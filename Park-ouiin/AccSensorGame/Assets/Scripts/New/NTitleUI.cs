using UnityEngine;
using UnityEngine.UI;

public class NTitleUI
{
    GameObject titleimage;
    public GameObject startbtn;

    public void MakeTitle()
    {
        titleimage = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Title, NUIRoot.titleCanvas);
        startbtn = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Startbtn, NUIRoot.titleCanvas);
    }
}