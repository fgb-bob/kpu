using UnityEngine;

public class PlayerManager
{
    Player player;

    public void Init()
    {
        player = new Player();
        player.Init();
    }

    public void PlayerMoveUpdate()
    {
        player.ControllerMoveUpdate();
    }
}
