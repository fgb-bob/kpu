using UnityEngine;

public class PlayerManager
{
    Player player;

    public void Init(float speed)
    {
        player = new Player();
        player.Init(speed);
    }

    public void PlayerMoveUpdate()
    {
        player.ControllerMoveUpdate();
    }

    public GameObject GetGameObjectPlayer()
    {
        return player.GetPlayerGameObject();
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void Reset()
    {
        player.GetPlayerGameObject().GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
    }
}
