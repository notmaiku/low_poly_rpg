﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript : MonoBehaviour {
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if(Input.GetKeyDown("left shift")){
                speed *= 2;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if(Input.GetKeyDown("space")){
            jump();
        }
        gravity();
    }
    public void jump(){
        controller.Move(Vector3.up * 100f * Time.deltaTime);
    }

    public void gravity(){
        controller.Move(Vector3.down * 4.5f * Time.deltaTime);
    }
}
