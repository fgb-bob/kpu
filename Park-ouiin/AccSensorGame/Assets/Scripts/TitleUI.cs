using UnityEngine;

public class TitleUI : IButtonMaker
{
    public static GameObject TitleImage;
    public static GameObject startbtn;

    public static void MakeTitle()
    {
        TitleImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.titleCanvas);
        startbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Startbtn, UIRoot.titleCanvas);                
    }

    public static void Invisible()
    {
        GameObject temp = GameObject.Find("titleCanvas");
        temp.SetActive(false);
    }

    public static void visible()
    {
        GameObject temp = GameObject.Find("titleCanvas");
        temp.SetActive(true);
    }

    public void OnClick()
    {
        Invisible();
        MaingameUI.MakeMaingame();
    }
}
