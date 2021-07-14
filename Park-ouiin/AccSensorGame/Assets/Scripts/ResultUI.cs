using UnityEngine;
using UnityEngine.UI;

public class ResultUI
{
    GameObject restartbtn;
    GameObject quitbtn;
    GameObject gameObject;

    // ���â UI �ʱ�ȭ
    public void Init()
    {
        restartbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Restartbtn, UIRoot.resultCanvas);
        quitbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Quitbtn, UIRoot.resultCanvas);
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick());
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());

        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Invisible(gameObject);
    }

    // ����� ��ư �Լ�
    void RestartbtnClick()
    {
        Utility.Resume();
        Utility.Invisible(gameObject);
    }

    // ���� ��ư �Լ�
    void QuitbtnClick()
    {
        Application.Quit();
    }

    // ResultCanvas�� ��� ���� ������Ʈ ��ȯ
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public GameObject GetRestartbtn()
    {
        return restartbtn;
    }
}
