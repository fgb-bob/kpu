using UnityEngine;
using UnityEngine.UI;

public class TitleUI : IButtonMaker
{
    public static GameObject TitleImage;
    public static GameObject startbtn;

    public static void MakeTitle()
    {
        TitleImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.titleCanvas);
        startbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Startbtn, UIRoot.titleCanvas);
        TitleUI temp = new TitleUI();
        startbtn.GetComponent<Button>().onClick.AddListener(() => temp.OnClick(0));
    }

    public void OnClick(int num)
    {
        UIManager.Invisible(GameManager.titleUI);        
        CharacterManager.Init();
        UIManager.Visible(GameManager.maingameUI);
        GameManager.state = 1;
        ObstacleManager.Init();
    }
}
