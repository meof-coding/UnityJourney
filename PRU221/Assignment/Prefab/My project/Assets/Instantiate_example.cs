using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_example : MonoBehaviour
{
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, new Vector3(2.0F, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
