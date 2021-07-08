using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private MoveController p_MoveContoller;

    private Vector3 SavePos = Vector3.zero;
    private GameObject m_Player;
    private CapsuleCollider m_Collider;
    private Rigidbody m_Rigid;
    private Collision m_CheckColl;
    private RaycastHit m_Rayh;
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

    }

    public void SetPlayer(Vector3 Pos)
    {
        m_Player.tag = "Player";
        m_Player = GameObject.Instantiate(GetObject(), GetObject().transform.position, Quaternion.identity);
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
        p_MoveContoller.PlayerJump(m_Player);
    }

    public void Dead()
    {
        m_Player.transform.position = SavePos;
    }

    //SavePoint
    public void SetSavePoint(Vector3 Pos)
    {
        SavePos = Pos;
    }
    public void Coll()
    {
        //Debug.Log(m_CheckColl.gameObject);
        if(Physics.Raycast(m_Player.transform.position, Vector3.down,out m_Rayh, 0.9f))
        {
            if(m_Rayh.transform.tag == "Map")
            {
                Jump();
            }
        }
    }




}
