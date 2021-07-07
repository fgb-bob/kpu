using UnityEngine;

public class CharacterController
{
    public float speed;
    public Rigidbody2D rig;
    Animator animator;
    Vector3 dir;

    public void Init()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        animator = temp.GetComponent<Animator>();
        speed = 500f;
    }

    public void Checkdir(Vector3 dir)
    {
        if (dir.x >= 0)
            animator.SetBool("dir", true);
        else
            animator.SetBool("dir", false);
    }

    public void Move()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;

        Checkdir(dir);

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        rig = temp.GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(dir.x * speed, dir.y * speed);
        Vector3 worldpos = Camera.main.WorldToViewportPoint(temp.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        if (worldpos.y > 1f) worldpos.y = 1f;

        temp.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
