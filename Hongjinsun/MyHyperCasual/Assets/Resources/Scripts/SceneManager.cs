using UnityEngine;

public class SceneManager
{
    EnermyGenerator enermyGenerator;
    ButtonManager buttonManager;
    UIManager uiManager;
    BackgroundManager backgroundManager;
    ColliderManager colliderManager;
    PlayerController playerController;
    Player player;
    EnermyController enermyController;

    int state;

    public void Init()
    {
        // Enermy Generator
        enermyGenerator = new EnermyGenerator();
        enermyGenerator.Init();
        enermyController = new EnermyController();
        enermyController.Init();

        // UI Manager
        uiManager = new UIManager();
        uiManager.Init();

        // Background Manager
        backgroundManager = new BackgroundManager();
        backgroundManager.Init();

        // Player Controller
        player = new Player();
        player.Init();
        playerController = new PlayerController();
        playerController.Init(player);

        // Button Manager
        buttonManager = new ButtonManager();
        buttonManager.Init();
        buttonManager.setSceneManager(this);

        // Collider Manager
        colliderManager = new ColliderManager();
        colliderManager.Init(backgroundManager, player);
        playerController.setColliderManager(colliderManager);

        state = 0;

        uiManager.deadUI.SetActive(false);
        uiManager.clearUI.SetActive(false);
    }

    public void sceneUpdate()
    {
        // EnermyGen == true�� ���ʹ� ����
        enermyGenerator.spawnEnermy();
        enermyController.setEnermies(enermyGenerator.getEnermies());
        enermyController.move();
        playerController.move();

        if (enermyGenerator.getEnermies().Count == enermyGenerator.getMaxEnermy())
        {
            enermyController.setSpeedState(false);
        }

        uiManager.setScoreText(player.getScore());

        if (state != 0 && player.getScore() == enermyGenerator.getMaxEnermy())
        {
            Debug.Log("���������� �� ��� óġ!");
            player.getPlayerObj().SetActive(false);
            uiManager.clearUI.SetActive(true);
            for (int i = 0; i < enermyGenerator.getEnermies().Count; ++i)
                GameObject.Destroy(enermyGenerator.getEnermies()[i].getEnermyObj());
            state = 0;
            Time.timeScale = 0;
            //Time.fixedDeltaTime = 0;
        }

        if (!player.getPlayerObj().activeSelf)
        {
            uiManager.deadUI.SetActive(true);
            state = 0;
            Time.timeScale = 0;
        }
    }
    public void PlayGame()
    {
        enermyGenerator.setMaxEnermy();
        enermyGenerator.setEnermyGen(true);
        enermyController.setSpeedState(true);
        uiManager.PlayGame();
        state = 1;
    }

    public void ResumeGame()
    {
        // reset�ϴ� �� PlayGame()�� ��ġ��...
        // static Util Ŭ������ Play, Resume, Quit () �����, 

        state = 1;
        enermyController.setSpeedState(true);
        enermyGenerator.resetData();
        player.resetDate();

        uiManager.ResumeGame();

        GameObject[] temp = GameObject.FindGameObjectsWithTag("enermy");
        for (int i = 0; i < temp.Length; ++i) 
            GameObject.Destroy(temp[i]);

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        Debug.Log("���� �� ����");
    }

    public void QuitGame()
    {
        Debug.Log("���� ����!");
        Application.Quit();
    }
}
