using UnityEngine;
using UnityEngine.UI;

public class NTitleUI
{
    GameObject titleImage;
    GameObject gameObject;
    GameObject startbtn;

    public void Init()
    {
        titleImage = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Title, NUIRoot.titleCanvas);
        startbtn = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Startbtn, NUIRoot.titleCanvas);
        startbtn.GetComponent<Button>().onClick.AddListener(() => StartbtnClick());
    }

    void StartbtnClick()
    {
        Debug.Log("���۹�ư ������!");
        
        gameObject = NUtility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        NUtility.Invisible(gameObject);
        Debug.Log(gameObject);
        gameObject = NUtility.FindInvisibleGameobjectWithName(gameObject, "MaingameCanvas");
        Debug.Log(gameObject);
        NUtility.Visible(gameObject);

        Debug.Log("���� ����!");
    }
}