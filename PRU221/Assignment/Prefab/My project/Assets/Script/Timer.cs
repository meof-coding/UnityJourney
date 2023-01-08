using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    //timer duration
    float totalSeconds = 0;
    //timer execution
    float elapsedSeconds = 0;
    bool running = false;
    //support for Finished property
    bool started = false;
    private float startTime;

    public bool Finished { get { return started && !running; } }
    public float Duration
    {
        set
        {
            if (!running) { totalSeconds = value; }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Run()
    {
        if (totalSeconds > 0)
        {
            running = true;
            started = true;
            elapsedSeconds = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }
}
