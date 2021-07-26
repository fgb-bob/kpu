using UnityEngine;

public interface IMyListener
{
    void OnEvent(EventType eventType, string eventParameter);
}
