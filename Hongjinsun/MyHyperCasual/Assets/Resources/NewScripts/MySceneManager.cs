using UnityEngine;

public class MySceneManager
{
    MyUIManager m_UIManager;
    MyPlayerController m_playerController;
    MyEnermyGenerator m_enermyGenerator;
    MyColliderManager m_colliderManager;
    MyCamera m_camera;
    float m_deltaTime;

    public void Init()
    {
        m_playerController = new MyPlayerController();
        m_playerController.Init();

        m_enermyGenerator = new MyEnermyGenerator();
        m_enermyGenerator.Init();

        m_UIManager = new MyUIManager();
        m_UIManager.Init(m_playerController, m_enermyGenerator);

        m_colliderManager = new MyColliderManager();
        m_colliderManager.Init(m_playerController, m_enermyGenerator);

        m_camera = new MyCamera();
        m_camera.Init();

        m_UIManager.clearUI.SetActive(false);
        m_UIManager.deadUI.SetActive(false);
    }

    public void Update()
    {
        m_camera.Update();
        if (m_UIManager.isStart == true)
        {
            Debug.Log("Àç½ÃÀÛ!");
            PlayGame();
            m_UIManager.isStart = false;
        }

        if (m_colliderManager.isDead == true)
        {
            Debug.Log("¾Ç! ³»°¡ Á×¾ú¶ß¾Æ!");
            m_UIManager.deadUI.SetActive(true);
            Time.timeScale = 0;
            m_colliderManager.isDead = false;
        }

        if (m_playerController.GetScore() == m_enermyGenerator.GetMaxEnermy())
        {
            Debug.Log("¸ðµç Àû Ã³Áö!!");
            Time.timeScale = 0;
            m_UIManager.clearUI.SetActive(true);
        }

        m_deltaTime = Time.deltaTime;

        m_playerController.Update();
        m_enermyGenerator.Update(m_deltaTime);
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
