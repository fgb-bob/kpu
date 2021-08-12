using System;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger
{
    static Dictionary<EVENT_TYPE, List<Action<IEvent>>> listeners;

    public void Init()
    {
        listeners = new Dictionary<EVENT_TYPE, List<Action<IEvent>>>();
    }

    public static void AddListener(Action<IEvent> e)
    {
        // e.Method == void OnJumpEvent();
        List<Action<IEvent>> list = new List<Action<IEvent>>();
        list.Add(e);
        list[0].Invoke(new JumpEvent());
        
        // if ( listeners[] != null)
        foreach (var item in list)
        {
            Debug.Log(item.Method);
        }
     
        foreach (KeyValuePair<EVENT_TYPE, List<Action<IEvent>>> item in listeners)
        {
            Debug.Log(item.Key + ", " + item.Value);
        }

        listeners.Add(EVENT_TYPE.Jump, list);

        
        //if (listeners[e] != null)
    }

    public static void Do(IEvent e)
    {

        Debug.Log("Do함수");
    }

}
