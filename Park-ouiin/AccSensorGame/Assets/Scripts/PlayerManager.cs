using UnityEngine;

public class PlayerManager
{
    Player player;

    // �÷��̾� �ʱ�ȭ
    public void Init(float speed)
    {
        player = new Player();
        player.Init(speed);
    }

    // �÷��̾� ��ȯ
    public Player GetPlayer()
    {
        return player;
    }

    // �÷��̾� ��ġ �ʱ�ȭ
    public void Reset()
    {
        player.GetPlayerGameObject().GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
    }
}
