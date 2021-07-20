using UnityEngine;
using UnityEngine.UI;

public class ButtonManager
{
    GameObject startbtn, restartbtn, quitbtn;
    GameObject gameObject;
    public void Init(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        startbtn = Utility.FindInvisibleGameobjectWithName(startbtn, "UIRoot(Clone)", "TitleCanvas");
        startbtn = startbtn.transform.Find("Startbtn(Clone)").gameObject;
        startbtn.GetComponent<Button>().onClick.AddListener(() => StartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        restartbtn = Utility.FindInvisibleGameobjectWithName(restartbtn, "UIRoot(Clone)", "ResultCanvas");
        restartbtn = restartbtn.transform.Find("Restartbtn(Clone)").gameObject;
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        quitbtn = Utility.FindInvisibleGameobjectWithName(quitbtn, "UIRoot(Clone)", "ResultCanvas");
        quitbtn = quitbtn.transform.Find("Quitbtn(Clone)").gameObject;
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());
    }

    void StartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Invisible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Visible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Visible(gameObject);
        playerManager.Init(playerData.speed);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        uIManager.SetState(UIManager.State.MAINGAME);
    }

    void RestartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        Utility.Resume();
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Invisible(gameObject);
        playerManager.Reset();
        obstacleManager.ResetObstacleNum();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        lifeManager.ResetLife(playerData.life);
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        uIManager.GetMaingameUI().ResetScore();
        uIManager.SetState(UIManager.State.MAINGAME);
    }

    void QuitbtnClick()
    {
        Application.Quit();
    }
}
