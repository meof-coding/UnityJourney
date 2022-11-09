using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public Transform startingPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Chaise();
            Flip();
        }
        else
        {
            return;
        }
    }

    private void ReturnStartingPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Attack");
        //Play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Die animation
        animator.SetBool("isDead", true);
        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    private void Chaise()
    {
        animator.SetTrigger("Chaise");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
