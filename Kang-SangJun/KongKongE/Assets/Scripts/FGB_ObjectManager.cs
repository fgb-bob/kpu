using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FGB_ObjectManager
{

    private FGB_DataManager m_DataManager = new FGB_DataManager();
    private FGB_Player player;

    private List<FGB_Object> MapObj = new List<FGB_Object>();
    private int MapLevel = 1;

    public void Init()
    {
        player = new FGB_Player();
        player.Init();

        m_DataManager.ObjectDataInit();
        MakeMap(MapLevel);
    }



    public void Update(float Time)
    {
        player.Update(Time);

        for (int i = 0; i < MapObj.Count; ++i)
        {
            MapObj[i].Update(Time);
        }

        if (player.GetCheckPoint())
        {
            ClearMap();
            MakeMap(MapLevel++);
        }
    }

    private void ClearMap()
    {
        for (int i = 0; i < MapObj.Count; ++i)
        {
            MapObj[i].Destroy();
        }
        MapObj.Clear();
    }



    public void MakeMap(int MapLevel)
    {
        for (int i = 0; i < m_DataManager.GetMapCount(MapLevel); ++i)
        {
            MapObj.Add(FGB_ObjectsFactory.CreateObjects(m_DataManager.GetObjectDataInfo(MapLevel, i).ObjectType, m_DataManager.GetObjectDataInfo(MapLevel, i).PrefabsType));
            MapObj[i].GetObject().transform.position = m_DataManager.GetObjectDataInfo(MapLevel, i).Pos;
            MapObj[i].GetObject().transform.rotation = Quaternion.Euler(m_DataManager.GetObjectDataInfo(MapLevel, i).Rotation);
        }
    }
}