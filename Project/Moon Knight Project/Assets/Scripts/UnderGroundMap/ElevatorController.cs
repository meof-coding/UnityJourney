using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    //Speed of platform
    public float speed;
    //Starting index
    public int startingPoint;
    //Array of transform point
    public Transform[] points;

    //Index of array
    private int i;
    public bool isTrigger = false;

    public void Active()
    {
        //Setting position of platform to the position of starting Point

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            //increase index
            i++;
            //check if the platform was on the last point after the index increase
            if (i == points.Length)
            {
                i = 0;
            }
        }
        //moving the platform to the points with the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            Active();
        }
    }
}
