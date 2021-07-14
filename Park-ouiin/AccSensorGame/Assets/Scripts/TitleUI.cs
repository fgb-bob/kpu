using UnityEngine;
using UnityEngine.UI;

public class TitleUI
{
    GameObject titleImage;
    GameObject gameObject;
    GameObject startbtn;

    // 타이틀 UI 초기화
    public void Init()
    {
        titleImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.titleCanvas);
        startbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Startbtn, UIRoot.titleCanvas);
        startbtn.GetComponent<Button>().onClick.AddListener(() => StartbtnClick());
    }

    // 시작 버튼 함수
    void StartbtnClick()
    {        
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Invisible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Visible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Visible(gameObject);
    }

    public GameObject GetStartbtn()
    {
        return startbtn;
    }
}