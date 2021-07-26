using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 타입
// 위치값
// 속성
public enum PrefabsType
{
    Cube, CheckPoint, Circle ,Plane , Player
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
                //    default:
                //        throw (Exception(prefabs.ToString()));
                //
        }
        return prefabs;
    }
}



public enum ObjectType
{
    Player , FixedMap, MoveMap , CheckPoint
}
public abstract class FGB_Object
{
    private  GameObject Obj;

    public abstract void Update();

    public GameObject GetObject()
    {
        return Obj;
    }

    public void Destroy()
    {
        GameObject.Destroy(Obj);
    }

    public void Init(PrefabsType preName)
    {
        FGB_Prefab prefabs = FGB_PrefabFactory.CreatPrefabs(preName);
        Obj = GameObject.Instantiate(prefabs.GetGameObject(), Vector3.zero, Quaternion.identity);

    }

    public abstract void AddComponent();
}
public class FGB_PlayerObject : FGB_Object
{
    private GameObject Obj;

    public override void AddComponent()
    {
        Obj.AddComponent<Rigidbody>();
        Obj.AddComponent<CapsuleCollider>();
        Obj.GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
        Obj.GetComponent<CapsuleCollider>().height = 2;
        Obj.GetComponent<CapsuleCollider>().radius = 0.05f;
        Obj.GetComponent<Rigidbody>().freezeRotation = true;
        Obj.tag = "Player";
    }

    public override void Update()
    {
        FGB_MoveController.PlayerMove(GetObject());
    }
    public void Jump()
    {
        FGB_MoveController.PlayerJump(Obj);
    }

}
public class FGB_FixedMapObject : FGB_Object
{
    private GameObject Obj;

    public override void AddComponent()
    {
        Obj.tag = "Map";
    }
    public override void Update()
    {
        FGB_MoveController.MoveMap(Obj);
    }


}

public class FGB_MoveMapObject : FGB_Object
{
    private GameObject Obj;
    public override void AddComponent()
    {
        Obj.tag = "Map";
    }
    public override void Update()
    {
        Obj.transform.position = new Vector3(1, 10, 1);
    }


}
public class FGB_CheckPointObject : FGB_Object
{
    private GameObject Obj;
    private RaycastHit m_Rayh;
    private bool isTouching = false;
    public override void AddComponent()
    {
        Obj.tag = "CheckPoint";
    }
    public override void Update()
    {

    }


}



public class ObjectsFactory
{
    public static FGB_Object CreateObjects(ObjectType type, PrefabsType preNam)
    {
        FGB_Object obj = null;
        switch (type)
        {
            case ObjectType.Player:
                obj = new FGB_PlayerObject();
                break;
            case ObjectType.FixedMap:
                obj = new FGB_FixedMapObject();
                break;
            case ObjectType.MoveMap:
                obj = new FGB_MoveMapObject();
                break;
            case ObjectType.CheckPoint:
                obj = new FGB_CheckPointObject();
                break;
        }
        obj.Init(preNam);
        return obj;
    }
}


