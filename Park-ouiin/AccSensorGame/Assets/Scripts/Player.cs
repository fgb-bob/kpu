using UnityEngine;

public class Player
{
    GameObject goPlayer;
    PlayerController playerController;

    public void Init(float speed)
    {
        goPlayer = Share.Util.InstantiatePrefab(Share.Path.Prefab.Character, UIRoot.noneUIGameObject);
        playerController = new PlayerController();
        playerController.Init(speed);
    }

    public void ControllerMoveUpdate()
    {
        playerController.Move();
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }

    public GameObject GetPlayerGameObject()
    {
        return goPlayer;
    }
}
