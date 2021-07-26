using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_Player
{
    private FGB_Object m_pp;
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
        m_pp = ObjectsFactory.CreateObjects(ObjectType.Player, PrefabsType.Player);
        FGB_DataManager.PlayerDataInit();
        m_pp.GetObject().transform.position = FGB_DataManager.setPlayerPos();

        m_Camera = new FGB_Camera();
        m_Camera.Init();

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

        FGB_UIManager.Death_Count(++DeathCount);
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
        FGB_MoveController.PlayerJump(m_pp.GetObject());
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
