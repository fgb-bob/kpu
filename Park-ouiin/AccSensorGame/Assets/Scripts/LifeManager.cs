using UnityEngine;

public class LifeManager
{
    int life, maxLife;

    public void Init(int startLife, int maxLife)
    {
        life = startLife;
        this.maxLife = maxLife;
    }

    public void DecreaseLife(int damage)
    {
        life -= damage;        
    }
    public void IncreaseLife(int amount)
    {
        if (life < maxLife)
            life += amount;
    }

    public void ResetLife(int startLife)
    {
        life = startLife;
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
