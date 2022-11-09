using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public enum soundsGame
    {
        hit,
        run
    }
    // Start is called before the first frame update
 
    public AudioClip soundHit;
    public AudioClip soundRun;
    public static SoundController instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }
    public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            
            case soundsGame.hit:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundHit);
                }
                break;
           
            case soundsGame.run:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundRun);
                }
                break;
           
        }
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.RightArrow))
        {
            SoundController.PlaySound(soundsGame.run);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SoundController.PlaySound(soundsGame.run);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            SoundController.PlaySound(soundsGame.hit);

        }
    }

}
