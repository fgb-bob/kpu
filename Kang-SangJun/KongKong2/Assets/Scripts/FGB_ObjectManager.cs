using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FGB_ObjectManager
{
    private static List<FGB_Object> MapObj = new List<FGB_Object>();
    private static FGB_Player player;
    private static int MapLevel = 0;

    public static void PlayerInit()
    {
        player = new FGB_Player();
        player.Init();
    }



    public static void MapInit()
    {
        MapLevel++;
        switch (MapLevel)
        {
            case 1:
                MakeMap();

                //Map1_Init();
                break;

            case 2:
                //Map2_Init();
                FGB_UIManager.Level_Change(2);
                break;
            case 3:
                break;
        }
    }

   
    public static void Update()
    {
        player.Update();

        for (int i = 0; i < MapObj.Count; ++i)
        {
            MapObj[i].Update();
        }

        if (player.GetCheckPoint())
        {
            MapInit();
        }
    }

    private static void Destroy()
    {
        for(int i = 0; i < MapObj.Count; ++i)
        {
            MapObj[i].Destroy();
        }
        MapObj.Clear();
    }



    public static void MakeMap()
    {
        if (MapObj.Count > 0) Destroy();

        for (int i = 0; i < FGB_DataManager.GetMapCount(); ++i)
        {
            MapObj.Add(ObjectsFactory.CreateObjects(FGB_DataManager.GetObjectType(i), FGB_DataManager.GetPrefabsType(i)));
            Debug.Log(FGB_DataManager.GetObjectType(i));
            Debug.Log(i);

        }
        FGB_DataManager.setPositon(MapObj);
    }
}