using UnityEngine;

public class PlayerController
{
    public enum GameType { DODGE, UP };
    GameType type = GameType.DODGE;

    float speed;
    GameObject playerGameObject;
    Animator animator;
    Rigidbody2D rig;
    Vector3 dir;

    public void SetGameType(GameType type)
    {
        this.type = type;
    }

    public GameType GetGameType()
    {
        return type;
    }

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
        Debug.Log(dir.y);
        dir = Vector3.zero;

        dir.x = Input.acceleration.x * 2;

        if (type == GameType.DODGE)
        {
            dir.y = Input.acceleration.y * 2;
            if (dir.sqrMagnitude > 1)
                dir.Normalize();
        }
        else
        {
            dir.y = 9.81f;
        }        

        dir *= Time.deltaTime;
        Checkdir(dir);

        if (type == GameType.DODGE)
        {
            rig.velocity = new Vector2(dir.x * speed, dir.y * speed);
            Utility.NoScreenRangeOut(playerGameObject);
        }
        else
        {
            rig.AddForce(dir);            
        }       
    }
}
