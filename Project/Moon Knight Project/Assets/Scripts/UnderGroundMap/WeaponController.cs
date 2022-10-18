using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (collision.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

    }
}
