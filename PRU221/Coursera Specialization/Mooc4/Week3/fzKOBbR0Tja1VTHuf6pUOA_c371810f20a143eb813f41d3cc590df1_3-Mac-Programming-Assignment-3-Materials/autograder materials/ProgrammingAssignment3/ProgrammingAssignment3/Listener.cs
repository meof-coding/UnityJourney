using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An event listener
/// </summary>
public class Listener : MonoBehaviour
{
    public void Start()
    {
        // add your code here
        //add HandleMessageEvent as a no argument listener in the EventManager
        EventManager.AddNoArgumentListener(HandleMessageEvent);
    }

    /// <summary>
    /// Handles the no argument event
    /// </summary>
    void HandleMessageEvent()
    {
        print("MessageEvent");
    }

    /// <summary>
    /// Handles the one argument event
    /// </summary>
    /// <param name="number">number</number>
    void HandleCountMessageEvent(int number)
    {
        print("CountMessageEvent: " + number);
    }
}
