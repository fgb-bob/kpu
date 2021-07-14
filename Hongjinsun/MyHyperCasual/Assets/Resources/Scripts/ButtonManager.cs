
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : IButton
{
    // UIManager에서 play, resume, quit BTN 관리하고 -> 버튼 누르면 Launcher의 함수를 호출해야 해
    // PlayerController에서 right, left BTN 관리하고 싶다. -> 버튼 누르면 PlayerController의 move를 호출해야해.
    // Share.Util에서 static으로 Button, Click함수 선언하고 사용하면?
    // Scriptable Object로 에너미, 플레이어 변수 설정해주는 거? 

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
                Debug.Log("Play버튼 눌렀다!");
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
            Debug.Log("오른쪽!");
            player.transform.localScale = new Vector2(1, 1);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0), ForceMode2D.Impulse);
        }
    }

    private void OnClickLeftButton()
    {
        if (player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            player.GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("왼쪽!");
            player.transform.localScale = new Vector2(-1, 1);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0), ForceMode2D.Impulse);
        }
    }

    public void setSceneManager(SceneManager sceneManager)
    {
        this.sceneManager = sceneManager;
    }
}
