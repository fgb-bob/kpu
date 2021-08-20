using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    public enum State { TITLE, DODGEMAINGAME, UPMAINGAME, ELSE };

    State state = State.TITLE;

    TitleUI titleUI = new TitleUI();
    MaingameUI maingameUI = new MaingameUI();
    ResultUI resultUI = new ResultUI();

    public void UISetting(LifeManager lifeManager)
    {
        titleUI.Init();
        maingameUI.Init(lifeManager.GetMaxLife());
        resultUI.Init();
    }

    public GameObject GetGameObjectResultUI()
    {
        return resultUI.GetGameObject();
    }

    public MaingameUI GetMaingameUI()
    {
        return maingameUI;
    }

    public void SetScore()
    {
        maingameUI.SetScoreText(state);
    }

    public float GetScore()
    {
        return maingameUI.GetScore();
    }

    public void SetHeartActive(int life, int maxLife)
    {
        maingameUI.SetHeartActive(life, maxLife);
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
