using UnityEngine;
using UnityEngine.UI;

public class NUIManager : NIButtonMaker
{
    NTitleUI nTitleUI = new NTitleUI();
    public NMaingameUI nMaingameUI = new NMaingameUI();
    NResultUI nResultUI = new NResultUI();
    public GameObject titleUI, maingameUI, resultUI;
    GameObject maingameImage;
    public int state; // 0 - title  1 - 메인 2 - 재시작 초기화

    public void MakeTitleUI()
    {
        Debug.Log("타이틀 UI 생성");
        nTitleUI.MakeTitle();
        titleUI = GameObject.Find("TitleCanvas");
        nTitleUI.startbtn.GetComponent<Button>().onClick.AddListener(() => OnClick(0));
    }

    public void MakeMaingameUI(int life, int maxLife)
    {
        Debug.Log("메인게임 UI 생성");
        nMaingameUI.MakeMaingame(life, maxLife);

        maingameUI = GameObject.Find("MaingameCanvas");
        if(maingameUI)
            Debug.Log("MaingameCanvas 찾았어~");
        else
            Debug.Log("MaingameCanvas 없어~");

        maingameImage = GameObject.Find("Maingame(Clone)");
        if (maingameUI)
            Debug.Log("Maingame(Clone) 찾았어~");
        else
            Debug.Log("Maingame(Clone) 없어~");

        Invisible(maingameUI);
        Invisible(maingameImage);
    }

    public void MakeResultUI()
    {
        Debug.Log("결과창 UI 생성");
        nResultUI.MakeResult();
        resultUI = GameObject.Find("ResultCanvas");
        nResultUI.restartbtn.GetComponent<Button>().onClick.AddListener(() => OnClick(1));
        nResultUI.quitbtn.GetComponent<Button>().onClick.AddListener(() => OnClick(2));
        Invisible(resultUI);
    }

    public void Invisible(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " 안보이게!");
        gameObject.SetActive(false);
    }

    public void Visible(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " 보이게!");
        gameObject.SetActive(true);
    }

    public void OnClick(int func)
    {
        switch (func)
        {
            case 0: // 시작 버튼
                Debug.Log("시작버튼 눌렀어!");
                Invisible(titleUI);
                Visible(maingameUI);
                Visible(maingameImage);
                state = 1;
                Debug.Log("게임 시작!");
                break;
            case 1: // 재시작 버튼
                GameResume();                
                Invisible(resultUI);
                state = 2;
                break;
            case 2: // 종료 버튼
                Application.Quit();
                break;
        }
    }

    public void GamePause()
    {
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void GameResume()
    {
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
