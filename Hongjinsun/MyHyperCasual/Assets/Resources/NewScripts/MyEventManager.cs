using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MyEventManager : MonoBehaviour
{
	#region C# properties
	public static MyEventManager Instance
	{
		get { return instance; }
		set { }
	}
	#endregion

	#region variables
	private static MyEventManager instance = null;

	private Dictionary<EVENT_TYPE, List<IMyListener>> Listeners = new Dictionary<EVENT_TYPE, List<IMyListener>>();
	#endregion

	#region methods

	void Awake()
	{

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject); 
		}
		else 
			DestroyImmediate(this);
	}
	//-----------------------------------------------------------
	/// <summary>
	/// Function to add specified listener-object to array of listeners
	/// </summary>
	/// <param name="Event_Type">Event to Listen for</param>
	/// <param name="Listener">Object to listen for event</param>
	public void AddListener(EVENT_TYPE Event_Type, IMyListener Listener)
	{
		Debug.Log("AddListener");
		
		List<IMyListener> ListenList = null;

		
		if (Listeners.TryGetValue(Event_Type, out ListenList))
		{
			
			ListenList.Add(Listener);
			return;
		}

		
		ListenList = new List<IMyListener>();
		ListenList.Add(Listener);
		Listeners.Add(Event_Type, ListenList); 
	}
	//-----------------------------------------------------------
	/// <summary>
	/// Function to post event to listeners
	/// </summary>
	/// <param name="Event_Type">Event to invoke</param>
	/// <param name="Sender">Object invoking event</param>
	/// <param name="Param">Optional argument</param>
	public void PostNotification(EVENT_TYPE Event_Type, GameObject Sender, object Param = null)
	{
		Debug.Log("이건 되냐?");

		List<IMyListener> ListenList = null;

		if (!Listeners.TryGetValue(Event_Type, out ListenList))
			return;

		for (int i = 0; i < ListenList.Count; i++)
		{
			if (!ListenList[i].Equals(null)) 
				ListenList[i].OnEvent(Event_Type, Sender, Param);
		}
	}
	public void RemoveEvent(EVENT_TYPE Event_Type)
	{
		Listeners.Remove(Event_Type);
	}

	public void RemoveRedundancies()
	{

		Dictionary<EVENT_TYPE, List<IMyListener>> TmpListeners = new Dictionary<EVENT_TYPE, List<IMyListener>>();


		foreach (KeyValuePair<EVENT_TYPE, List<IMyListener>> Item in Listeners)
		{
			for (int i = Item.Value.Count - 1; i >= 0; i--)
			{
				if (Item.Value[i].Equals(null))
					Item.Value.RemoveAt(i);
			}

			if (Item.Value.Count > 0)
				TmpListeners.Add(Item.Key, Item.Value);
		}

		Listeners = TmpListeners;
	}

    //internal void PostNotification(EVENT_TYPE Event_Type, MyPlayerController myPlayerController, int m_score)
    //{
    //    throw new NotImplementedException();
    //}


    //void OnLevelWasLoaded()
    //{
    //    RemoveRedundancies();
    //}

    #endregion
}
