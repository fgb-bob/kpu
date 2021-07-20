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
public abstract class Prefabs
{
    private GameObject prefabs;

    public abstract GameObject GetGameObject();
 
}
public class CubePrefabs : Prefabs
{
    private GameObject prefabs;

    public CubePrefabs()
    {
        prefabs = Resources.Load("Prefabs/Cube") as GameObject;
    }

    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}
public class CheckPrefabs : Prefabs
{
    private GameObject prefabs;

    public CheckPrefabs()
    {
        prefabs = Resources.Load("Prefabs/CheckPoint") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}
public class CirclePrefabs : Prefabs
{
    private GameObject prefabs;

    public CirclePrefabs()
    {
        prefabs = Resources.Load("Prefabs/Test") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}

public class PlanePrefabs : Prefabs
{
    private GameObject prefabs;

    public PlanePrefabs()
    {
        prefabs = Resources.Load("Prefabs/Plane") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}

public class PlayerPrefbs : Prefabs
{
    private GameObject prefabs;

    public PlayerPrefbs()
    {
        prefabs = Resources.Load("Prefabs/Stick") as GameObject;
    }
    public override GameObject GetGameObject()
    {
        return prefabs;
    }
}

public class PrefabsFactory
{
    public static Prefabs CreatPrefabs(PrefabsType type)
    {
        Prefabs prefabs = null;
        switch (type)
        {
            case PrefabsType.Cube:
                prefabs = new CubePrefabs();
                break;
            case PrefabsType.CheckPoint:
                prefabs = new CheckPrefabs();
                break;
            case PrefabsType.Circle:
                prefabs = new CirclePrefabs();
                break;
            case PrefabsType.Plane:
                prefabs = new PlanePrefabs();
                break;
            case PrefabsType.Player:
                prefabs = new PlayerPrefbs();
                break;
        }
        return prefabs;
    }
}



public enum ObjectType
{
    Player , FixedMap, MoveMap , CheckPoint
}
public abstract class Objects 
{
    private  GameObject Obj;

    public abstract void Update();

    public abstract GameObject GetObject();

    public abstract void Destroy();
}
public class Obj_Player : Objects
{
    private GameObject Obj;
    public Obj_Player(PrefabsType preNam)
    {
        Prefabs prefabs = PrefabsFactory.CreatPrefabs(preNam);
        Obj = GameObject.Instantiate(prefabs.GetGameObject(), Vector3.zero, Quaternion.identity);
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
        MoveController.PlayerMove(Obj);
        //MoveController.PlayerJump(Obj);
    }
    public void Jump()
    {
        MoveController.PlayerJump(Obj);
    }
    public override GameObject GetObject()
    {
        return Obj;
    }

    public override void Destroy()
    {
        GameObject.Destroy(Obj);
    }

}
public class Obj_FixedMap : Objects
{
    private GameObject Obj;

    public Obj_FixedMap(PrefabsType preNam)
    {
        Prefabs prefabs = PrefabsFactory.CreatPrefabs(preNam);
        Obj = GameObject.Instantiate(prefabs.GetGameObject(), Vector3.zero, Quaternion.identity);
        Obj.tag = "Map";
    }
    public override void Update()
    {
        MoveController.MoveMap(Obj);
    }
    public override GameObject GetObject()
    {
        return Obj;
    }

    public override void Destroy()
    {
        GameObject.Destroy(Obj);
    }
}

public class Obj_MoveMap : Objects
{
    private GameObject Obj;
    public Obj_MoveMap(PrefabsType preNam)
    {
        Prefabs prefabs = PrefabsFactory.CreatPrefabs(preNam);
        Obj = GameObject.Instantiate(prefabs.GetGameObject(), Vector3.zero, Quaternion.identity);
        Obj.tag = "Map";
    }
    public override void Update()
    {
        Obj.transform.position = new Vector3(1, 10, 1);
    }
    public override GameObject GetObject()
    {
        return Obj;
    }

    public override void Destroy()
    {
        GameObject.Destroy(Obj);
    }
}
public class Obj_CheckPoint : Objects
{
    private GameObject Obj;
    private RaycastHit m_Rayh;
    private bool isTouching = false;
    public Obj_CheckPoint(PrefabsType preNam)
    {
        Prefabs prefabs = PrefabsFactory.CreatPrefabs(preNam);
        Obj = GameObject.Instantiate(prefabs.GetGameObject(), Vector3.zero, Quaternion.identity);
        Obj.tag = "CheckPoint";
    }
    public override void Update()
    {
       // Coll();
        //Obj.transform.position += Vector3.up;
    }
    public override GameObject GetObject()
    {
        return Obj;
    }

    public override void Destroy()
    {
        GameObject.Destroy(Obj);
    }
}



public class ObjectsFactory
{
    public static Objects CreateObjects(ObjectType type, PrefabsType preNam)
    {
        Objects obj = null;
        switch (type)
        {
            case ObjectType.Player:
                obj = new Obj_Player( preNam);
                break;
            case ObjectType.FixedMap:
                obj = new Obj_FixedMap( preNam);
                break;
            case ObjectType.MoveMap:
                obj = new Obj_MoveMap( preNam);
                break;
            case ObjectType.CheckPoint:
                obj = new Obj_CheckPoint(preNam);
                break;
        }
        return obj;
    }
}

public class UseObjects 
{
    public static Objects MakeObjects(ObjectType name , PrefabsType preName)
    {
        Objects obj = ObjectsFactory.CreateObjects(name, preName);
        return obj;
    }
}

