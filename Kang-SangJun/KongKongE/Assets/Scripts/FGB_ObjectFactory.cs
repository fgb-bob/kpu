using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Player, FixedMap, MoveMap, CheckPoint
}
public abstract class FGB_Object
{
    private GameObject Obj;

    public abstract void Update(float Time);

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
        GetObject().AddComponent<Rigidbody>();
        GetObject().AddComponent<CapsuleCollider>();
        GetObject().GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
        GetObject().GetComponent<CapsuleCollider>().height = 2;
        GetObject().GetComponent<CapsuleCollider>().radius = 0.05f;
        GetObject().GetComponent<Rigidbody>().freezeRotation = true;
        GetObject().tag = "Player";
    }

    public override void Update(float Time)
    {
        FGB_MoveController.PlayerMove(GetObject() , Time);
    }
    public void Jump()
    {
        FGB_MoveController.PlayerJump(GetObject());
    }

}
public class FGB_FixedMapObject : FGB_Object
{
    private GameObject Obj;

    public override void AddComponent()
    {
        GetObject().tag = "Map";
    }
    public override void Update(float Time)
    {
    }


}

public class FGB_MoveMapObject : FGB_Object
{
    private GameObject Obj;
    public override void AddComponent()
    {
        GetObject().tag = "Map";
        GetObject().AddComponent<Rigidbody>();
        GetObject().GetComponent<Rigidbody>().useGravity = false;
    }
    public override void Update(float Time)
    {
        FGB_MoveController.MoveMap(GetObject(), Time);

    }


}
public class FGB_CheckPointObject : FGB_Object
{
    private GameObject Obj;
    private RaycastHit m_Rayh;
    private bool isTouching = false;
    public override void AddComponent()
    {
        GetObject().tag = "CheckPoint";
    }
    public override void Update(float Time)
    {

    }


}



public static class FGB_ObjectsFactory
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
        obj.AddComponent();
        return obj;
    }
}


