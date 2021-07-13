using UnityEngine;

public class UIManager
{
    // 현재 UI 상태 변수
    public enum State { TITLE, MAINGAME, RESULT };

    State state = State.TITLE;

    TitleUI titleUI = new TitleUI();
    MaingameUI maingameUI = new MaingameUI();
    ResultUI resultUI = new ResultUI();

    // 모든 UI 생성
    public void UISetting(int maxLife)
    {
        titleUI.Init();
        maingameUI.Init(maxLife);
        resultUI.Init();
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
