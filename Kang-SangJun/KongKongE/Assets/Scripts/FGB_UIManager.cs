using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FGB_UIManager
{
    static GameObject UIRoot;
    public GameObject Button;
    private static FGB_TitleUI title = new FGB_TitleUI();
    private static FGB_InGameUI inGame = new FGB_InGameUI();
    private FGB_GameoverUI gameover = new FGB_GameoverUI();

    public static void InGameInit()
    {
        inGame.Init();

    }

    public static void TitleInit()
    {
        title.Init();
        
    }



    public static void ChagneLevel(int Level)
    {
        inGame.GetObjectLevel().GetComponent<Text>().text = "Level " + Level;
    }
    public static void DeathCount(int Count)
    {
        inGame.GetObjectDeath().GetComponent<Text>().text = "Death Count " + Count;
    }
    public static void SetCanvas()
    {
        GameObject.DontDestroyOnLoad(UIRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));
    }



}
