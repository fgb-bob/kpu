
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : IButton
{
    // UIManager���� play, resume, quit BTN �����ϰ� -> ��ư ������ Launcher�� �Լ��� ȣ���ؾ� ��
    // PlayerController���� right, left BTN �����ϰ� �ʹ�. -> ��ư ������ PlayerController�� move�� ȣ���ؾ���.
    // Share.Util���� static���� Button, Click�Լ� �����ϰ� ����ϸ�?
    // Scriptable Object�� ���ʹ�, �÷��̾� ���� �������ִ� ��? 

    Button rightButton;
    Button leftButton;
    Button playButton;
    Button resumeButton;
    GameObject[] quitButton;
    Button nextButton;
    GameObject player;
    PlayerController pc;
    SceneManager sceneManager;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
        pc = new PlayerController();

        rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        leftButton = GameObject.Find("LeftButton").GetComponent<Button>();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        quitButton = new GameObject[3];
        quitButton = GameObject.FindGameObjectsWithTag("QuitButton");

        for (int i = 0; i < quitButton.Length; ++i)
        {
            quitButton[i].GetComponent<Button>().onClick.AddListener(() => OnClick(IButton.BTN.quitBTN));
        }

        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        nextButton = GameObject.Find("NextStageButton").GetComponent<Button>();

        rightButton.onClick.AddListener(() => OnClickRightButton());
        leftButton.onClick.AddListener(() => OnClickLeftButton());
        playButton.onClick.AddListener(() => OnClick(IButton.BTN.playBTN));

        resumeButton.onClick.AddListener(() => OnClick(IButton.BTN.resumeBTN));
        nextButton.onClick.AddListener(() => OnClick(IButton.BTN.resumeBTN));
    }

    public void OnClick(IButton.BTN btn)
    {
        switch (btn)
        {
            case IButton.BTN.playBTN:
                Debug.Log("Play��ư ������!");
                sceneManager.PlayGame();
                break;
            case IButton.BTN.quitBTN:
                sceneManager.QuitGame();
                break;
            case IButton.BTN.resumeBTN:
                sceneManager.ResumeGame();
                break;
        }
    }

    private void OnClickRightButton()
    {
        if (player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            player.GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("������!");
            player.transform.localScale = new Vector2(1, 1);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0), ForceMode2D.Impulse);
        }
    }

    private void OnClickLeftButton()
    {
        if (player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            player.GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("����!");
            player.transform.localScale = new Vector2(-1, 1);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0), ForceMode2D.Impulse);
        }
    }

    public void setSceneManager(SceneManager sceneManager)
    {
        this.sceneManager = sceneManager;
    }
}
