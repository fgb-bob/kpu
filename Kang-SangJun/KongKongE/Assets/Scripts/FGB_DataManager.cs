using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_DataManager
{
    public struct ObjectDataInfo
    {
        public Vector3 Pos;
        public Vector3 Rotation;
        public ObjectType ObjectType;
        public PrefabsType PrefabsType;
    }
    private FGB_Data m_PlayerData;
    private FGB_MapData m_MapData;

    private Vector3 PlayerPos;
    private int MapCount;
    private ObjectType ObjType;
    private PrefabsType PreType;

    public Dictionary<int, List<ObjectDataInfo>> MapDataDictionory;

    public void PlayerDataInit()


    {
        m_PlayerData = Resources.Load("Data/Player") as FGB_Data;
        PlayerPos = m_PlayerData.Pos;
    }

    public void ObjectDataInit()
    {
        MapDataDictionory = new Dictionary<int, List<ObjectDataInfo>>();

        if (!m_MapData) m_MapData = Resources.Load("Data/Map") as FGB_MapData;

        List<ObjectDataInfo> TempObjectDataList = new List<ObjectDataInfo>();
        for (int i = 0; i < m_MapData.M1_MaxCount; ++i)
        {
            ObjectDataInfo TempObjectDataInfo;
            TempObjectDataInfo.Pos = m_MapData.M1_DataPos[i];
            TempObjectDataInfo.Rotation = m_MapData.M1_DataRotation[i];
            TempObjectDataInfo.ObjectType = m_MapData.M1_ObjType[i];
            TempObjectDataInfo.PrefabsType = m_MapData.M1_PreType[i];
            TempObjectDataList.Add(TempObjectDataInfo);
        }
        MapDataDictionory.Add(1, TempObjectDataList);

        List<ObjectDataInfo> TempObjectDataList2 = new List<ObjectDataInfo>();

        for (int i = 0; i < m_MapData.M2_MaxCount; ++i)
        {
            ObjectDataInfo TempObjectDataInfo;
            TempObjectDataInfo.Pos = m_MapData.M2_DataPos[i];
            TempObjectDataInfo.Rotation = m_MapData.M2_DataRotation[i];
            TempObjectDataInfo.ObjectType = m_MapData.M2_ObjType[i];
            TempObjectDataInfo.PrefabsType = m_MapData.M2_PreType[i];
            TempObjectDataList2.Add(TempObjectDataInfo);
        }

        MapDataDictionory.Add(2, TempObjectDataList2);
    }




    public int GetMapCount(int Level)
    {
        List<ObjectDataInfo> ObjectDataList = MapDataDictionory[Level];
        Debug.Log(ObjectDataList.Count);
        return ObjectDataList.Count;
    }
    public ObjectDataInfo GetObjectDataInfo(int Level, int i)
    {
        List<ObjectDataInfo> ObjectDataList = MapDataDictionory[Level];
        return ObjectDataList[i];
    }
}



//public void setPositon(List<FGB_Object> Obj)
//{

//    List<ObjectDataInfo> ObjectDataList = MapDataDictionory[1];

//    for (int i = 0; i < ObjectDataList.Count; ++i)
//    {
//        Obj[i].GetObject().transform.position = ObjectDataList[i].Pos;
//        Obj[i].GetObject().transform.rotation = Quaternion.Euler(ObjectDataList[i].Rotation);
//    }
//}

//public void outData()
//{

//}
//public FGB_Data GetPlayerData()
//{
//    return m_PlayerData;
//}

//public FGB_MapData GetMapData()
//{
//    return m_MapData;
//}