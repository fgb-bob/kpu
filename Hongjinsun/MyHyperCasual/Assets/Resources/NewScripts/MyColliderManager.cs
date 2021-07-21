using UnityEngine;

public class MyColliderManager 
{
    MyPlayerController m_playerController;
    MyPlayer m_player;
    GameObject[] m_enermies;
    public bool isDead;

    public void Init(MyPlayerController playerController)
    {
        m_playerController = playerController;
        m_player = playerController.player;
    }

    public void Update()
    {
        m_enermies = GameObject.FindGameObjectsWithTag("enermy");

        if (m_enermies.Length > 0)
            Attack();
    }

    public void ResetData()
    {
        for (int i = 0; i < m_enermies.Length;++i)
        {
            GameObject.Destroy(m_enermies[i]);
        }
    }

    void Attack()
    {
        for (int i = 0; i < m_enermies.Length; ++i)
        {
            if (m_player.box.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>())) 
            { 
                GameObject.Destroy(m_enermies[i]);
                m_playerController.isAttack = true;
                m_playerController.SetScore(m_playerController.GetScore() + 1);
            }

            if (m_player.capsule.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>()))
            {
                isDead = true;
                ResetData();
            }
        }
    }
}
