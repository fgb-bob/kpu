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
        if (listeners[EVENT_TYPE.Jump] != null)
        {
            Debug.Log("추가");
            listeners[EVENT_TYPE.Jump].Add(e);
        }
        else
        {
            List<Action<IEvent>> list = new List<Action<IEvent>>();
            list.Add(e);
            Debug.Log("생성");
            listeners.Add(EVENT_TYPE.Jump, list);
        }


        foreach (KeyValuePair<EVENT_TYPE, List<Action<IEvent>>> item in listeners)
        {
            Debug.Log(item.Key + ", " + item.Value);
        }
    }

    public static void Do(IEvent e)
    {
        Debug.Log("Do함수");
    }

}
