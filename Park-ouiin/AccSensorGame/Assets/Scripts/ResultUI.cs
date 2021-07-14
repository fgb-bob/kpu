using UnityEngine;
using UnityEngine.UI;

public class ResultUI
{
    GameObject restartbtn;
    GameObject quitbtn;
    GameObject gameObject;

    // 결과창 UI 초기화
    public void Init()
    {
        restartbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Restartbtn, UIRoot.resultCanvas);
        quitbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Quitbtn, UIRoot.resultCanvas);
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick());
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());

        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Invisible(gameObject);
    }

    // 재시작 버튼 함수
    void RestartbtnClick()
    {
        Utility.Resume();
        Utility.Invisible(gameObject);
    }

    // 종료 버튼 함수
    void QuitbtnClick()
    {
        Application.Quit();
    }

    // ResultCanvas가 담긴 게임 오브젝트 반환
    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public GameObject GetRestartbtn()
    {
        return restartbtn;
    }
}
