using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FGB_TitleUI
{
    GameObject UIRoot, UITitle;
    Button GameStartBT;

    public void Init()
    {
        UITitle = Share.Util.InstantiatePrefab(Share.Path.Prefab.Panel, FGB_UIRoot.canvas);
        GameStartBT = GameObject.Find("Button").GetComponent<Button>();
        GameStartBT.onClick.AddListener(() => onClick());
        Time.timeScale = 0;
    }

    public void onClick()
    {
        UITitle.SetActive(false);
        Time.timeScale = 1;
        FGB_UIManager.InGameInit();
    }
}

public class FGB_GameoverUI
{
    GameObject uiRoot, uiGameover;

    public void onClick()
    {

    }
}