using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool canDestroy = false;
    public List<GameObject> PlayersInTrigger;
    //Audio Controller
    public AudioSource audioPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canDestroy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G) && canDestroy)
        {
            //Destroy(objToDestroy);
            audioPlayer.Play();
            canDestroy = false;
        }
    }


}
