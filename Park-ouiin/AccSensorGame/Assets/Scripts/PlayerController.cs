using UnityEngine;

public class PlayerController
{
    float speed;        
    GameObject playerGameObject;
    Animator animator;
    Rigidbody2D rig;
    Vector3 dir;

    // �÷��̾� ��Ʈ�ѷ� �ʱ�ȭ
    public void Init(float speed)
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        animator = playerGameObject.GetComponent<Animator>();
        rig = playerGameObject.GetComponent<Rigidbody2D>();
        this.speed = speed;
    }

    // �÷��̾ ��� �ٶ󺸴� �� Ȯ�� �Լ�
    void Checkdir(Vector3 dir)
    {
        if (dir.x >= 0)
            animator.SetBool("dir", true);
        else
            animator.SetBool("dir", false);
    }

    // �÷��̾� �̵� �Լ�
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
        // ȭ�� ���� ����� ���ϰ� ����
        Utility.NoScreenRangeOut(playerGameObject);
    }
}
