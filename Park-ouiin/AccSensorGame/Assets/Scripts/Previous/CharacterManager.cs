using UnityEngine;

public class CharacterManager
{
    public static GameObject Player;
    public static Transform tf;
    public static int life,maxLife;
    public static float ndt;

    public static void Init()
    {
        Player = Share.Util.InstantiatePrefab(Share.Path.Prefab.Character, null);
        tf = Player.GetComponent<Transform>();
    }

    public static bool Touching(Collider2D colA, Collider2D colB)
    {
        return colA.IsTouching(colB);
    }

    public static void DecreaseLife(int damage)
    {
        life -= damage;
        MaingameUI.SetHeartActive(life);
    }

    public static void IncreaseLife(int amount)
    {
        if (life < maxLife)
        {
            life += amount;
            MaingameUI.SetHeartActive(life);
        }
    }

    public static void Reset()
    {
        life = 3;
        Player.GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
    }
}
