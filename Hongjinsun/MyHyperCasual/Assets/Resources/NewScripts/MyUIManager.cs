using UnityEngine;
using UnityEngine.UI;

public class MyUIManager 
{
    public GameObject uiRoot;
    public GameObject titleUI;
    public GameObject deadUI;
    public GameObject clearUI;
    public GameObject background;
    public GameObject map;
    public GameObject buttonUI;
    Text m_scoreText;
    MyButtonManager m_myButtonManager;
    MyEnermyGenerator m_myEnermyGenerator;
    public bool isStart;

    public void Init(MyPlayerController playerController, MyEnermyGenerator m_myEnermyGenerator)
    {
        uiRoot = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Root, UIRoot.canvas);
        background = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Background, GameObject.Find("Main Camera").transform);
        map = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Map, null);
        buttonUI = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Button, UIRoot.canvas);
        titleUI = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Title, UIRoot.canvas);
        deadUI = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Dead, UIRoot.canvas);
        clearUI = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Clear, UIRoot.canvas);

        m_scoreText = GameObject.Find("Score").GetComponent<Text>();

        m_myButtonManager = new MyButtonManager();
        m_myButtonManager.Init(playerController, this);

        this.m_myEnermyGenerator = m_myEnermyGenerator;
        //this.m_myEnermyController = m_myEnermyController;
    }

    public void PlayGame()
    {
        m_myEnermyGenerator.enermyGen = true;
        titleUI.SetActive(false);
        deadUI.SetActive(false);
        clearUI.SetActive(false);
    }

    public void ResumeGame()
    {
        Debug.Log("Resume버튼클릭!");
        m_myEnermyGenerator.enermyGen = true;
        titleUI.SetActive(false);
        deadUI.SetActive(false);
        clearUI.SetActive(false);
        isStart = true;
        
    }

    public void QuitGame()
    {

    }

    public void SetScoreText(int score)
    {
        m_scoreText.text = "Score : " + score;
    }

    public Text GetScoreText()
    {
        return m_scoreText;
    }
}
