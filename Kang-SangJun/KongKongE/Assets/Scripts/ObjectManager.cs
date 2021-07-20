using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectManager
{
    private static List<Objects> MapObj = new List<Objects>();
    private static Player player;
    private static int MapLevel = 0;

    public static void Player_init()
    {
        player = new Player();
        player.init();
    }



    public static void Map_init()
    {
        MapLevel++;
        switch (MapLevel)
        {
            case 1:
                Map1_init();
                break;

            case 2:
                Map2_init();
                UIManager.Level_Change(2);
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
            Map_init();
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




    public static void Map1_init()
    {
        Destroy();

        DataManager.ObjectData_init(1);

        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Plane));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.CheckPoint, PrefabsType.Plane));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));

        DataManager.setPositon(MapObj);
    }

    public static void Map2_init()
    {
        Destroy();

        DataManager.ObjectData_init(2);

        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Plane));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.CheckPoint, PrefabsType.Plane));
        MapObj.Add(UseObjects.MakeObjects(ObjectType.FixedMap, PrefabsType.Cube));

        DataManager.setPositon(MapObj);

    }

}