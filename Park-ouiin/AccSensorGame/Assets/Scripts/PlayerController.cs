using UnityEngine;

public class PlayerController
{
    public enum GameType { DODGE, UP };
    GameType type = GameType.DODGE;

    float speed;
    GameObject playerGameObject;
    GameObject[] temp;
    GameObject gameObject;
    Animator animator;
    Rigidbody2D rig;
    Vector2 dir;

    float lifetime;

    public float GetLifetime()
    {
        return lifetime;
    }

    public void SetLifetime(float lifetime)
    {
        this.lifetime = lifetime;
    }

    public void SetGameType(GameType type)
    {
        this.type = type;
    }

    public void SetGravity(int scale)
    {
        rig.gravityScale = scale;
    }

    public void Init(float speed)
    {
        temp = new GameObject[10];
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        animator = playerGameObject.GetComponent<Animator>();
        rig = playerGameObject.GetComponent<Rigidbody2D>();
        this.speed = speed;
        lifetime = 3;
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
        lifetime -= Time.deltaTime;
        dir = Vector2.zero;
        dir.x = Input.acceleration.x;
        Checkdir(dir);
        if (type == GameType.DODGE)
        {            
            dir.y = Input.acceleration.y * 2;
            if (dir.sqrMagnitude > 1)
                dir.Normalize();
            dir *= Time.deltaTime;            
            rig.velocity = new Vector2(dir.x * speed, dir.y * speed);
            Utility.Judge.NoScreenRangeOut(playerGameObject);
        }
        else
        {
            rig.AddForce(dir, ForceMode2D.Impulse);
            temp = GameObject.FindGameObjectsWithTag("Scaffolding");
            for (int i = 0; i < temp.Length; ++i)
            {
                if (Utility.Judge.Touching(playerGameObject.GetComponent<Collider2D>(), temp[i].GetComponent<Collider2D>()))
                {
                    lifetime = 3;
                    rig.AddForce(Vector2.up * Time.deltaTime * 800, ForceMode2D.Impulse);                    
                    Vector3 tt = temp[i].GetComponent<Transform>().position;
                    tt.y += Random.Range(5, 8);
                    tt.x = Random.Range(-7, 8);
                    temp[i].GetComponent<Transform>().position = tt;                    
                    break;
                }
            }
            if (playerGameObject.GetComponent<Transform>().position.y >= 0)
            {
                gameObject = Utility.Object.FindVisibleGameobjectWithName(gameObject, "Main Camera");
                Vector3 ttt = new Vector3(0, playerGameObject.GetComponent<Transform>().position.y, -10);
                gameObject.GetComponent<Transform>().position = ttt;
                gameObject = Utility.Object.FindInvisibleGameobjectWithName(gameObject, "NoneUIGameObject", "Maingame(Clone)");
                ttt = new Vector3(0, playerGameObject.GetComponent<Transform>().position.y, 0);
                gameObject.GetComponent<Transform>().position = ttt;
            }
            Utility.Judge.NoScreenRangeOut2(playerGameObject);
        }
    }
}
