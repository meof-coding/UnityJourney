using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event invoker
/// </summary>
public class Invoker : MonoBehaviour
{
    // add your fields for your message event support here
    Timer timer;

    // add your fields for your count message event support here
    CountMessageEvent countMessageEvent;
    MessageEvent messageEvent;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    public void Awake()
    {
        // add your code here
        //create an instance of the MessageEvent object of that field
        messageEvent = new MessageEvent();
        countMessageEvent = new CountMessageEvent();
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public void Start()
    {
        // add your code here
        //add the Invoker as a no argument invoker in the EventManager
        EventManager.AddNoArgumentInvoker(this);
        //add a Timer component,
        timer = gameObject.AddComponent<Timer>();
        // set its duration to 1 second
        timer.Duration = 1;
        //run the timer
        timer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // add your code here
        //check if the timer has finished
        if (timer.Finished)
        {
            //call InvokenoArgumentEvent
            InvokeNoArgumentEvent();
            //run the timer again
            timer.Run();
        }
    }

    /// <summary>
    /// Adds the given listener to the no argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddNoArgumentListener(UnityAction listener)
    {
        // add your code here to add the given listener for
        // the message event
        messageEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener to the one argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddOneArgumentListener(UnityAction<int> listener)
    {
        // add your code here to 
        //add the given listener for the count message event
        countMessageEvent.AddListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the no argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveNoArgumentListener(UnityAction listener)
    {
        // add your code here to remove the given listener from the
        // message event
        messageEvent.RemoveListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the one argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveOneArgumentListener(UnityAction<int> listener)
    {
        // add your code here to remove the given listener from the
        // count message event
        countMessageEvent.RemoveListener(listener);
    }

    /// <summary>
    /// Invokes the no argument event
    /// 
    /// NOTE: We need this public method for the autograder to work
    /// </summary>
    public void InvokeNoArgumentEvent()
    {
        // add your code here to invoke the message event
        messageEvent.Invoke();
    }

    /// <summary>
    /// Invokes the one argument event
    /// 
    /// NOTE: We need this public method for the autograder to work
    /// </summary>
    /// <param name="argument">argument to use for the Invoke</param>
    public void InvokeOneArgumentEvent(int argument)
    {
        // add your code here to invoke the count message event
        // with the given argument
        countMessageEvent.Invoke(argument);
    }
}
