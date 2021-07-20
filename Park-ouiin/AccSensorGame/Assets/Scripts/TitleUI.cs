using UnityEngine;
using UnityEngine.UI;

public class TitleUI
{
    GameObject titleImage;
    GameObject gameObject;
    GameObject startbtn;

    public void Init()
    {
        titleImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.titleCanvas);
        startbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Startbtn, UIRoot.titleCanvas);
    }
}