using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Objects m_pp;
    private PlayerCamera m_Camera;

    private Vector3 SavePos;
    private bool isJumping;
    private RaycastHit m_Rayh;

    private float JumpCool;
    private bool CollCheckPoint;

    private int DeathCount;
    public void init()
    {
        DeathCount = 0;
        m_pp = UseObjects.MakeObjects(ObjectType.Player, PrefabsType.Player);
        DataManager.PlayerData_init();
        m_pp.GetObject().transform.position = DataManager.setPlayerPos();

        m_Camera = new PlayerCamera();
        m_Camera.init();

    }

    public void Update()
    {
        m_pp.Update();
        Coll();
        if (GetObject().transform.position.y < -5)
            Dead();
        m_Camera.onPlayer(m_pp.GetObject());
    }



    public GameObject GetObject()
    {
        return m_pp.GetObject();
    }


    public void Dead()
    {
        m_pp.GetObject().GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_pp.GetObject().transform.position = SavePos;
        m_pp.GetObject().transform.rotation = Quaternion.Euler(0, 0, 0);

        UIManager.Death_Count(++DeathCount);
    }



    public void Coll()
    {
        JumpCool -= Time.deltaTime;

        if (Physics.Raycast(m_pp.GetObject().transform.position, Vector3.down, out m_Rayh, 0.2f) && !isJumping)
        {
            if (m_Rayh.transform.tag == "Map")
            {
                Jump();
                JumpCool = 0.5f;
                isJumping = true;
            }
            else if(m_Rayh.transform.tag == "CheckPoint")
            {
                SetSavePoint(m_pp.GetObject().transform.position);
                SetCheckPoint(true);

            }
        }
        else if(JumpCool < 0) isJumping = false;
    }
    public void Jump()
    {
        MoveController.PlayerJump(m_pp.GetObject());
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
