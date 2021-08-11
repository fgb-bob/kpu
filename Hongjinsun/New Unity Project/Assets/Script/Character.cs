using System;
using UnityEngine;

public class Character
{
    public void Init()
    {

        EventTrigger.AddListener(OnJumpEvent);
    }

    public void Update()
    {
        
    }
    void OnJumpEvent(IEvent e)
    {
        var ev = e as JumpEvent;
    }
}
