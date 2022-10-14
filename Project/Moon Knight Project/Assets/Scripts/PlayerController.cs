using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Accessible by inspector
    public float movementSpeed = 5.0f;
    //Jumping Float
    public float jumpForce = 8.0f;
    public float fallMutiplier;
    public float lowJumpMultiplier;

    public int availableJump = 1;
    private int availableJumpLeft;
    private bool canJump;
    //Not accessible by Inspector
    private float InputDirection;
    //Related to running and flipping

    private bool isRunning;
    private bool isFacingRight = true;
    private bool isGrounded;
    //Groundcheck / Bool animator
    public float groundCheckCircle;
    public Transform groundCheck;
    public LayerMask groundLayerMask;

    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        availableJumpLeft = availableJump;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimation();
        CheckIfCanJump();

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    //update every second
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckEnvironment();
    }

    private void CheckInput()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");

        //Check input for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            availableJumpLeft--;
        }
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 3)
        {
            availableJumpLeft = availableJump;
        }
        else if (availableJumpLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * InputDirection, rb.velocity.y);
    }

    private void CheckMovementDirection()
    {
        //is Moving to Left
        if (isFacingRight && InputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && InputDirection > 0)
        {
            Flip();
        }

        if (rb.velocity.x <= -0.5f || rb.velocity.x >= 0.5f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void UpdateAnimation()
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckEnvironment()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckCircle);
    }
}
