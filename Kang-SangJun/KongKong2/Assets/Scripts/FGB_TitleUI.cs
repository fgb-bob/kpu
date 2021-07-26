using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FGB_TitleUI
{
    GameObject uiRoot, uiTitle;
    Button GameStartBT;

    public void Init()
    {
        uiTitle = Share.Util.InstantiatePrefab(Share.Path.Prefab.Panel, UIRoot.canvas);
        GameStartBT = GameObject.Find("Button").GetComponent<Button>();
        GameStartBT.onClick.AddListener(() => onClick());
        Time.timeScale = 0;
    }

    public void onClick()
    {
        uiTitle.SetActive(false);
        Time.timeScale = 1;
        FGB_UIManager.LevelUI_Init();
    }
}
public class FGB_InGameUI
{
    GameObject uiLevel;
    GameObject uiDeath;
    public void Init()
    {
        uiLevel = Share.Util.InstantiatePrefab(Share.Path.Prefab.Level, UIRoot.canvas);
        uiDeath = Share.Util.InstantiatePrefab(Share.Path.Prefab.Death, UIRoot.canvas);
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

public class FGB_GameoverUI
{
    GameObject uiRoot, uiGameover;

    public void onClick()
    {

    }
}