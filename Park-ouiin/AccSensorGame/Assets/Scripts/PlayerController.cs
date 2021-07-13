using UnityEngine;

public class PlayerController
{
    float speed;        
    GameObject playerGameObject;
    Animator animator;
    Rigidbody2D rig;
    Vector3 dir;

    // 플레이어 컨트롤러 초기화
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

    // 플레이어 이동 함수
    public void Move()
    {
        dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;

        Checkdir(dir);

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        rig.velocity = new Vector2(dir.x * speed, dir.y * speed);
        // 화면 밖을 벗어나지 못하게 설정
        Utility.NoScreenRangeOut(playerGameObject);
    }
}
