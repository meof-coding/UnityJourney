using UnityEngine;
using UnityEngine.Events;

public class MessageEvent : UnityEvent
{
    //method when message event is invoke
    public void Invoke()
    {
        //print message
        Debug.Log("MessageEvent");
    }
}