//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System;

//public class MyEventManager : MonoBehaviour
//{
//	#region C# properties
//	public static MyEventManager Instance
//	{
//		get { return instance; }
//		set { }
//	}
//	#endregion

//	#region variables
//	private static MyEventManager instance = null;

//    private Dictionary<EVENT_TYPE, List<IMyListener>> Listeners = new Dictionary<EVENT_TYPE, List<IMyListener>>();
//    #endregion

//    #region methods

//    void Awake()
//    {

//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//            DestroyImmediate(this);
//    }
//    //-----------------------------------------------------------
//    /// <summary>
//    /// Function to add specified listener-object to array of listeners
//    /// </summary>
//    /// <param name="Event_Type">Event to Listen for</param>
//    /// <param name="Listener">Object to listen for event</param>
//    public void AddListener(EVENT_TYPE Event_Type, IMyListener Listener)
//    {
//        Debug.Log("AddListener");

//        List<IMyListener> ListenList = null;


//        if (Listeners.TryGetValue(Event_Type, out ListenList))
//        {

//            ListenList.Add(Listener);
//            return;
//        }


//        ListenList = new List<IMyListener>();
//        ListenList.Add(Listener);
//        Listeners.Add(Event_Type, ListenList);
//    }
//    //-----------------------------------------------------------
//    /// <summary>
//    /// Function to post event to listeners
//    /// </summary>
//    /// <param name="Event_Type">Event to invoke</param>
//    /// <param name="Sender">Object invoking event</param>
//    /// <param name="Param">Optional argument</param>
//    public void postnotification(EVENT_TYPE event_type, gameobject sender, object param = null)
//    {
//        debug.log("이건 되냐?");

//        list<imylistener> listenlist = null;

//        if (!listeners.trygetvalue(event_type, out listenlist))
//            return;

//        for (int i = 0; i < listenlist.count; i++)
//        {
//            if (!listenlist[i].equals(null))
//                listenlist[i].onevent(event_type, sender, param);
//        }
//    }
//    public void removeevent(EVENT_TYPE event_type)
//    {
//        listeners.remove(event_type);
//    }

//    public void removeredundancies()
//    {

//        dictionary<EVENT_TYPE, list<imylistener>> tmplisteners = new dictionary<EVENT_TYPE, list<imylistener>>();


//        foreach (keyvaluepair<EVENT_TYPE, list<imylistener>> item in listeners)
//        {
//            for (int i = item.value.count - 1; i >= 0; i--)
//            {
//                if (item.value[i].equals(null))
//                    item.value.removeat(i);
//            }

//            if (item.value.count > 0)
//                tmplisteners.add(item.key, item.value);
//        }

//        listeners = tmplisteners;
//    }

//    //internal void postnotification(event_type event_type, myplayercontroller myplayercontroller, int m_score)
//    //{
//    //    throw new notimplementedexception();
//    //}


//    //void onlevelwasloaded()
//    //{
//    //    removeredundancies();
//    //}

//    #endregion
//}
