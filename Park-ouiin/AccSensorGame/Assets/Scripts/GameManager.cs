using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject uiRoot;
    GameObject go;
    UIManager uiManager;
    PlayerManager playerManager;
    LifeManager lifeManager;
    ObstacleManager obstacleManager;
    JudgeManager judgeManager;
    ButtonManager buttonManager;

    PlayerData playerData;

    private void Awake()
    {
        Utility.Mode.NoSleepMode();

        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

        playerData = Resources.Load("ScriptableObject/Player Data") as PlayerData;

        buttonManager = new ButtonManager();
        playerManager = new PlayerManager();
        lifeManager = new LifeManager();
        lifeManager.Init(playerData.life, playerData.maxLife);
        uiManager = new UIManager();
        obstacleManager = new ObstacleManager();
        uiManager.UISetting(lifeManager);
        judgeManager = new JudgeManager();
        judgeManager.Init(obstacleManager, lifeManager, uiManager);
        buttonManager.Init(playerData, playerManager, obstacleManager, lifeManager, uiManager);
    }

    void FixedUpdate()
    {
        switch (uiManager.GetState())
        {
            case UIManager.State.DODGEMAINGAME:
                GameUpdate();
                // playerData.monsterDelay마다 장애물 1개 추가 생성
                MakeObstacle(playerData.monsterDelay);
                // 장애물과 플레이어 충돌 판단
                judgeManager.judging(playerManager.GetGameObjectPlayer());
                if (lifeManager.GetLife() <= 0)
                    GameEnd();
                break;
            case UIManager.State.UPMAINGAME:
                GameUpdate();
                MakeObstacle(playerData.monsterDelay);
                go = GameObject.FindGameObjectWithTag("Scaffolding");
                if (playerManager.GetGameObjectPlayer().GetComponent<Transform>().position.y < go.GetComponent<Transform>().position.y
                    && playerManager.GetPlayer().GetPlayerController().GetLifetime() < 0)
                    GameEnd();
                break;
            default:
                //throw new System.NotImplementedException();
                break;
        }
    }

    void GameEnd()
    {
        obstacleManager.DestroyObject();
        Utility.Object.Visible(uiManager.GetGameObjectResultUI());
        Utility.Mode.Pause();
        uiManager.SetState(UIManager.State.RESULT);
    }

    void MakeObstacle(int delay)
    {
        if (((int)uiManager.GetScore() / delay) == obstacleManager.GetObstacleNum())
            obstacleManager.Generate(obstacleManager.GetObstacleNum(), uiManager);
        obstacleManager.Moving(uiManager);
    }

    void GameUpdate()
    {
        playerManager.PlayerMoveUpdate();
        uiManager.SetScore();
    }
}
