using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player" , menuName = "Data/Player")]
public class Data : ScriptableObject
{
    public string TypeName = "Player";
    public Vector3 Pos = new Vector3(0,10,0);
    public Vector3 Rotate = new Vector3(0, 10, 0);
    public Vector3 Scale = new Vector3(0, 10, 0);
}

[CreateAssetMenu(fileName = "Map", menuName = "Data/Map")]

public class MapData : ScriptableObject
{
    public static int Map1 = 10;
    public static int Map2 = 20;

    public int M1_Count = 10;
    public int[] DataType = new int[Map1];
    public GameObject[] DataPrefabs = new GameObject[Map1];
    public Vector3[] M1_DataPos = new Vector3[Map1];
    public Vector3[] M1_DataRotation = new Vector3[Map1];
    public Vector3[] M1_DataScale = new Vector3[Map1];

    public GameObject C1_DataPrefabs;
    public Vector3 C1_DataPos;
    public Vector3 C1_DataRotation;
    public Vector3 C1_DataScale;

    public int[] M2_DataType = new int[Map1];
    public GameObject[] M2_DataPrefabs = new GameObject[Map1];
    public Vector3[] M2_DataPos = new Vector3[Map1];
    public Vector3[] M2_DataRotation = new Vector3[Map1];
    public Vector3[] M2_DataScale = new Vector3[Map1];
}
public class MapDataSource
{
    public string TypeName = "Map";

    public int type;
    public Vector3 Pos;
    public Vector3 Rotate;
    public Vector3 Scale;

}