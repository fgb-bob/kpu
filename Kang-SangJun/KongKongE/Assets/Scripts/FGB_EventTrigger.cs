using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum FGB_EventType
{

    Title = 0, Jump
}
interface FGB_IEvnet
{
    FGB_EventType GetEventType();
}

public class FGB_TitleEvent : FGB_IEvnet
{
    public FGB_EventType GetEventType()
    {
        return FGB_EventType.Title;
    }
}

public class FGB_EventTrigger
{
    static Dictionary<FGB_EventType, List<Action<FGB_IEvnet>>> Dic ;

}
