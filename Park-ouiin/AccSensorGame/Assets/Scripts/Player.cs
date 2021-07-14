using UnityEngine;

public class Player
{
    GameObject goPlayer;
    PlayerController playerController;

    // �÷��̾� �ʱ�ȭ
    public void Init(float speed)
    {
        goPlayer = Share.Util.InstantiatePrefab(Share.Path.Prefab.Character, UIRoot.noneUIGameObject);
        playerController = new PlayerController();
        playerController.Init(speed);
    }

    // �÷��̾���Ʈ�ѷ� ��ȯ
    public PlayerController GetPlayerController()
    {
        return playerController;
    }

    // �÷��̾� ���� ������Ʈ ��ȯ
    public GameObject GetPlayerGameObject()
    {
        return goPlayer;
    }
}
