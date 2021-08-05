using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrefabsType
{
    Cube, CheckPoint, Circle, Plane, Player
}
public abstract class FGB_Prefab
{
    private GameObject prefabs;

    public abstract GameObject GetGameObject();

}
public class FGB_CubePrefab : FGB_Prefab
{
    private GameObject prefabs;

    public FGB_CubePrefab()
    {
        prefabs = Resources.Load("Prefabs/Cube") as GameObject;
    }

    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}
public class FGB_CheckPrefab : FGB_Prefab
{
    private GameObject prefabs;

    public FGB_CheckPrefab()
    {
        prefabs = Resources.Load("Prefabs/CheckPoint") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}
public class FGB_CirclePrefab : FGB_Prefab
{
    private GameObject prefabs;

    public FGB_CirclePrefab()
    {
        prefabs = Resources.Load("Prefabs/Test") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}

public class FGB_PlanePrefab : FGB_Prefab
{
    private GameObject prefabs;

    public FGB_PlanePrefab()
    {
        prefabs = Resources.Load("Prefabs/Plane") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}

public class FGB_PlayerPrefb : FGB_Prefab
{
    private GameObject prefabs;

    public FGB_PlayerPrefb()
    {
        prefabs = Resources.Load("Prefabs/Stick") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}

public class FGB_PrefabFactory
{
    public static FGB_Prefab CreatPrefabs(PrefabsType type)
    {
        FGB_Prefab prefabs = null;
        switch (type)
        {
            case PrefabsType.Cube:
                prefabs = new FGB_CubePrefab();
                break;
            case PrefabsType.CheckPoint:
                prefabs = new FGB_CheckPrefab();
                break;
            case PrefabsType.Circle:
                prefabs = new FGB_CirclePrefab();
                break;
            case PrefabsType.Plane:
                prefabs = new FGB_PlanePrefab();
                break;
            case PrefabsType.Player:
                prefabs = new FGB_PlayerPrefb();
                break;
            default:
                throw new System.NotImplementedException();
        }
        return prefabs;
    }
}


