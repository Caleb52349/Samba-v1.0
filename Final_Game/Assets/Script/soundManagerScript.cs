using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, FireSound, jumpSound;
    static AudioSource audioSrc;
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
       jumpSound = Resources.Load<AudioClip>("jump");
        FireSound = Resources.Load<AudioClip>("laser1");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "laser1":
                audioSrc.PlayOneShot(FireSound);
                break;
        }
    }
}
