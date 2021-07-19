using UnityEngine;
using UnityEngine.UI;

public class MyUIButton
{
    Button m_playButton;
    Button m_resumeButton;
    GameObject[] m_quitButton;
    Button m_nextButton;

    public void Init(MyUIManager uiManager)
    {
        m_playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        m_quitButton = new GameObject[3];
        m_quitButton = GameObject.FindGameObjectsWithTag("QuitButton");
        m_resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        m_nextButton = GameObject.Find("NextStageButton").GetComponent<Button>();

        m_playButton.onClick.AddListener(() => uiManager.PlayGame());

        for (int i = 0; i < m_quitButton.Length; ++i)
        {
            m_quitButton[i].GetComponent<Button>().onClick.AddListener(() => uiManager.QuitGame());
        }

        m_resumeButton.onClick.AddListener(() => uiManager.ResumeGame());
        m_nextButton.onClick.AddListener(() => uiManager.ResumeGame());
    }
}
