using UnityEngine;

public class PlayerController
{
    float speed;
    GameObject playerGameObject;
    Animator animator;
    Rigidbody2D rig;
    Vector3 dir;

    public void Init(float speed)
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        animator = playerGameObject.GetComponent<Animator>();
        rig = playerGameObject.GetComponent<Rigidbody2D>();
        this.speed = speed;
    }

    // 플레이어가 어디를 바라보는 지 확인 함수
    void Checkdir(Vector3 dir)
    {
        if (dir.x >= 0)
            animator.SetBool("dir", true);
        else
            animator.SetBool("dir", false);
    }

    public void Move()
    {
        dir = Vector3.zero;

        dir.x = Input.acceleration.x * 2;
        dir.y = Input.acceleration.y * 2;

        Checkdir(dir);

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        rig.velocity = new Vector2(dir.x * speed, dir.y * speed);

        Utility.NoScreenRangeOut(playerGameObject);
    }
}
