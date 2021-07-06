using UnityEngine;

public class MaingameUI
{
    public static GameObject MaingameImage;   

    public static void MakeMaingame()
    {
        MaingameImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Mainaame, UIRoot.maingameCanvas);
    }

    public static void Invisible()
    {
        GameObject temp = GameObject.Find("maingameCanvas");
        temp.SetActive(false);
    }

    public static void visible()
    {
        GameObject temp = GameObject.Find("maingameCanvas");
        temp.SetActive(true);
    }

}
