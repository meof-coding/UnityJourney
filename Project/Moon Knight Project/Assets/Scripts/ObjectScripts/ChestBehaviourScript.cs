using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviourScript : MonoBehaviour
{
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
        if(Input.GetKey(KeyCode.O))
        {
            Open();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Open ();
    }
}
