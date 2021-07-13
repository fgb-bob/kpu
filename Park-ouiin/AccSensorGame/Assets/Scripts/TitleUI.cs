using UnityEngine;
using UnityEngine.UI;

public class TitleUI
{
    GameObject titleImage;
    GameObject gameObject;
    GameObject startbtn;

    // Ÿ��Ʋ UI �ʱ�ȭ
    public void Init()
    {
        titleImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.titleCanvas);
        startbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Startbtn, UIRoot.titleCanvas);
        startbtn.GetComponent<Button>().onClick.AddListener(() => StartbtnClick());
    }

    // ���� ��ư �Լ�
    void StartbtnClick()
    {        
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Invisible(gameObject);      
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "MaingameCanvas");
        Utility.Visible(gameObject);
    }
}