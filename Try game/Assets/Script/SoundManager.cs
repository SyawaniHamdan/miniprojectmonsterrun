using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerJump, playerHit, playerDie, playerBreak, playerCollect, playerDone;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerJump = Resources.Load<AudioClip>("pJump");
        playerHit = Resources.Load<AudioClip>("pHit");
        playerDie = Resources.Load<AudioClip>("pDie");
        playerBreak = Resources.Load<AudioClip>("pBreak");
        playerCollect = Resources.Load<AudioClip>("pCollect");
        playerDone = Resources.Load<AudioClip>("pDone");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "pJump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "pHit":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "pDie":
                audioSrc.PlayOneShot(playerDie);
                break;
            case "pBreak":
                audioSrc.PlayOneShot(playerBreak);
                break;
            case "pCollect":
                audioSrc.PlayOneShot(playerCollect);
                break;
            case "pDone":
                audioSrc.PlayOneShot(playerDone);
                break;
        }
    }
}
