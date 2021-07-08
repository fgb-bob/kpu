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
    public int Map1 = 10;
    public int Map2 = 20;

    public List<int> DataType = new List<int>();
    public List<GameObject> DataPrefabs = new List<GameObject>();
    public Vector3[] DataPos = new Vector3[10];
    public List<Vector3> DataRotation = new List<Vector3>();
    public List<Vector3> DataScale = new List<Vector3>();
}
public class MapDataSource
{
    public string TypeName = "Map";

    public int type;
    public Vector3 Pos;
    public Vector3 Rotate;
    public Vector3 Scale;

}