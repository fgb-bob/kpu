
public class JumpEvent : IEvent
{
    public EVENT_TYPE GetEventType()
    {
        return EVENT_TYPE.Jump;
        //throw new System.NotImplementedException();
    }
}
