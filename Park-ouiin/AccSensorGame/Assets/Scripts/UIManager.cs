using UnityEngine;

public class UIManager
{
    public static void MakeTitleUI()
    {
        TitleUI.MakeTitle();
    }

    public static void MakeMaingameUI()
    {
        MaingameUI.MakeMaingame();
    }

    public static void Invisible(string canvasname)
    {
        GameObject gameObject = GameObject.Find(canvasname);
        gameObject.SetActive(false);
    }

    public static void Visible(string canvasname)
    {
        GameObject gameObject = GameObject.Find(canvasname);
        gameObject.SetActive(true);
    }
}
