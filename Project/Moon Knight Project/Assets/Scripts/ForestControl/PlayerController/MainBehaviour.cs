using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 localScale;
    Animator animator;
    public float movementSpeed = 5.0f;
    private float InputDirection;
    public float jumpForce = 5.0f;
    private GameObject enemy;
    //thanh mau
    [SerializeField]
    HealthBar healthBar;
    int health = 10000;
    int damage = 200;
    int healthBack = 5000;
    public float spawnDelay = 2;

    //di chuyển
    private bool isStay;
    private bool isRun;
    private bool isAttack;
   
    //button
    public GameObject swordButton;
    public GameObject spearButton;
    public GameObject healthButton;
    private Button btnSword;
    private Button btnSpear;
    private Button btnHealth;

    //check vu khi
    private bool isSword = false;
    private bool isSpear = false;

    //hien thi panel khi dead/win
    public GameObject panelDead;
    public GameObject panelWin;
    public GameObject outDoor;
    public GameObject keyButton;
    private Button btnKey;
    private bool isActiveKey = false;


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        //get button
        btnSword = swordButton.GetComponent<Button>();
        btnSpear = spearButton.GetComponent<Button>();
        btnHealth = healthButton.GetComponent<Button>();
        btnKey = keyButton.GetComponent<Button>();
        //gọi ham click
        btnSword.onClick.AddListener(TaskOnSwordClick);
        btnSpear.onClick.AddListener(TaskOnSpearClick);
        btnHealth.onClick.AddListener(TaskOnHealthClick);
        
        //set Panel
        panelDead.SetActive(false);
        panelWin.SetActive(isActiveKey);
        btnKey.onClick.AddListener(TaskOnKeyClick);
    }

   


    // Update is called once per frame
    void Update()
    {
        //di chuyen
        getInput();

        if (isStay)
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsStay", true);
            animator.SetBool("isAttack", false);
        }
        else if (isRun)
        {
            animator.SetBool("IsRun", true);
            animator.SetBool("IsStay", false);
            animator.SetBool("isAttack", false);
        }
        else if (isAttack)
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsStay", false);
            animator.SetBool("isAttack", true);
        }
       
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

        //chuyen doi vu khi
        if (isSword)
        {
            animator.SetBool("isSword", true);
            animator.SetBool("isSpear", false);
        }
        if (isSpear)
        {
            animator.SetBool("isSpear", true);
            animator.SetBool("isSword", false);
        }

        //check main die
        if (health <= 0)
        {
            animator.SetBool("isDie", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsStay", false);
            animator.SetBool("isAttack", false);
            StartCoroutine(Dead());
            
        }
        panelWin.SetActive(isActiveKey);
    }


    //di chuyển
    void getInput()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            isStay = false;
            isRun = true;
            isAttack = false;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            isStay = false;
            isRun = false;
            isAttack = true;
        }
        else
        {
            isStay = true;
            isRun = false;
            isAttack = false;
        }
    }
    void GoLeft()
    {

        Vector2 localScale = transform.localScale;
        if (localScale.x > 0)
            localScale.x *= -1.0f;
        gameObject.transform.localScale = localScale;
        InputDirection = -0.5f;
        rb.velocity = new Vector2(movementSpeed * InputDirection, rb.velocity.y);
    }

    void GoRight()
    {

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



    //Enemy attack
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject;

                StartCoroutine(EnemyHit());
        
        }
    }
    IEnumerator EnemyHit()
    {
        if (Mathf.Abs(enemy.transform.position.x - transform.position.x) < 2)
        {
            health -= damage;
            healthBar.SetHealth(health);
        }

        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(EnemyHit());
    }


    //Button
    void TaskOnSwordClick()
    {
        isSpear = false;
        isSword = true;
    }
    void TaskOnSpearClick()
    {
        isSword = false;
        isSpear = true;
    }
    void TaskOnHealthClick()
    {
        health += 5000;
        healthBar.SetHealth(health);
    }
    void TaskOnKeyClick()
    {
        if (Mathf.Abs(outDoor.transform.position.x - transform.position.x) < 5)
       {
           isActiveKey = true;
      }
    }

    //dead function
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        panelDead.SetActive(true);
    }
}

