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

    public static void MakeResultUI()
    {
        ResultUI.MakeResult();
    }

    public static void Invisible(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public static void Visible(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
