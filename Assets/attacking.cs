using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacking : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
private IEnumerator attack()
{
    anim.SetBool("Attack", true);
    yield return new WaitForSeconds(1);
    anim.SetBool("Attack", false);
}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            StartCoroutine(attack());
        }
    }
}
