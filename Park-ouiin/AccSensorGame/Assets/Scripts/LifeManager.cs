using UnityEngine;

public class LifeManager
{
    int life, maxLife; // 현재 체력, 최대 체력

    // 현재 체력과 최대 체력 초기화
    public void Init(int startLife, int maxLife)
    {
        life = startLife;
        this.maxLife = maxLife;
    }

    // 체력 감소
    public void DecreaseLife(int damage)
    {
        life -= damage;        
    }

    // 체력 증가
    public void IncreaseLife(int amount)
    {
        // 현재 체력이 최대 체력보다 낮을 경우만
        if (life < maxLife)
            life += amount;
    }

    // 체력 리셋
    public void ResetLife(int startLife)
    {
        life = startLife;
    }

    // 현재 체력 반환
    public int GetLife()
    {
        return life;
    }

    // 최대 체력 반환
    public int GetMaxLife()
    {
        return maxLife;
    }
}
