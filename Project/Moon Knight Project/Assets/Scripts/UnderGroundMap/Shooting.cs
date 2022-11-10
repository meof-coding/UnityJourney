using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject arrowPrefabs;
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -1 * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(arrowPrefabs, shootingPoint.position, transform.rotation);

    }
}
