using UnityEngine;

public interface IMyEventTrigger
{
    void Trigger(IMyListener listener, string state);

}
