using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject sdiem;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, sdiem.transform.position, 2 * Time.deltaTime);
            
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            button.SetActive(true);
        }
    }
}
