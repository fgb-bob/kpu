using UnityEngine;

public class LifeManager
{
    int life, maxLife; // ���� ü��, �ִ� ü��

    // ���� ü�°� �ִ� ü�� �ʱ�ȭ
    public void Init(int startLife, int maxLife)
    {
        life = startLife;
        this.maxLife = maxLife;
    }

    // ü�� ����
    public void DecreaseLife(int damage)
    {
        life -= damage;        
    }

    // ü�� ����
    public void IncreaseLife(int amount)
    {
        // ���� ü���� �ִ� ü�º��� ���� ��츸
        if (life < maxLife)
            life += amount;
    }

    // ü�� ����
    public void ResetLife(int startLife)
    {
        life = startLife;
    }

    // ���� ü�� ��ȯ
    public int GetLife()
    {
        return life;
    }

    // �ִ� ü�� ��ȯ
    public int GetMaxLife()
    {
        return maxLife;
    }
}
