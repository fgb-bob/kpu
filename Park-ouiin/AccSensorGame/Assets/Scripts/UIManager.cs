using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    public enum State { TITLE, MAINGAME, RESULT };

    State state = State.TITLE;

    TitleUI titleUI = new TitleUI();
    MaingameUI maingameUI = new MaingameUI();
    ResultUI resultUI = new ResultUI();

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
        playerManager.Reset();
        obstacleManager.ResetObstacleNum();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        lifeManager.ResetLife(playerData.life);
        GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        GetMaingameUI().ResetScore();
        SetState(UIManager.State.MAINGAME);
    }

    void Startbtn(PlayerManager playerManager, PlayerData playerData, ObstacleManager obstacleManager, LifeManager lifeManager)
    {
        playerManager.Init(playerData.speed);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        SetState(UIManager.State.MAINGAME);
    }

    public MaingameUI GetMaingameUI()
    {
        return maingameUI;
    }

    public ResultUI GetResultUI()
    {
        return resultUI;
    }

    public State GetState()
    {
        return state;
    }

    public void SetState(State state)
    {
        this.state = state;
    }
}
