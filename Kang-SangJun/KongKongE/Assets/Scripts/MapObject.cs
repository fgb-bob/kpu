using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject
{
    private MapData m_MapData;
    private GameObject Obj;

    public void init(int index)
    {
        m_MapData = Resources.Load("Data/Map") as MapData;
        Obj = m_MapData.DataPrefabs[index];
        Obj = GameObject.Instantiate(Obj, m_MapData.DataPos[index], Quaternion.Euler(m_MapData.DataRotation[index]));
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

//public class MoveMap : Map
//{

//}

//public class CheckPoint: Map
//{

//}
