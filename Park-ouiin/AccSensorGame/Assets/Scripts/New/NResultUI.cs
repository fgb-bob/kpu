using UnityEngine;
using UnityEngine.UI;

public class NResultUI
{
    GameObject restartbtn;
    GameObject quitbtn;
    GameObject gameObject;

    public void Init()
    {
        restartbtn = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Restartbtn, NUIRoot.resultCanvas);
        quitbtn = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Quitbtn, NUIRoot.resultCanvas);
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick());
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());

        gameObject = NUtility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        NUtility.Invisible(gameObject);
    }

    void RestartbtnClick()
    {
        Debug.Log("재시작버튼 눌렀어!");
        NUtility.Resume();
        NUtility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        NUtility.Invisible(gameObject);
        Debug.Log("재시작!");
    }

    void QuitbtnClick()
    {
        Application.Quit();
    }
}
