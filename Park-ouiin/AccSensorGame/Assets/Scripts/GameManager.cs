using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject uiRoot;

    UIManager uiManager;
    PlayerManager playerManager;
    LifeManager lifeManager;
    ObstacleManager obstacleManager;
    JudgeManager judgeManager;

    PlayerData playerData;

    private void Awake()
    {
        Utility.NoSleepMode(); 

        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

        playerData = Resources.Load("ScriptableObject/Player Data") as PlayerData;

        playerManager = new PlayerManager();
        lifeManager = new LifeManager();
        lifeManager.Init(playerData.life, playerData.maxLife);
        uiManager = new UIManager();        
        obstacleManager = new ObstacleManager();
        uiManager.UISetting(playerManager, playerData, obstacleManager, lifeManager);
        judgeManager = new JudgeManager();
        judgeManager.Init(obstacleManager, lifeManager, uiManager);
    }

    void FixedUpdate()
    {
        switch (uiManager.GetState())
        {
            case UIManager.State.MAINGAME:
                playerManager.PlayerMoveUpdate();
                uiManager.SetScore();

                // playerData.monsterDelay마다 장애물 1개 추가 생성
                if (((int)uiManager.GetScore() / playerData.monsterDelay) == obstacleManager.GetObstacleNum())
                    obstacleManager.Generate(obstacleManager.GetObstacleNum());      
                
                obstacleManager.Moving();
                // 장애물과 플레이어 충돌 판단
                judgeManager.judging(playerManager.GetGameObjectPlayer());

                if (lifeManager.GetLife() <= 0)
                {                    
                    obstacleManager.DestroyObject();
                    Utility.Visible(uiManager.GetGameObjectResultUI());
                    Utility.Pause();
                    uiManager.SetState(UIManager.State.RESULT);
                }
                break;
            default:
                break;
        }
    }
}
