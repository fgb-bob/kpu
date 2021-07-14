using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    // ���� UI ���� ����
    public enum State { TITLE, MAINGAME, RESULT };

    State state = State.TITLE;

    TitleUI titleUI = new TitleUI();
    MaingameUI maingameUI = new MaingameUI();
    ResultUI resultUI = new ResultUI();

    // ��� UI ����
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
        // �÷��̾� �ʱ�ȭ
        playerManager.Reset();
        // ��ֹ� �ʱ�ȭ �� �����
        obstacleManager.ResetObstacleNum();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        // �÷��̾� ü�� �ʱ�ȭ
        lifeManager.ResetLife(playerData.life);
        // UI �ʱ�ȭ
        GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        GetMaingameUI().ResetScore();
        // ���� ����
        SetState(UIManager.State.MAINGAME);
    }

    void Startbtn(PlayerManager playerManager, PlayerData playerData, ObstacleManager obstacleManager, LifeManager lifeManager)
    {
        // �÷��̾� ����
        playerManager.Init(playerData.speed);
        // ��ֹ� ����
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        // ���� ����
        SetState(UIManager.State.MAINGAME);
    }

    // ���� UI ��ȯ �Լ�
    public MaingameUI GetMaingameUI()
    {
        return maingameUI;
    }

    // ���â UI ��ȯ �Լ�
    public ResultUI GetResultUI()
    {
        return resultUI;
    }

    // UI ���� ǥ�� ���� ��ȯ
    public State GetState()
    {
        return state;
    }

    // UI ���� ǥ�� ���� ����
    public void SetState(State state)
    {
        this.state = state;
    }
}
