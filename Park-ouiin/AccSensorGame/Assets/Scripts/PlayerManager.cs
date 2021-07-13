using UnityEngine;

public class PlayerManager
{
    Player player;

    // 플레이어 초기화
    public void Init(float speed)
    {
        player = new Player();
        player.Init(speed);
    }

    // 플레이어 반환
    public Player GetPlayer()
    {
        return player;
    }

    // 플레이어 위치 초기화
    public void Reset()
    {
        player.GetPlayerGameObject().GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
    }
}
