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

    void Open()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isClose", false);
        animator.SetBool("isOpen", true);
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
        if (Input.GetKey(KeyCode.O))
        {
            animator.SetBool("isClose", false);
            animator.SetBool("isOpen", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Open();
        }
    }
}
