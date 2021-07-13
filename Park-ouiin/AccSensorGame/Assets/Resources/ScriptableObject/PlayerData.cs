using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = int.MaxValue)]
public class PlayerData : ScriptableObject
{
    public int life;
    public int maxLife;
    public float speed;
    public int monsterDelay;
}