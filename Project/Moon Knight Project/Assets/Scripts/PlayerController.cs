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

    //Jump Stuff
    private float moveSpeed;
    private float dirX;
    private float dirY;
    public bool ClimbingAllowed { get; set; }
    //public bool canWallJump = true;
    //public float wallSlidingSpeed = -0.45f;
    //public float verticalWallForce;
    //public float wallJumpTime;

    public bool isTouchingWalls;
    public bool climb;
    public bool ladleHold;
    //public bool wallJumping;

    public Transform wallCheck;
    //public ParticleSystem dust;
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
    public LayerMask laddleLayerMask;

    private Rigidbody2D rb;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        availableJumpLeft = availableJump;
        //Climb Stuff
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimation();
        CheckIfCanJump();

        if (ClimbingAllowed)
        {
            if (isTouchingWalls && !isGrounded && Input.anyKey)
            {
                climb = true;
                dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
            }
            if (isTouchingWalls && !isGrounded && !Input.anyKey)
            {
                ladleHold = true;
                climb = false;
                dirY = 0;
            }
            if (!isTouchingWalls && isGrounded)
            {
                climb = false;
            }
        }
        if (isGrounded)
        {
            ladleHold = false;
            climb = false;
        }

        //Variable Jump Height
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
        //Climb Stuff
        if (ClimbingAllowed)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(dirX, dirY);
        }
        else
        {
            rb.isKinematic = false;
        }
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
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
        if (availableJumpLeft <= 0)
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
        animator.SetBool("isClimb", climb);
        animator.SetBool("isnotClimb", ladleHold);

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckEnvironment()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayerMask);
        isTouchingWalls = Physics2D.OverlapCircle(wallCheck.position, groundCheckCircle, laddleLayerMask);
    }

    ////wallJumpStuff
    //private void setWallJumpToFalse()
    //{
    //    wallJumping = false;
    //    availableJumpLeft++;
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckCircle);
        //Gizmos.DrawWireSphere(wallCheck.position, groundCheckCircle);
    }
}
