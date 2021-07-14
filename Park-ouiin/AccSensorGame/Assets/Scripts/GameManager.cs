using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        obstacleManager = new ObstacleManager();
        uiManager.UISetting(playerManager, playerData, obstacleManager, lifeManager);
    }

    void FixedUpdate()
    {
        switch (uiManager.GetState())
        {
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
        }
    }
}
