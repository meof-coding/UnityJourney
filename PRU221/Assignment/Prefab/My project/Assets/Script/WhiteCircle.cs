using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCircle : Mover
{
    [SerializeField]
    //make field visible in Inspector
    GameObject prefabCirlce;
    // Start is called before the first frame update
    void Start()
    {
        InitSpawn(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRandom(prefabCirlce);
    }
}
