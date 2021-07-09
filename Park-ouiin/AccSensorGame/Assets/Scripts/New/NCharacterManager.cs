using UnityEngine;

public class NCharacterManager
{
    public NPlayer nPlayer;
    GameObject Player;
    int life, maxLife;

    public void Init()
    {
        nPlayer = new NPlayer();
        Player = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Character, null);
        life = 3;
        maxLife = life;
    }

    public bool Touching(Collider2D colA, Collider2D colB)
    {
        return colA.IsTouching(colB);
    }

    public void DecreaseLife(int damage)
    {
        life -= damage;
    }

    public void IncreaseLife(int amount)
    {
        if (life < maxLife)
        {
            life += amount;
        }
    }

    public void Reset()
    {
        life = 3;
        Player.GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
    }

    public int GetLife()
    {
        return life;
    }
    public int GetMaxLife()
    {
        return maxLife;
    }
}
