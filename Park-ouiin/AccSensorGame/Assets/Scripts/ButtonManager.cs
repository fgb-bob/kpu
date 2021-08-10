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
        upStartbtn.GetComponent<Button>().onClick.AddListener(() => UpStartbtnClick(playerData, playerManager, obstacleManager, uIManager));

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
        playerManager.GetPlayer().GetPlayerController().SetGravity(0);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum(), uIManager);
        uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
        uIManager.SetState(UIManager.State.DODGEMAINGAME);
    }

    void UpStartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, UIManager uIManager)
    {
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "TitleCanvas");
        Utility.Invisible(gameObject);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "UIRoot(Clone)", "MaingameCanvas");
        Utility.Visible(gameObject);
        uIManager.SetHeartActive(0, 10);
        gameObject = Utility.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
        Utility.Visible(gameObject);        
        uIManager.SetState(UIManager.State.UPMAINGAME);
        playerManager.Init(playerData.speed);
        playerManager.GetPlayer().GetPlayerController().SetGameType(PlayerController.GameType.UP);
        playerManager.GetPlayer().GetPlayerController().SetGravity(1);
        obstacleManager.Init();
        obstacleManager.Generate(obstacleManager.GetObstacleNum(), uIManager);          
        Share.Util.InstantiatePrefab(Share.Path.Prefab.Scaffolding, null);
    }

    void RestartbtnClick(PlayerData playerData, PlayerManager playerManager, ObstacleManager obstacleManager, LifeManager lifeManager, UIManager uIManager)
    {
        Utility.Resume();
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "ResultCanvas");
        Utility.Invisible(gameObject);
        playerManager.Reset();
        obstacleManager.ResetObstacleNum();
        obstacleManager.Generate(obstacleManager.GetObstacleNum(), uIManager);
        lifeManager.ResetLife(playerData.life);
        if (uIManager.GetState() == UIManager.State.DODGEMAINGAME)
        {
            uIManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());            
            uIManager.SetState(UIManager.State.DODGEMAINGAME);
        }
        else 
        {
            playerManager.GetPlayer().GetPlayerController().SetLife(5);
            uIManager.SetState(UIManager.State.UPMAINGAME); GameObject go = GameObject.FindGameObjectWithTag("Obstacle");
            gameObject = GameObject.FindGameObjectWithTag("Scaffolding");
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
