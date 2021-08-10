using System;
using System.Collections.Generic;

public class EventTrigger
{
    Dictionary<EVENT_TYPE, List<Action<IEvent>>> listeners;

    void Init()
    {
        listeners = new Dictionary<EVENT_TYPE, List<Action<IEvent>>>();
    }

    public static void AddListener(Action<IEvent> e)
    {
        
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
