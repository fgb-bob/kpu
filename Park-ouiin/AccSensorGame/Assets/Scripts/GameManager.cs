using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject emptyObject;
    GameObject uiRoot;    

    UIManager uiManager;
    PlayerManager playerManager;
    LifeManager lifeManager;
    ObstacleManager obstacleManager;

    PlayerData playerData;

    private void Awake()
    {
        // ȭ�� �Ȳ����� ����
        Utility.NoSleepMode(); 

        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

        // ������ �ҷ�����
        playerData = Resources.Load("ScriptableObject/Player Data") as PlayerData;

        // ��� �Ŵ��� ����
        playerManager = new PlayerManager();
        lifeManager = new LifeManager();
        lifeManager.Init(playerData.life, playerData.maxLife);
        uiManager = new UIManager();
        uiManager.UISetting(lifeManager.GetMaxLife());
        obstacleManager = new ObstacleManager();
    }

    void FixedUpdate()
    {
        switch (uiManager.GetState())
        {
            case UIManager.State.TITLE: // Ÿ��Ʋ ȭ��
                // ����ĵ������ Ȱ��ȭ �Ǿ����� ��
                if (Utility.FindVisibleGameobjectWithName(emptyObject, "MaingameCanvas") != null)
                {                    
                    // �÷��̾� ����
                    playerManager.Init(playerData.speed);
                    // ��ֹ� ����
                    obstacleManager.Init();
                    obstacleManager.Generate(obstacleManager.GetObstacleNum());
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                    // ���� ����
                    uiManager.SetState(UIManager.State.MAINGAME);
                }
                break;
            case UIManager.State.MAINGAME: // ���� ���� �÷��� ȭ��
                // �÷��̾� �̵�
                playerManager.GetPlayer().GetPlayerController().Move();
                // ���� ����
                uiManager.GetMaingameUI().SetScoreText();                
                // 10�� ���������� ��ֹ� 1�� �߰� ����
                if (((int)uiManager.GetMaingameUI().GetScore() / playerData.monsterDelay) == obstacleManager.GetObstacleNum())
                    obstacleManager.Generate(obstacleManager.GetObstacleNum());
                // ��ֹ� �̵�
                obstacleManager.Moving(obstacleManager.GetObstacleNum(), playerManager.GetPlayer().GetPlayerGameObject(), lifeManager, uiManager);
                // �÷��̾� ü�� 0�� ���
                if (lifeManager.GetLife() <= 0)
                {                    
                    // ������ ��ֹ� �ı�
                    obstacleManager.DestroyObject();
                    // ���â ����
                    Utility.Visible(uiManager.GetResultUI().GetGameObject());
                    // ���� ���߱�
                    Utility.Pause();
                    // ���� ����
                    uiManager.SetState(UIManager.State.RESULT);
                }
                break;
            case UIManager.State.RESULT: // ���â ȭ��
                // ���âĵ������ ��Ȱ��ȭ �Ǿ����� ���
                if (Utility.FindVisibleGameobjectWithName(emptyObject, "ResultCanvas") == null)
                {                    
                    // �÷��̾� �ʱ�ȭ
                    playerManager.Reset();
                    // ��ֹ� �ʱ�ȭ �� �����
                    obstacleManager.ResetObstacleNum();
                    obstacleManager.Generate(obstacleManager.GetObstacleNum());
                    // �÷��̾� ü�� �ʱ�ȭ
                    lifeManager.ResetLife(playerData.life);
                    // UI �ʱ�ȭ
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                    uiManager.GetMaingameUI().ResetScore();
                    // ���� ����
                    uiManager.SetState(UIManager.State.MAINGAME);
                }
                break;                
        }
    }
}
