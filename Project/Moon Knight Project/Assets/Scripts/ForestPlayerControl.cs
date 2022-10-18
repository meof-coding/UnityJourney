using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPlayerControl : MonoBehaviour
{

    Rigidbody2D rigid;
    Vector2 localScale;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void GoLeft(float force)
    {
        Vector2 localScale = transform.localScale;
        if (localScale.x > 0)
            localScale.x *= -1.0f;
        gameObject.transform.localScale = localScale;
        Vector2 v = new Vector2(-0.2f, 0);
        rigid.AddForce(v * force, ForceMode2D.Impulse);
    }

    void GoRight(float force)
    {
        Vector2 localScale = transform.localScale;
        if (localScale.x < 0)
            localScale.x *= -1.0f;
        gameObject.transform.localScale = localScale;
        Vector2 v = new Vector2(0.2f, 0);
        rigid.AddForce(v * force, ForceMode2D.Impulse);
    }

    void Jump(float force)
    {
        Vector2 v = new Vector2(0, 1);
        rigid.AddForce(v * force, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump(1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight(2);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft(2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Debug.Log("Va cham " + gameObject.name);
    }
}
