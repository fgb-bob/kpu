using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    // 현재 UI 상태 변수
    public enum State { TITLE, MAINGAME, RESULT };

    State state = State.TITLE;

    TitleUI titleUI = new TitleUI();
    MaingameUI maingameUI = new MaingameUI();
    ResultUI resultUI = new ResultUI();

    // 모든 UI 생성
    public void UISetting(PlayerManager playerManager, PlayerData playerData, ObstacleManager obstacleManager, LifeManager lifeManager)
    {
        titleUI.Init();
        titleUI.GetStartbtn().GetComponent<Button>().onClick.AddListener(() => Startbtn(playerManager, playerData, obstacleManager, lifeManager));
        maingameUI.Init(lifeManager.GetMaxLife());
        resultUI.Init();
        resultUI.GetRestartbtn().GetComponent<Button>().onClick.AddListener(() => Restartbtn(playerManager, playerData, obstacleManager, lifeManager));
    }

    void Restartbtn(PlayerManager playerManager, PlayerData playerData, ObstacleManager obstacleManager, LifeManager lifeManager)
    {
        // 플레이어 초기화
        playerManager.Reset();
        // 장애물 초기화 및 재생성
        obstacleManager.ResetObstacleNum();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        // 플레이어 체력 초기화
        lifeManager.ResetLife(playerData.life);
        // UI 초기화
        GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        GetMaingameUI().ResetScore();
        // 상태 변경
        SetState(UIManager.State.MAINGAME);
    }

    void Startbtn(PlayerManager playerManager, PlayerData playerData, ObstacleManager obstacleManager, LifeManager lifeManager)
    {
        // 플레이어 생성
        playerManager.Init(playerData.speed);
        // 장애물 생성
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        // 상태 변경
        SetState(UIManager.State.MAINGAME);
    }

    // 메인 UI 반환 함수
    public MaingameUI GetMaingameUI()
    {
        return maingameUI;
    }

    // 결과창 UI 반환 함수
    public ResultUI GetResultUI()
    {
        return resultUI;
    }

    // UI 상태 표시 변수 반환
    public State GetState()
    {
        return state;
    }

    // UI 상태 표시 변수 변경
    public void SetState(State state)
    {
        this.state = state;
    }
}
