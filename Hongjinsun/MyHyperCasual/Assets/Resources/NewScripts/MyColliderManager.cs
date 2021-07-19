using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColliderManager 
{
    MyPlayerController playerController;
    MyPlayer player;
    GameObject[] m_enermies;
    public bool isDead;

    public void Init(MyPlayerController playerController)
    {
        this.playerController = playerController;
        player = playerController.player;
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
            if (player.box.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>())) 
            { 
                Debug.Log("플레이어가 적을 공격!");
                //m_enermies[i].SetActive(false);
                GameObject.Destroy(m_enermies[i]);
                playerController.isAttack = true;
                playerController.SetScore(playerController.GetScore() + 1);
            }

            if ( player.capsule.IsTouching(m_enermies[i].GetComponent<CapsuleCollider2D>()))
            {
                Debug.Log("적이 플레이어를 공격!");
                //player.obj.SetActive(false);
                isDead = true;
                ResetData();
            }
        }
    }
}
