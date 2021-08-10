using UnityEngine;
using System;

public class MyColliderManager
{
    MyPlayerController m_playerController;
    MyPlayer m_player;
    MyEnermyGenerator m_enermyGenerator;
    GameObject[] m_enermies;
    BoxCollider2D m_SideStop;
    public bool isDead;

    public void Init(MyPlayerController playerController, MyEnermyGenerator enermyGenerator)
    {
        m_playerController = playerController;
        m_player = playerController.player;
        m_enermyGenerator = enermyGenerator;

        m_SideStop = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.StopSide, null).GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        m_enermies = GameObject.FindGameObjectsWithTag("enermy");

        if (m_enermies.Length > 0)
        {
            Attack();
            Block();
        }

        SideCollide();
    }

    public void ResetData()
    {
        for (int i = 0; i < m_enermies.Length; ++i)
        {
            GameObject.Destroy(m_enermies[i]);
        }
    }

    void Attack()
    {
        for (int i = 0; i < m_enermies.Length; ++i)
        {
            if (m_player.polygon.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>()))
            {
                GameObject.Destroy(m_enermies[i]);
                m_playerController.isAttack = true;
                m_playerController.Score += 1;
            }

            if (m_player.capsule.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>()))
            {
                //isDead = true;
                //ResetData();
                m_playerController.isReturn = true;
                m_playerController.isMove = false;
            }
        }
    }

    void Block()
    {
        for (int i = 0; i < m_enermies.Length; ++i)
        {
            if(m_player.box.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>()))
            {
                Debug.Log("¹æ¾î");
                for (int j = 0; j < m_enermies.Length; ++j)
                {
                    m_enermies[j].transform.Translate( new Vector2(m_enermies[i].transform.position.x + 1, 0));
                }
            }
        }
     }

    void SideCollide()
    {
        if (m_player.rigid.IsTouching(m_SideStop) && m_playerController.isMove == false)  
        {
            m_player.rigid.velocity = Vector2.zero;
            m_playerController.isMove = true;
        }
    }
}