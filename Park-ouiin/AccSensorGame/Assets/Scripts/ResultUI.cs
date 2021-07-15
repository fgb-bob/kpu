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
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick());
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());

        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Invisible(gameObject);
    }

    void RestartbtnClick()
    {
        Utility.Resume();
        Utility.Invisible(gameObject);
    }

    void QuitbtnClick()
    {
        Application.Quit();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public GameObject GetRestartbtn()
    {
        return restartbtn;
    }
}
