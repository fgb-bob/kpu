using UnityEngine;

[CreateAssetMenu(fileName = "Map Data", menuName = "Scriptable Object/Map Data", order = int.MaxValue)]
public class MapData : ScriptableObject
{
    public GameObject indestructible;
    public GameObject destructible;
    [System.Serializable]
    public struct Row
    {
        public int[] col;
    }
    [System.Serializable]
    public struct Array
    {
        public Row[] row;
    }
    public Array[] map;
}