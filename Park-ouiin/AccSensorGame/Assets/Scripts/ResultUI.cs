using UnityEngine;
using UnityEngine.UI;

public class ResultUI
{
    GameObject restartbtn;
    GameObject quitbtn;
    GameObject gameObject;

    public void Init()
    {
        restartbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Restartbtn, UIRoot.resultCanvas);
        quitbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Quitbtn, UIRoot.resultCanvas);
        gameObject = Utility.Object.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Object.Invisible(gameObject);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
