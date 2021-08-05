using UnityEngine;
using UnityEngine.UI;

public class TitleUI
{
    GameObject titleImage;
    GameObject gameObject;
    GameObject dodgeStartbtn, upStartbtn;

    public void Init()
    {
        titleImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.titleCanvas);
        dodgeStartbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.DodgeStartbtn, UIRoot.titleCanvas);
        upStartbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.UpStartbtn, UIRoot.titleCanvas);
    }
}