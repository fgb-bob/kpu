using UnityEngine;

public class Obstacle
{
    
    public static void Move(GameObject gameObject, Vector3 vector3)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = vector3;
    }
}
