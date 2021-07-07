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
        startbtn.GetComponent<Button>().onClick.AddListener(temp.OnClick);
    }

    public void OnClick()
    {
        UIManager.Invisible("TitleCanvas");        
        CharacterManager.Init();
        UIManager.MakeMaingameUI();
        GameManager.state = 1;
        ObstacleManager.Init();
    }
}
