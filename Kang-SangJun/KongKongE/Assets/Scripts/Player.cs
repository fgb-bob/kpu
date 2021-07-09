using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private MoveController p_MoveContoller;

    private Vector3 SavePos;
    private bool isJumping;
    private GameObject m_Player;
    private CapsuleCollider m_Collider;
    private Rigidbody m_Rigid;
    private Collision m_CheckColl;
    private RaycastHit m_Rayh;
    private float JumpCool;
    private bool CollCheckPoint;
    public void init()
    {
        p_MoveContoller = new MoveController();

        m_Player = Resources.Load("Prefabs/Stick") as GameObject;
        m_Player = GameObject.Instantiate(GetObject(), GetObject().transform.position, Quaternion.identity);
        m_Player.tag = "Player";
        m_Player.AddComponent<Rigidbody>();
        m_Player.AddComponent<CapsuleCollider>();


        //콜라이더 박스
        m_Collider = m_Player.GetComponent<CapsuleCollider>();
        m_Collider.center = new Vector3(0, 1, 0);
        m_Collider.height = 2;
        m_Collider.radius = 0.05f;

        //리지드
        m_Rigid = m_Player.GetComponent<Rigidbody>();
        m_Rigid.freezeRotation = true;

        isJumping = false;
        JumpCool = 0.5f;
        CollCheckPoint = false;
        ////SavePos = m_Player.transform.position;
        //SavePos = GetObject().transform.position;
    }
    public GameObject GetObject()
    {
        return m_Player;
    }
    public void Move()
    {
       p_MoveContoller.PlayerMove(m_Player);
    }
    public void Jump()
    {
        //if (!isJumping)
        //{
        //    p_MoveContoller.PlayerJump(m_Player);
        //    isJumping = true;
        //}
        // if (m_Rigid.velocity.y < -1.0f) isJumping = false;
        
        p_MoveContoller.PlayerJump(m_Player);
    }

    public void Dead()
    {
        m_Rigid.velocity = Vector3.zero;
        m_Player.transform.position = SavePos;
        m_Player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    //SavePoint
    public void SetSavePoint(Vector3 Pos)
    {
        SavePos = Pos;
        Debug.Log(SavePos.x + "," + SavePos.y + "," + SavePos.z);
    }


    public void Coll()
    {
        JumpCool -= Time.deltaTime;

        //Debug.Log(m_Rigid.velocity.x + "," + m_Rigid.velocity.y + "," + m_Rigid.velocity.z  + "::" + isJumping);
        //Debug.Log(m_CheckColl.gameObject);
        if (Physics.Raycast(m_Player.transform.position, Vector3.down, out m_Rayh, 0.2f) && !isJumping)
        {
            if (m_Rayh.transform.tag == "Map")
            {
                Jump();
                JumpCool = 0.5f;
                Debug.Log("충돌");
                isJumping = true;
            }
            else if(m_Rayh.transform.tag == "CheckPoint")
            {
                SetSavePoint(m_Player.transform.position);
                SetCheckPoint(true);

            }
        }
        else if(JumpCool < 0) isJumping = false;
    }

    public void SetCheckPoint(bool B)
    {
        CollCheckPoint = B;
    }
    public bool GetCheckPoint()
    {
        return CollCheckPoint;
    }


}
