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
                playerManager.GetPlayer().GetPlayerController().Move();
                uiManager.GetMaingameUI().SetScoreText();      
                
                // 10�� ���������� ��ֹ� 1�� �߰� ����
                if (((int)uiManager.GetMaingameUI().GetScore() / playerData.monsterDelay) == obstacleManager.GetObstacleNum())
                    obstacleManager.Generate(obstacleManager.GetObstacleNum());      
                
                obstacleManager.Moving();
                // ��ֹ��� �÷��̾� �浹 �Ǵ�
                judgeManager.judging(playerManager.GetPlayer().GetPlayerGameObject());

                if (lifeManager.GetLife() <= 0)
                {                    
                    obstacleManager.DestroyObject();
                    Utility.Visible(uiManager.GetResultUI().GetGameObject());
                    Utility.Pause();
                    uiManager.SetState(UIManager.State.RESULT);
                }
                break;
            default:
                break;
        }
    }
}
