using UnityEngine;

public class NUIManager
{
    public enum State { TITLE, MAINGAME, RESULT };

    State state = State.TITLE;

    NTitleUI nTitleUI = new NTitleUI();
    NMaingameUI nMaingameUI = new NMaingameUI();
    NResultUI nResultUI = new NResultUI();

    public void UISetting()
    {
        nTitleUI.Init();
        nMaingameUI.Init(3,3);
        nResultUI.Init();
    }

    public NMaingameUI GetNMaingameUI()
    {
        return nMaingameUI;
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
