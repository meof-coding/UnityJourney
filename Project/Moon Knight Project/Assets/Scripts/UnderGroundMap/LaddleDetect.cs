using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaddleDetect : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Laddle>())
        {
            player.ClimbingAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Laddle>())
        {
            player.ClimbingAllowed = false;
        }
    }
}
