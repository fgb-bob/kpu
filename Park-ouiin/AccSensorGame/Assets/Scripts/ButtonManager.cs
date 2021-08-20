using UnityEngine;
using UnityEngine.UI;

public class ButtonManager
{
    GameObject dodgeStartbtn, upStartbtn, restartbtn, quitbtn;
    GameObject gameObject;
    public void Init(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        upStartbtn = Utility.Object.FindInvisibleGameobjectWithName(upStartbtn, "UIRoot(Clone)", "TitleCanvas");
        upStartbtn = upStartbtn.transform.Find("UpStartbtn(Clone)").gameObject;
        upStartbtn.GetComponent<Button>().onClick.AddListener(() => UpStartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        dodgeStartbtn = Utility.Object.FindInvisibleGameobjectWithName(dodgeStartbtn, "UIRoot(Clone)", "TitleCanvas");
        dodgeStartbtn = dodgeStartbtn.transform.Find("DodgeStartbtn(Clone)").gameObject;
        dodgeStartbtn.GetComponent<Button>().onClick.AddListener(() => DodgeStartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        restartbtn = Utility.Object.FindInvisibleGameobjectWithName(restartbtn, "UIRoot(Clone)", "ResultCanvas");
        restartbtn = restartbtn.transform.Find("Restartbtn(Clone)").gameObject;
        restartbtn.GetComponent<Button>().onClick.AddListener(() => RestartbtnClick(playerData, playerManager, obstacleManager, lifeManager, uIManager));

        quitbtn = Utility.Object.FindInvisibleGameobjectWithName(quitbtn, "UIRoot(Clone)", "ResultCanvas");
        quitbtn = quitbtn.transform.Find("Quitbtn(Clone)").gameObject;
        quitbtn.GetComponent<Button>().onClick.AddListener(() => QuitbtnClick());
    }

    void DodgeStartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        gameObject = Utility.Object.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Object.Invisible(gameObject);
        gameObject = Utility.Object.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Object.Visible(gameObject);
        gameObject = Utility.Object.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Object.Visible(gameObject);
        playerManager.Init(playerData.speed);
        playerManager.GetPlayer().GetPlayerController().SetGameType(PlayerController.GameType.DODGE);
        playerManager.GetPlayer().GetPlayerController().SetGravity(0);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum(), uIManager);
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        uIManager.SetState(UIManager.State.DODGEMAINGAME);
    }

    void UpStartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        gameObject = Utility.Object.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Object.Invisible(gameObject);
        gameObject = Utility.Object.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Object.Visible(gameObject);
        uIManager.SetHeartActive(0, 10);
        gameObject = Utility.Object.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Object.Visible(gameObject);
        uIManager.SetState(UIManager.State.UPMAINGAME);
        playerManager.Init(playerData.speed);
        playerManager.GetPlayer().GetPlayerController().SetGameType(PlayerController.GameType.UP);
        playerManager.GetPlayer().GetPlayerController().SetGravity(1);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum(), uIManager);
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        Share.Util.InstantiatePrefab(Share.Path.Prefab.Scaffolding, null);
    }

    void RestartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        Utility.Mode.Resume();
        gameObject = Utility.Object.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Object.Invisible(gameObject);
        playerManager.Reset();
        obstacleManager.ResetObstacleNum();
        obstacleManager.Generate(obstacleManager.GetObstacleNum(), uIManager);
        lifeManager.ResetLife(playerData.life);
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        gameObject = GameObject.FindGameObjectWithTag("Scaffolding");
        if (gameObject == null)
            uIManager.SetState(UIManager.State.DODGEMAINGAME);
        else
        {
            uIManager.SetState(UIManager.State.UPMAINGAME);
            playerManager.GetPlayer().GetPlayerController().SetLifetime(3);
            Vector3 tt = new Vector3(0, -4, 0);
            gameObject.GetComponent<Transform>().position = tt;
        }
        uIManager.GetMaingameUI().ResetScore();
    }

    void QuitbtnClick()
    {
        Application.Quit();
    }
}
