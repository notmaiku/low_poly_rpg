using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collide : MonoBehaviour {
  public Rigidbody explosion;
  public float radius = 100.0F;
  public float power = 100.0F;
  private bool exploded=false;
  void OnCollisionEnter(Collision collision) {
    /*try {
        EnemyController enemy = collision.collider.GetComponent("EnemyController") as EnemyController;
        enemy.HP -= 25;
        print(enemy.HP);
    } catch (System.NullReferenceException e) {
        print("ERROR: Bullet collided with a non enemy - " + e);
    }*/
    if(!exploded)
    {
        exploded=true;
        Vector3 explosionPos = transform.position;
        Rigidbody bomb = Instantiate(explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            try {
                EnemyController enemy = collision.collider.GetComponent("EnemyController") as EnemyController;
                enemy.HP -= 50;
                print(enemy.HP);
            } catch (System.NullReferenceException e) {
            print("ERROR: Bullet collided with a non enemy - " + e);
            }
        }
    }
  }
}
// void OnDrawGizmos() {
//         Gizmos.color = Color.red;
//         //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
//         if (m_start)
//             //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
//             Gizmos.DrawWireCube(transform.position, transform.localScale);
//     }
// }
