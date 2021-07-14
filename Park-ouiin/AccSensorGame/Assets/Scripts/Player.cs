using UnityEngine;

public class Player
{
    GameObject goPlayer;
    PlayerController playerController;

    // 플레이어 초기화
    public void Init(float speed)
    {
        goPlayer = Share.Util.InstantiatePrefab(Share.Path.Prefab.Character, UIRoot.noneUIGameObject);
        playerController = new PlayerController();
        playerController.Init(speed);
    }

    // 플레이어컨트롤러 반환
    public PlayerController GetPlayerController()
    {
        return playerController;
    }

    // 플레이어 게임 오브젝트 반환
    public GameObject GetPlayerGameObject()
    {
        return goPlayer;
    }
}
