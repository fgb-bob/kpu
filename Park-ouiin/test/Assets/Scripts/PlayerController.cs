using UnityEngine;

public class PlayerController
{
    GameObject playerGameObject;
    Rigidbody2D rig;
    Vector2 dir;

    public void Init()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        rig = playerGameObject.GetComponent<Rigidbody2D>();
        dir = Vector2.zero;
    }

    public void Horizontal()
    {
        dir.x = Input.acceleration.x;
    }

    public void Vertical()
    {
        dir.y = Input.acceleration.y;
    }

    public void Move()
    {
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        dir *= Time.deltaTime;
        //rig.velocity = new Vector2(dir.x * 500, dir.y * 500);
        rig.AddForce(dir, ForceMode2D.Impulse);
    }
}
