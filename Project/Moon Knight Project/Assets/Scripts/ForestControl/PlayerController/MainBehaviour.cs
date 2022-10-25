using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 localScale;
    Animator animator;
    public float movementSpeed = 5.0f;
    private float InputDirection;
    public float jumpForce = 5.0f;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void GoLeft()
    {
        animator.SetBool("IsRun", true);
        animator.SetBool("IsStay", false);
        Vector2 localScale = transform.localScale;
        if (localScale.x > 0)
            localScale.x *= -1.0f;
        gameObject.transform.localScale = localScale;
        InputDirection = -0.5f;
        rb.velocity = new Vector2(movementSpeed * InputDirection, rb.velocity.y);
    }

    void GoRight()
    {
        animator.SetBool("IsRun", true);
        animator.SetBool("IsStay", false);
        Vector2 localScale = transform.localScale;
        if (localScale.x < 0)
            localScale.x *= -1.0f;
        gameObject.transform.localScale = localScale;
        InputDirection = 0.5f;
        rb.velocity = new Vector2(movementSpeed * InputDirection, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Debug.Log("Va cham " + gameObject.name);
    }
}
