using System;

public class Character
{
    void Init()
    {
        EventTrigger.AddListener(OnJumpEvent);
    }

    void OnJumpEvent(IEvent e)
    {
        var ev = e as JumpEvent;
    }
}
