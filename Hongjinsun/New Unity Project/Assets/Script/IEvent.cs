
public enum EVENT_TYPE
{
    Jump
}
public interface IEvent
{
    EVENT_TYPE GetEventType();
}
