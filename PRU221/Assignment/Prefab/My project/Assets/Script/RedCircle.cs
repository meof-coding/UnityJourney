using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RedCircle : Mover
{
    [SerializeField]
    //make field visible in Inspector
    GameObject prefabCirlce;

    [SerializeField]
    //make field visible in Inspector
    object circleSprites { get; set; }
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
