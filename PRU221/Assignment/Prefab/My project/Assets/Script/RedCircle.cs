using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RedCircle : Mover
{

    // Start is called before the first frame update
    void Start()
    {
        OnPlacedRandom(gameObject);
        //generate prefab at random position in screen bound
        MoveRandom();
    }

    // Update is called once per frame
    void Update()
    {
        //moving object

    }
}
