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
        // 화면 안꺼지게 설정
        Utility.NoSleepMode(); 

        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

        // 데이터 불러오기
        playerData = Resources.Load("ScriptableObject/Player Data") as PlayerData;

        // 모든 매니저 생성
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
            case UIManager.State.MAINGAME: // 메인 게임 플레이 화면
                // 플레이어 이동
                playerManager.GetPlayer().GetPlayerController().Move();
                // 점수 변동
                uiManager.GetMaingameUI().SetScoreText();                
                // 10점 오를때마다 장애물 1개 추가 생성
                if (((int)uiManager.GetMaingameUI().GetScore() / playerData.monsterDelay) == obstacleManager.GetObstacleNum())
                    obstacleManager.Generate(obstacleManager.GetObstacleNum());
                // 장애물 이동               
                obstacleManager.Moving(obstacleManager.GetObstacleNum(), playerManager.GetPlayer().GetPlayerGameObject(), lifeManager, uiManager);
                // 플레이어 체력 0일 경우
                if (lifeManager.GetLife() <= 0)
                {                    
                    // 생성한 장애물 파괴
                    obstacleManager.DestroyObject();
                    // 결과창 띄우기
                    Utility.Visible(uiManager.GetResultUI().GetGameObject());
                    // 게임 멈추기
                    Utility.Pause();
                    // 상태 변경
                    uiManager.SetState(UIManager.State.RESULT);
                }
                break;              
        }
    }
}
