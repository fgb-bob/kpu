using UnityEngine;

public class UIManager
{
    // ���� UI ���� ����
    public enum State { TITLE, MAINGAME, RESULT };

    State state = State.TITLE;

    TitleUI titleUI = new TitleUI();
    MaingameUI maingameUI = new MaingameUI();
    ResultUI resultUI = new ResultUI();

    // ��� UI ����
    public void UISetting(int maxLife)
    {
        titleUI.Init();
        maingameUI.Init(maxLife);
        resultUI.Init();
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
