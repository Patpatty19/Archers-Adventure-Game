using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{


    public static AudioClip attackSound, jumpSound, buffSound, debuffSound, walkSound, landSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        attackSound = Resources.Load<AudioClip>("attack");
        jumpSound = Resources.Load<AudioClip>("finaljump2");
        buffSound = Resources.Load<AudioClip>("buff");
        debuffSound = Resources.Load<AudioClip>("debuff");
        landSound = Resources.Load<AudioClip>("land");
        walkSound = Resources.Load<AudioClip>("finalwalk"); 

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "attack":
                audioSrc.PlayOneShot(attackSound);
                break;

            case "finaljump2":
                audioSrc.PlayOneShot(jumpSound);
                break;

            case "buff":
                audioSrc.PlayOneShot(buffSound);
                break;

            case "debuff":
                audioSrc.PlayOneShot(debuffSound);
                break;

            case "land":
                audioSrc.PlayOneShot(landSound);
                break;


                 case "finalwalk":
                     audioSrc.PlayOneShot(walkSound);
                     break; 
        }
    }

}
