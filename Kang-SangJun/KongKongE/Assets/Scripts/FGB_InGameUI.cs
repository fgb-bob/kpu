using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_InGameUI
{
    GameObject uiLevel;
    GameObject uiDeath;
    public void Init()
    {
        uiLevel = Share.Util.InstantiatePrefab(Share.Path.Prefab.Level, FGB_UIRoot.canvas);
        uiDeath = Share.Util.InstantiatePrefab(Share.Path.Prefab.Death, FGB_UIRoot.canvas);
    }

    public GameObject GetObjectLevel()
    {
        return uiLevel;
    }
    public GameObject GetObjectDeath()
    {
        return uiDeath;
    }
}
