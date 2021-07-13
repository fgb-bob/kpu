using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle Spawn Data", menuName = "Scriptable Object/Obstacle Spawn Data", order = int.MaxValue)]
public class ObstacleSpawnData : ScriptableObject
{
    public int max_pos_x;
    public float min_pos_x;
    public int max_pos_y;
    public float min_pos_y;
    public float max_speed;
    public float min_speed;
}
