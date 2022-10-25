using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviourScript : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - player.transform.position.x) < 2)
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isOpen", true);
        }
        Debug.Log(Mathf.Abs(transform.position.x - player.transform.position.x));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}
