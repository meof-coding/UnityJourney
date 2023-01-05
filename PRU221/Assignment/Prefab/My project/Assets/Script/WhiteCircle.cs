using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCircle : Mover
{
    public Transform prefab;
    float timeout = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //instantiating the white circle for each 0.2 seconds
        if (timeout > 0)
        {
            // Reduces the timeout by the time passed since the last frame
            timeout -= Time.deltaTime;

            // return to not execute any code after that
            return;
        }
        // Spawn object once
        //RandomPosition(prefab);

        // Reset timer
        timeout = duration;
        if (Time.time > duration)
        {
            //RandomPosition(prefab);
            duration = Time.time + duration;
        }
    }
}
