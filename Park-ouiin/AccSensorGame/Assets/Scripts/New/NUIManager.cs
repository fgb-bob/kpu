using UnityEngine;
using UnityEngine.UI;

public class NUIManager : NIButtonMaker
{
    NTitleUI nTitleUI = new NTitleUI();
    public NMaingameUI nMaingameUI = new NMaingameUI();
    NResultUI nResultUI = new NResultUI();
    public GameObject titleUI, maingameUI, resultUI;
    GameObject maingameImage;
    public int state; // 0 - title  1 - ���� 2 - ����� �ʱ�ȭ

    public void MakeTitleUI()
    {
        Debug.Log("Ÿ��Ʋ UI ����");
        nTitleUI.MakeTitle();
        titleUI = GameObject.Find("TitleCanvas");
        nTitleUI.startbtn.GetComponent<Button>().onClick.AddListener(() => OnClick(0));
    }

    public void MakeMaingameUI(int life, int maxLife)
    {
        Debug.Log("���ΰ��� UI ����");
        nMaingameUI.MakeMaingame(life, maxLife);

        maingameUI = GameObject.Find("MaingameCanvas");
        if(maingameUI)
            Debug.Log("MaingameCanvas ã�Ҿ�~");
        else
            Debug.Log("MaingameCanvas ����~");

        maingameImage = GameObject.Find("Maingame(Clone)");
        if (maingameUI)
            Debug.Log("Maingame(Clone) ã�Ҿ�~");
        else
            Debug.Log("Maingame(Clone) ����~");

        Invisible(maingameUI);
        Invisible(maingameImage);
    }

    public void MakeResultUI()
    {
        Debug.Log("���â UI ����");
        nResultUI.MakeResult();
        resultUI = GameObject.Find("ResultCanvas");
        nResultUI.restartbtn.GetComponent<Button>().onClick.AddListener(() => OnClick(1));
        nResultUI.quitbtn.GetComponent<Button>().onClick.AddListener(() => OnClick(2));
        Invisible(resultUI);
    }

    public void Invisible(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " �Ⱥ��̰�!");
        gameObject.SetActive(false);
    }

    public void Visible(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " ���̰�!");
        gameObject.SetActive(true);
    }

    public void OnClick(int func)
    {
        switch (func)
        {
            case 0: // ���� ��ư
                Debug.Log("���۹�ư ������!");
                Invisible(titleUI);
                Visible(maingameUI);
                Visible(maingameImage);
                state = 1;
                Debug.Log("���� ����!");
                break;
            case 1: // ����� ��ư
                GameResume();                
                Invisible(resultUI);
                state = 2;
                break;
            case 2: // ���� ��ư
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
