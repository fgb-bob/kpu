using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle Data", menuName = "Scriptable Object/Obstacle Data", order = int.MaxValue)]
public class ObstacleData : ScriptableObject
{
    public int maxObstacle;
    public int obstacleTypeDelay;
    public float pos_x;
    public float pos_y;
}
