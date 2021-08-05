using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_Player
{
    private FGB_Object m_Player;
    private FGB_Camera m_Camera;

    private Vector3 SavePos;
    private bool isJumping;
    private RaycastHit m_Rayh;

    private float JumpCool;
    private bool CollCheckPoint;

    private int DeathCount;
    public void Init()
    {
        DeathCount = 0;
        m_Player = FGB_ObjectsFactory.CreateObjects(ObjectType.Player, PrefabsType.Player);
        m_Player.GetObject().transform.position = new Vector3(0, 10, 0);

        m_Camera = new FGB_Camera();
        m_Camera.Init();

        isJumping = false;
    }

    public void Update(float Time)
    {
        m_Player.Update(Time);
        Coll();
        if (GetObject().transform.position.y < -5)
            Dead();
        m_Camera.onPlayer(m_Player.GetObject());
    }



    public GameObject GetObject()
    {
        return m_Player.GetObject();
    }


    public void Dead()
    {
        m_Player.GetObject().GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_Player.GetObject().transform.position = SavePos;
        m_Player.GetObject().transform.rotation = Quaternion.Euler(0, 0, 0);

        FGB_UIManager.DeathCount(++DeathCount);
    }

    public void Coll()
    {
        JumpCool -= Time.deltaTime;

        if (Physics.Raycast(m_Player.GetObject().transform.position, Vector3.down, out m_Rayh, 0.2f) && !isJumping)
        {
            if (m_Rayh.transform.tag == "Map")
            {
                Debug.Log("????");
                Jump();
                JumpCool = 0.5f;
                isJumping = true;
            }
            else if (m_Rayh.transform.tag == "CheckPoint")
            {
                SetSavePoint(m_Player.GetObject().transform.position);
                SetCheckPoint(true);

            }
        }
        else if (JumpCool < 0) isJumping = false;
    }
    public void Jump()
    {
        FGB_MoveController.PlayerJump(m_Player.GetObject());
    }

    public void SetSavePoint(Vector3 Pos)
    {
        SavePos = Pos;
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
