using UnityEngine;

public class MySceneManager
{
    MyUIManager m_UIManager;
    MyPlayerController m_playerController;
    MyEnermyGenerator m_enermyGenerator;
    MyColliderManager m_colliderManager;

    public void Init()
    {
        m_playerController = new MyPlayerController();
        m_playerController.Init();

        m_enermyGenerator = new MyEnermyGenerator();
        m_enermyGenerator.Init();

        m_UIManager = new MyUIManager();
        m_UIManager.Init(m_playerController, m_enermyGenerator);

        m_colliderManager = new MyColliderManager();
        m_colliderManager.Init(m_playerController);

        m_UIManager.clearUI.SetActive(false);
        m_UIManager.deadUI.SetActive(false);
    }

    public void Update()
    {
        if (m_UIManager.isStart == true)
        {
            Debug.Log("�����!");
            PlayGame();
            m_UIManager.isStart = false;
        }

        if (m_colliderManager.isDead == true)
        {
            Debug.Log("��! ���� �׾��߾�!");
            m_UIManager.deadUI.SetActive(true);
            Time.timeScale = 0;
            m_colliderManager.isDead = false;
        }

        if (m_playerController.GetScore() == m_enermyGenerator.GetMaxEnermy())
        {
            Debug.Log("��� �� ó��!!");
            Time.timeScale = 0;
            m_UIManager.clearUI.SetActive(true);
        }


        m_playerController.Update();
        m_enermyGenerator.SpawnEnermy();
        m_colliderManager.Update();
        m_UIManager.SetScoreText(m_playerController.GetScore());
    }

    public void PlayGame()
    {
        m_playerController.player.ResetData();
        m_enermyGenerator.ResetData();
        m_colliderManager.ResetData();
        m_playerController.SetScore(0);

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
