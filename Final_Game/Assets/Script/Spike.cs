using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Player player;
    private bool enableDmg = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();



    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player") && enableDmg)
        {
            player.Damage(1);
            StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
            enableDmg = false;
            

        }


    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !enableDmg)
        {
            enableDmg = true;
           

        }


    }
}

