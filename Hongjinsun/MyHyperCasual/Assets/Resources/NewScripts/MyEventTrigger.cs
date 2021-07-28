using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventHandler(object sender, EventArgs e);
public class MyEventTrigger : IMyEventTrigger
{
    List<IMyListener> listeners;
   
    public MyEventTrigger() { listeners = new List<IMyListener>(); }
    ~MyEventTrigger() { }

    public void Trigger(IMyListener listener, string state)
    {
        switch(state)
        {
            case "add":
                listeners.Add(listener);
                break;
            case "remove":
                listeners.Remove(listener);
                break;
            default:
                throw new System.NotImplementedException();
        }

    }

    public class MyEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Cnt { get; set; }
        public IMyListener Listener { get; set; }

    }



    public event EventHandler Clicked;

    public virtual void OnClicked(EventArgs e)
    {
        Debug.Log("OnClicked");
        if (Clicked != null)
            Clicked(this, e);
        else
            Debug.Log("Clicked�� ����");
    }

    //public delegate void MyEventHandler(string message);
    //public delegate void MyEventHandler();
    //public static event MyEventHandler MyEvent;

    //public event EventHandler<MyEventArgs> MyEvent;
    //public void Move()
    //{
    //    MyEventArgs args = new MyEventArgs();
    //    args.Name = "Move";
    //    args.Cnt = 1;
    //    Debug.Log(args.Listener);
    //    listeners.Add(args.Listener);
    //    OnEventTrigger(args);
    //    Debug.Log(args.Name + "�Լ� ȣ��");
    //}
    //public void AddScore(int n)
    //{
    //    MyEventArgs args = new MyEventArgs();
    //    args.Name = "AddScore";
    //    args.Cnt = n;
    //    OnEventTrigger(args);
    //    Debug.Log(args.Name + "�Լ� ȣ�� - Cnt : " + args.Cnt);
    //}


    //protected virtual void OnEventTrigger(MyEventArgs myEventArgs)
    //{
    //    MyEvent?.Invoke(this, myEventArgs);
    //    /*  �Ʒ� �ڵ尡 �ѹ������� ->  MyEvent?.Invoke(this, myEventArgs);
    //    EventHandler<MyEventArgs> handler = MyEvent;
    //    if (handler != null)
    //    {
    //        handler(this, myEventArgs);
    //    }
    //    */
    //}



    //public static void Do(bool key)
    //{
    //    if (key == true)
    //    {
    //        MyEvent("����ȭ��ǥ!");
    //        //Debug.Log("����ȭ��ǥ!");
    //    }
    //}


    //public static class SubScriber
    //{
    //    public static void Main()
    //    {
    //        Publisher p = new Publisher();
    //        Publisher.MyEvent += new MyEventHandler(DoAction);

    //        Publisher.Do(Input.GetKeyDown(KeyCode.RightArrow));
    //    }

    //    public static void DoAction(string message)
    //    {
    //        Debug.Log(message);
    //    }
    //}

}
