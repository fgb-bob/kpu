using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FGB_DataManager
{
    private static FGB_Data m_PlayerData;
    private static FGB_MapData m_MapData;
    private static Vector3 Player_Pos;
    private static List<Vector3> Map_Pos = new List<Vector3>();
    private static List<Vector3> Map_Rotation = new List<Vector3>();
    private static int Map_Count;
    private static ObjectType ObjType;
    private static PrefabsType PreType;

    public static void PlayerDataInit()
    {
        m_PlayerData = Resources.Load("Data/Player") as FGB_Data;
        Player_Pos = m_PlayerData.Pos;
    }
    public static void ObjectDataInit(int MapLevel)
    {
        if (!m_MapData) m_MapData = Resources.Load("Data/Map") as FGB_MapData;

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
        if (MapLevel == 2)
        {
            Map_Pos.Clear();
            Map_Rotation.Clear();

            Map_Count = m_MapData.M1_Count;
            for (int i = 0; i < Map_Count; ++i)
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

    public static void setPositon(List<FGB_Object> Obj)
    {
        for (int i = 0; i < Map_Count; ++i)
        {
            Obj[i].GetObject().transform.position = Map_Pos[i];
            Obj[i].GetObject().transform.rotation = Quaternion.Euler(Map_Rotation[i]);
        }
    }

    public static void outData()
    {

    }
    public static FGB_Data GetPlayerData()
    {
        return m_PlayerData;
    }

    public static FGB_MapData GetMapData()
    {
        return m_MapData;
    }
    public static int GetMapCount()
    {
        return Map_Count;
    }
    public static Vector3 GetMapPos(int i)
    {
        return Map_Pos[i];
    }
    public static ObjectType GetObjectType(int i)
    {
        return ObjType;
    }
    public static PrefabsType GetPrefabsType(int i)
    {
        return PreType;
    }
}

