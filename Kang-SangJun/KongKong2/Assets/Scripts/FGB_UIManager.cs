using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FGB_UIManager
{
    static GameObject uiRoot;
    public GameObject Button;
    private static FGB_TitleUI title = new FGB_TitleUI();
    private static FGB_InGameUI inGame = new FGB_InGameUI();
    private FGB_GameoverUI gameover = new FGB_GameoverUI();

    public static void LevelUI_Init()
    {
        inGame.Init();

    }
    public static void Level_Change(int Level)
    {
        inGame.GetObjectLevel().GetComponent<Text>().text = "Level " + Level;
    }
    public static void Death_Count(int Count)
    {
        inGame.GetObjectDeath().GetComponent<Text>().text = "Death Count " + Count;
    }
    public static void SetCanvas()
    {
        GameObject.DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));
    }

    public static void TitleUI_Init()
    {
        title.Init();
    }

    public static void SetButton(string Name)
    {

    }

    public static void InstantiatUI(GameObject Obj)
    {

    }
}
