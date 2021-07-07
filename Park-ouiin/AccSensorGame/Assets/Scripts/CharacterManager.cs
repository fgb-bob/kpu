using UnityEngine;

public class CharacterManager
{
    public static GameObject Player;    
    public static int life,maxLife;
    public static bool NoDamage;
    public static float ndt;

    public static void Init()
    {
        Player = Share.Util.InstantiatePrefab(Share.Path.Prefab.Character, null);
        life = 3;
        maxLife = life;
        NoDamage = false;
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
}
