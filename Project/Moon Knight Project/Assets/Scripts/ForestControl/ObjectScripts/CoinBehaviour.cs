using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject sdiem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, sdiem.transform.position, 2 * Time.deltaTime);
            if (Input.GetKey(KeyCode.G))
            {
                Destroy(gameObject);
            }
        }
        

    }
}
