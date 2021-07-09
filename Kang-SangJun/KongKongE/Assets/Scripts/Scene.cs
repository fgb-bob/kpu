using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    private Player m_Player;
    private myCamera m_Camera;
    private MapObject[] m_Maps;
    private CheckPoint m_CheckPoint;


    private Data m_PlayerData = Resources.Load("Data/Player") as Data;

    private int m_nMapGameObject;
    public void init()
    {
        m_Player = new Player();
        m_Camera = new myCamera();
        m_Maps = new MapObject[10];
        m_CheckPoint = new CheckPoint();

        m_nMapGameObject = 10;

        m_Player.init();
        m_Camera.init();
        m_CheckPoint.init(0);

        for (int i = 0; i < m_nMapGameObject; ++i)
        {
            m_Maps[i] = new MapObject();
            m_Maps[i].init(i);
            Debug.Log(i);
        }
        Set_Map1();

        m_Player.SetSavePoint(m_Player.GetObject().transform.position);
    }


    // 맵의 오브젝트 위치 정보 전달.
    public void Set_Map1()
    {
        m_Player.GetObject().transform.position = m_PlayerData.Pos;
    }

    public void Update()
    {
        //플레이어 이동
        m_Player.Move();

        //카메라 이동
        m_Camera.onPlayer(m_Player.GetObject());
        //큐브 이동
        //for (int i = 0; i < m_nMapGameObject; ++i)
        //    m_Maps[i].Move();

        m_Player.Coll();
        if (m_Player.GetCheckPoint())
        {
            for (int i = 0; i < m_nMapGameObject; ++i)
                m_Maps[i].ChangeMap(i);
            m_Player.SetCheckPoint(false);
        }
        
        if (m_Player.GetObject().transform.position.y < -5)
            m_Player.Dead();

        
    }
    


    private void CollsionCheck()
    {
    }
    

}
