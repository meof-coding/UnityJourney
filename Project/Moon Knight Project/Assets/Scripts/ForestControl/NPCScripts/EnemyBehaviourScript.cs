using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public GameObject diem1;
    public GameObject diem2;
    public static int diem;
    Vector2 vec;
    public GameObject player;
    Animator animator;
    Collision2D collision;
    //thanh mau
    [SerializeField]
    public HealthBar healthBar;
    int health=10000;
    int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        collision = gameObject.GetComponent<Collision2D>();
    }
    
    
    // Update is called once per frame
 
    void Update() 
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 2)
        {
            if(transform.position.x - player.transform.position.x > 0)
            {
                Vector2 localScale = transform.localScale;
                if (localScale.x > 0)
                    localScale.x *= -1.0f;
                gameObject.transform.localScale = localScale;
            }
            else
            {
                Vector2 localScale = transform.localScale;
                if (localScale.x < 0)
                    localScale.x *= -1.0f;
                gameObject.transform.localScale = localScale;
            }
            animator.SetBool("isEnemyRun", false);
            animator.SetBool("isEnemyAttack", true);
            

        }
        else
        {
            animator.SetBool("isEnemyRun", true);
            animator.SetBool("isEnemyAttack", false);
            if (transform.position == diem1.transform.position)
            {
                diem = 1;
            }

            if (transform.position == diem2.transform.position)
            {
                diem = 2;
            }
            switch (diem)
            {
                case 1:
                    Debug.Log("diem1");

                    vec = transform.localScale;
                    vec.y = 1;
                    if (vec.x < 0)
                        vec.x *= -1.0f;
                    transform.localScale = vec;
                    deg(diem2);

                    break;
                case 2:
                    Debug.Log("diem2");

                    vec.y = 1;
                    if (vec.x > 0)
                        vec.x *= -1.0f;
                    transform.localScale = vec;
                    deg(diem1);

                    break;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
           if (Mathf.Abs(transform.position.x - player.transform.position.x) < 2
                && Mathf.Abs(transform.position.y - player.transform.position.y) < 10)
           {
                health -= damage;
                healthBar.SetHealth(health);
            }
            
        }
        if (health <= 0)
        {
       
            animator.SetBool("isDead", true);
            animator.SetBool("isEnemyRun", false);
            animator.SetBool("isEnemyAttack", false);
            StartCoroutine(Dead());
        }

    }
    public void deg(GameObject vitri)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, vitri.transform.position, 1 * Time.deltaTime);
        Debug.Log("deg");    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
   
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
