using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager
{
    static GameObject uiRoot;
    public GameObject Button;
    private static TitleUI title = new TitleUI();
    private static InGameUI inGame = new InGameUI();
    private GameoverUI gameover = new GameoverUI();

    public static void LevelUI_init()
    {
        inGame.init();

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

    public static void TitleUI_init()
    {
        title.init();
    }

    public static void SetButton(string Name)
    {

    }

    public static void InstantiatUI(GameObject Obj)
    {

    }
}
