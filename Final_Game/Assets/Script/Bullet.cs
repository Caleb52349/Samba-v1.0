using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

 void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.tag !=("turret"))
            
        {
            if(col.CompareTag("Player"))
            {
                col.GetComponent<Player>().Damage(1);
                soundManagerScript.PlaySound("playerHit");
            }

            Destroy(gameObject);
        }
    }
}
