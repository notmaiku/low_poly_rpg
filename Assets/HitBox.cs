using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
   //Attach this script to your GameObject. This GameObject doesn’t need to have a Collider component
//Set the Layer Mask field in the Inspector to the layer you would like to see collisions in (set to Everything if you are unsure).
//Create a second Gameobject for testing collisions. Make sure your GameObject has a Collider component (if it doesn’t, click on the Add Component button in the GameObject’s Inspector, and go to Physics>Box Collider).
//Place it so it is overlapping your other GameObject.
//Press Play to see the console output the name of your second GameObject

//This script uses the OverlapBox that creates an invisible Box Collider that detects multiple collisions with other colliders. The OverlapBox in this case is the same size and position as the GameObject you attach it to (acting as a replacement for the BoxCollider component).

    bool m_Started;
    public LayerMask m_LayerMask;
    private Animator anim;
    private const int magnitude=2000;
    public GameObject player;
    Collider coll;
    public float hitTime = 0;
    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
        player = GameObject.FindWithTag("Player");
        anim=player.GetComponent<Animator>();
        coll = GetComponent<Collider>();
        coll.isTrigger = false;
    }

    void Update(){
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&  this.hitTime < anim.GetCurrentAnimatorStateInfo(0).length){
            coll.isTrigger = true;
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("None")){
            this.hitTime = 0;
        }
    }
    void OnTriggerEnter(Collider other) {
        coll.isTrigger = false;
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
        try {
            this.hitTime += 1;
            EnemyController enemy = other.GetComponent("EnemyController") as EnemyController;
            enemy.HP -= 25;
            print(enemy.HP);
        } catch (System.NullReferenceException e) {
            print("ERROR: Bullet collided with a non enemy - " + e);
        }
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
