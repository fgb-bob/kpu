using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject
{
    protected MapData m_MapData;
    protected GameObject Obj;

    public void init(int index)
    {
        m_MapData = Resources.Load("Data/Map") as MapData;
        Obj = m_MapData.DataPrefabs[index];
        Obj = GameObject.Instantiate(Obj, m_MapData.M1_DataPos[index], Quaternion.Euler(m_MapData.M1_DataRotation[index]));
        //Obj.transform.localScale = m_MapData.DataScale[index];
        Obj.tag = "Map"; 

    }

    public void ChangeMap(int index)
    {
        GameObject.Destroy(Obj);
        m_MapData = Resources.Load("Data/Map") as MapData;
        Obj = m_MapData.M2_DataPrefabs[index];
        Obj = GameObject.Instantiate(Obj, m_MapData.M2_DataPos[index], Quaternion.Euler(m_MapData.M2_DataRotation[index]));
        //Obj.transform.localScale = m_MapData.DataScale[index];
        Obj.tag = "Map";

    }
    public void SavePos()
    {
        Debug.Log("d");
    }

    public BoxCollider GetCollider()
    {
        return Obj.GetComponent<BoxCollider>();
    }
}

public class MoveMap : MapObject
{
    private MoveController m_MoveContoller;
    public void init(int index)
    {
        m_MapData = Resources.Load("Data/Map") as MapData;
        Obj = m_MapData.DataPrefabs[index];
        Obj = GameObject.Instantiate(Obj, m_MapData.M1_DataPos[index], Quaternion.Euler(m_MapData.M1_DataRotation[index]));
        //Obj.transform.localScale = m_MapData.DataScale[index];
        Obj.tag = "Map";
        m_MoveContoller = new MoveController();
    }

    public void Move()
    {
        Obj.transform.position += new Vector3(0.001f, 0, 0);
    }

 

}

public class CheckPoint : MapObject
{
    public void init(int index)
    {
        m_MapData = Resources.Load("Data/Map") as MapData;
        Obj = m_MapData.C1_DataPrefabs;
        Obj = GameObject.Instantiate(Obj,m_MapData.C1_DataPo, Quaternion.Euler(m_MapData.C1_DataRotation));
        Obj.transform.localScale = m_MapData.C1_DataScale;

        Obj.tag = "CheckPoint";
    }
    public void ChangeMap()
    {

    }
}
