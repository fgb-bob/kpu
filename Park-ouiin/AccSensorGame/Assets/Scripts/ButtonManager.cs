using UnityEngine;
using UnityEngine.UI;

public class ButtonManager
{
    GameObject dodgeStartbtn, upStartbtn, restartbtn, quitbtn;
    GameObject gameObject;
    public void Init(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        upStartbtn = Utility.FindInvisibleGameobjectWithName(upStartbtn, "UIRoot(Clone)", "TitleCanvas");
        upStartbtn = upStartbtn.transform.Find("UpStartbtn(Clone)").gameObject;
        upStartbtn.GetComponent<Button>().onClick.AddListener(() => UpStartbtnClick(playerData, playerManager, uIManager));

        dodgeStartbtn = Utility.FindInvisibleGameobjectWithName(dodgeStartbtn, "UIRoot(Clone)", "TitleCanvas");
        dodgeStartbtn = dodgeStartbtn.transform.Find("DodgeStartbtn(Clone)").gameObject;
        dodgeStartbtn.GetComponent<Button>().onClick.AddListener(() => DodgeStartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        restartbtn = Utility.FindInvisibleGameobjectWithName(restartbtn, "UIRoot(Clone)", "ResultCanvas");
        restartbtn = restartbtn.transform.Find("Restartbtn(Clone)").gameObject;
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        quitbtn = Utility.FindInvisibleGameobjectWithName(quitbtn, "UIRoot(Clone)", "ResultCanvas");
        quitbtn = quitbtn.transform.Find("Quitbtn(Clone)").gameObject;
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());
    }

    void DodgeStartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Invisible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Visible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Visible(gameObject);        
        playerManager.Init(playerData.speed);
        playerManager.GetPlayer().GetPlayerController().SetGameType(PlayerController.GameType.DODGE);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum());
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        uIManager.SetState(UIManager.State.DODGEMAINGAME);
    }

    void UpStartbtnClick(PlayerData playerData, PlayerManager playerManager, UIManager uIManager)
    {
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Invisible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Visible(gameObject);
        uIManager.SetHeartActive(0, 10);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Visible(gameObject);
        playerManager.Init(playerData.speed);
        playerManager.GetPlayer().GetPlayerController().SetGameType(PlayerController.GameType.UP);
        uIManager.SetState(UIManager.State.UPMAINGAME);        
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "Main Camera");        
        gameObject.GetComponent<Transform>().SetParent(Utility.FindVisibleGameobjectWithName(gameObject, "Character(Clone)").transform);
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
        uIManager.SetState(UIManager.State.DODGEMAINGAME);
    }

    void QuitbtnClick()
    {
        Application.Quit();
    }
}
