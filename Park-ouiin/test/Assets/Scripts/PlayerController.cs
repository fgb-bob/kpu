using UnityEngine;

public class PlayerController
{
    GameObject playerGameObject;
    Rigidbody2D rig;
    Vector2 dir;

    public Rigidbody2D GetRig()
    {
        return rig;
    }

    public void Init()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        rig = playerGameObject.GetComponent<Rigidbody2D>();        
    }

    public void Horizontal()
    {
        dir = Vector2.zero;
        dir.x = Input.acceleration.x;
    }

    public void Vertical()
    {
        dir = Vector2.zero;
        dir.y = Input.acceleration.y;
    }

    public void Move()
    {
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        dir *= Time.deltaTime;
        rig.AddForce(dir, ForceMode2D.Impulse);
        float h = Input.GetAxisRaw("Horizontal");
        rig.AddForce(Vector2.right * (h / 10), ForceMode2D.Impulse);
    }
}
