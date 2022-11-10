using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemyController = collision.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.TakeDamage(20);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
