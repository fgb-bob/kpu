using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player" , menuName = "Data/Player")]
public class FGB_Data : ScriptableObject
{
    public string TypeName = "Player";
    public Vector3 Pos = new Vector3(0,10,0);
    public Vector3 Rotate = new Vector3(0, 10, 0);
    public Vector3 Scale = new Vector3(0, 10, 0);
}

[CreateAssetMenu(fileName = "Map", menuName = "Data/Map")]

public class FGB_MapData : ScriptableObject
{
    public static int M1_Count = 10;
    public static int M2_Count= 20;

    public int M1_MaxCount = 10;
    public int M2_MaxCount = 20;

    public ObjectType[] M1_ObjType = new ObjectType[M1_Count];
    public PrefabsType[] M1_PreType = new PrefabsType[M1_Count];
    public GameObject[] DataPrefabs = new GameObject[M1_Count];
    public Vector3[] M1_DataPos = new Vector3[M1_Count];
    public Vector3[] M1_DataRotation = new Vector3[M1_Count];
    public Vector3[] M1_DataScale = new Vector3[M1_Count];

    public ObjectType[] M2_ObjType = new ObjectType[M2_Count];
    public PrefabsType[] M2_PreType = new PrefabsType[M2_Count];
    public Vector3[] M2_DataPos = new Vector3[M2_Count];
    public Vector3[] M2_DataRotation = new Vector3[M2_Count];
    public Vector3[] M2_DataScale = new Vector3[M2_Count];
}

