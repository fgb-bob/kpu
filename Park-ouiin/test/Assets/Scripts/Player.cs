using UnityEngine;

public class Player
{
    GameObject playerGameObject;
    PlayerController playerController;

    public void Init()
    {
        playerGameObject = Share.Util.InstantiatePrefab(Share.Path.Prefab.player, UIRoot.noneUIGameObject);
        playerController = new PlayerController();
        playerController.Init();
    }

    public void ControllerMoveUpdate()
    {
        playerController.Horizontal();
        //playerController.Vertical();
        playerController.Move();      
    }
}
