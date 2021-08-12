using System;
using UnityEngine;

public class Character
{
    public void Init()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            EventTrigger.AddListener(OnJumpEvent);
    }
    void OnJumpEvent(IEvent e)
    {
        Debug.Log("OnJumpEvent호출");
        var ev = e as JumpEvent;
    }

    
}
