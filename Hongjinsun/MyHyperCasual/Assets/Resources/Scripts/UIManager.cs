using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    public GameObject uiRoot;
    public GameObject titleUI;
    public GameObject deadUI;
    public GameObject clearUI;
    Text scoreText;

    public void Init()
    {
        uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, UIRoot.canvas);
        titleUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.canvas);
        deadUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.Dead, UIRoot.canvas);
        clearUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.Clear, UIRoot.canvas);

        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    public void PlayGame()
    {
        titleUI.SetActive(false);
    }

    public void ResumeGame()
    {
        deadUI.SetActive(false);
        clearUI.SetActive(false);
    }

    public void setScoreText(int score)
    {
        scoreText.text = "Score : " + score;
    }

    public Text getScoreText()
    {
        return scoreText;
    }
}

