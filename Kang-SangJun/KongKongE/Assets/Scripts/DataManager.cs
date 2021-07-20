using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private static Data m_PlayerData;
    private static MapData m_MapData;
    private static Vector3 Player_Pos;
    private static List<Vector3> Map_Pos = new List<Vector3>();
    private static List<Vector3> Map_Rotation = new List<Vector3>();
    private static int Map_Count;

    public static void PlayerData_init()
    {
        m_PlayerData = Resources.Load("Data/Player") as Data;
        Player_Pos = m_PlayerData.Pos;
    }
    public static void ObjectData_init(int MapLevel)
    {
        if(!m_MapData)m_MapData = Resources.Load("Data/Map") as MapData;
        
        if (MapLevel == 1)
        {
            Map_Pos.Clear();
            Map_Rotation.Clear();
            Map_Count = m_MapData.M1_Count;
            for (int i = 0; i < Map_Count; ++i)
            {
                Map_Pos.Add(m_MapData.M1_DataPos[i]);
                Map_Rotation.Add(m_MapData.M1_DataRotation[i]);
            }
        }
        if(MapLevel == 2)
        {
            Map_Pos.Clear();
            Map_Rotation.Clear();

            Map_Count = m_MapData.M1_Count;
            for(int i = 0; i < Map_Count; ++i)
            {
                Map_Pos.Add(m_MapData.M2_DataPos[i]);
                Map_Rotation.Add(m_MapData.M2_DataRotation[i]);
            }
        }


    }
    public static Vector3 setPlayerPos()
    {
        return Player_Pos;
    }

    public static void setPositon( List<Objects> Obj)
    {
        for(int i = 0; i < Map_Count; ++i)
        { 
           Obj[i].GetObject().transform.position = Map_Pos[i];
           Obj[i].GetObject().transform.rotation = Quaternion.Euler(Map_Rotation[i]);           
        }
    }

    public static void outData()
    {

    }
    public Data GetPlayerData()
    {
        return m_PlayerData;
    }

    public MapData GetMapData()
    {
        return m_MapData;
    }
}

