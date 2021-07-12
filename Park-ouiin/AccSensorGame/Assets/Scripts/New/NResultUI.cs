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
        Debug.Log("����۹�ư ������!");
        NUtility.Resume();
        NUtility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        NUtility.Invisible(gameObject);
        Debug.Log("�����!");
    }

    void QuitbtnClick()
    {
        Application.Quit();
    }
}
