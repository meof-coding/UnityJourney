using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    GameObject objToDestroy;
    bool canDestroy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objToDestroy = gameObject;
        canDestroy = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G) && canDestroy)
        {
            Destroy(objToDestroy);
            canDestroy = false;
        }
    }
}
