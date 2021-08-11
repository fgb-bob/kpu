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

        foreach(var item in list)
        {
            Debug.Log(item.Method);
        }

        listeners.Add(EVENT_TYPE.Jump, list);
        foreach(KeyValuePair<EVENT_TYPE, List<Action<IEvent>>> item in listeners)
        {
            Debug.Log(item.Key + ", " + item.Value);
        }
        //if (listeners[e] != null)
    }

    public static void Do(IEvent e)
    {
        //listeners[e] => ;
        List<Action<IEvent>> list;
        list = new List<Action<IEvent>>();

        foreach(var listener in list)
        {
            listener(e);
        }
    }

}
