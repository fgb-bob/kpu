using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderManager 
{
    BackgroundManager backgroundManager;
    //PlayerController playerController;
    Player player;
    Rigidbody2D rigid;
    

    public void Init(BackgroundManager backgroundManager, Player player)
    {
        this.backgroundManager = backgroundManager;
        this.player = player;
        rigid = player.getRigidbody();
    }

    // 캐릭터가 좌우로 움직이다가 SideCollider에 부딪히면 가운데로 돌아와야 한다.
    public void OnTriggerEnterToSide()
    {
        if ( rigid.IsTouching(backgroundManager.getLeftSide()) && player.getMoveState() != 1 )
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(player.myVelocity, ForceMode2D.Impulse);
            player.setMoveState(1);
        }

        else if ( rigid.IsTouching(backgroundManager.getRightSide()) && player.getMoveState() != 2)
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(-player.myVelocity, ForceMode2D.Impulse);
            player.setMoveState(2);
        }

        else if (rigid.IsTouching(backgroundManager.getCenterSide()) && player.getMoveState() != 0)
        {
            rigid.velocity = Vector2.zero;
            player.getPlayerObj().transform.position = new Vector2(0, -2.89f);
            player.setMoveState(0);
        }
    }

    public void OnTriggerEnterToEnermy()
    {
        BoxCollider2D boxCollider = player.getBoxCollider();

        GameObject[] enermy = GameObject.FindGameObjectsWithTag("enermy");

        for (int i = 0; i < enermy.Length; ++i) {
            if (boxCollider.IsTouching(enermy[i].GetComponent<CapsuleCollider2D>()))
            {
                rigid.velocity = Vector2.zero;
                if (enermy[i].transform.position.x < 0)
                    rigid.AddForce(player.myVelocity, ForceMode2D.Impulse);
                else if (enermy[i].transform.position.x > 0)
                    rigid.AddForce(-player.myVelocity, ForceMode2D.Impulse);
                player.setMoveState(4);
                player.addScore(1);
                GameObject.Destroy(enermy[i]);
            }
            
            if (rigid.IsTouching(enermy[i].GetComponent<CapsuleCollider2D>())) {
                Time.timeScale = 0;                

                Debug.Log("악!!!! 나 죽었다!!");
                player.getPlayerObj().SetActive(false);
                GameObject.Destroy(enermy[i]);
               // Time.fixedDeltaTime = 0;
            }
        }

    }
}

