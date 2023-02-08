using UnityEngine.Events;
using System.Collections;
using UnityEngine;

public class CountMessageEvent : UnityEvent<int>
{
    public void Invoke(int message)
    {
        Debug.Log("CountMessageEvent: " + message);
    }
}

