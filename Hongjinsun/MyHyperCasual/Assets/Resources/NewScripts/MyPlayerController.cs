using UnityEngine;

public class MyPlayerController
{
    public MyPlayer player;
    int m_score;
    public bool isButtonOnClick;
    public bool isAttack;
    public void Init()
    {
        m_score = 0;
        player = new MyPlayer();
        player.Init();
        isButtonOnClick = false;
        isAttack = false;
    }

    public void Update()
    {
        if (player.obj.transform.position.x >= 4 || (player.obj.transform.position.x >= 0 && isAttack == true))
        {
            player.SetMoveState(1);
            ReturnToCenter("fromRight");
            isAttack = false;
        }

        else if (player.obj.transform.position.x <= -4 || (player.obj.transform.position.x <= 0 && isAttack == true))
        {
            player.SetMoveState(1);
            ReturnToCenter("fromLeft");
            isAttack = false;
        }

        if ((player.obj.transform.position.x >= -0.3f && player.obj.transform.position.x <= 0.3f) && player.GetMoveState() != 0)
        {
            player.rigid.velocity = Vector2.zero;
            player.obj.transform.position = new Vector2(0, -2.89f);
            player.SetMoveState(0);
            player.box.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && player.rigid.velocity == Vector2.zero)
            MoveToRight();
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.rigid.velocity == Vector2.zero)
            MoveToLeft();
    }

    public void MoveToRight() 
    {
        player.obj.transform.localScale = new Vector2(1, 1);
        player.box.enabled = true;
        player.rigid.AddForce(player.velocity, ForceMode2D.Impulse);
    }

    public void MoveToLeft() 
    {
        player.obj.transform.localScale = new Vector2(-1, 1);
        player.box.enabled = true;
        player.rigid.AddForce(-player.velocity, ForceMode2D.Impulse);
    }

    void ReturnToCenter(string s)
    {
        player.rigid.velocity = Vector2.zero;
        switch (s)
        {
            case "fromRight":
                player.rigid.AddForce(-player.velocity, ForceMode2D.Impulse);
                break;
            case "fromLeft":
                player.rigid.AddForce(player.velocity, ForceMode2D.Impulse);
                break;
        }
    }

    public void SetScore(int n)
    {
        m_score = n;
    }

    public int GetScore()
    {
        return m_score;
    }
}
