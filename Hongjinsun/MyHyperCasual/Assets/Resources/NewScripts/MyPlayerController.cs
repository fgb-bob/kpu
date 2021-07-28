using System;
using UnityEngine;

public class MyPlayerController : MyEventTrigger
{
    public MyPlayer player;
    int m_score;
    public bool isButtonOnClick;
    public bool isAttack;

    MyEventTrigger myEvent;
    EventArgs eventArgs;

    public void Init()
    {
        m_score = 0;
        player = new MyPlayer();
        player.Init();
        isButtonOnClick = false;
        isAttack = false;

        myEvent = new MyEventTrigger();
        myEvent.Clicked += new EventHandler(button_Clicked);
    }

    private void button_Clicked(object sender, EventArgs e)
    {
        Debug.Log("오른쪽 버튼 클릭");
        //throw new NotImplementedException();
    }

    public void c_MyEvent(object sender, MyEventTrigger.MyEventArgs args)
    {
        Debug.Log("c_MyEvent - " + sender + ", " + args);
    }
    public void Update()
    {

        //if (player.obj.transform.position.x >= 4 || (player.obj.transform.position.x >= 0 && isAttack == true))
        //{
        //    player.SetMoveState(1);
        //    ReturnToCenter("fromRight");
        //    isAttack = false;
        //}

        //else if (player.obj.transform.position.x <= -4 || (player.obj.transform.position.x <= 0 && isAttack == true))
        //{
        //    player.SetMoveState(1);
        //    ReturnToCenter("fromLeft");
        //    isAttack = false;
        //}

        //if ((player.obj.transform.position.x >= -0.3f && player.obj.transform.position.x <= 0.3f) && player.GetMoveState() != 0)
        //{
        //    player.rigid.velocity = Vector2.zero;
        //    player.obj.transform.position = new Vector2(0, -2.99f);
        //    player.SetMoveState(0);
        //    player.box.enabled = false;
        //}

        //if (Input.GetKeyDown(KeyCode.RightArrow) && player.rigid.velocity == Vector2.zero)
        //    MoveToRight();
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.rigid.velocity == Vector2.zero)
        //    MoveToLeft();


        if (Input.GetKeyDown(KeyCode.RightArrow) && player.rigid.velocity == Vector2.zero)
        {
            eventArgs = new EventArgs();

            
            OnClicked(eventArgs);

            //OnEvent(EventType.KeyDown, "RightArrow");

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //OnEvent(EventType.KeyDown, "AddScore");
        }
    }

    public override void OnClicked(EventArgs e)
    {
        base.OnClicked(e);
    }


    void Move()
    {
        player.rigid.AddForce(new Vector2(20, 0), ForceMode2D.Impulse);

        float deltaTime = Time.deltaTime;
    }


    void Defence()
    {
        
    }

    //public void MoveToRight()
    //{
    //    player.obj.transform.localScale = new Vector2(1, 1);
    //    player.box.enabled = true;
    //    player.rigid.AddForce(player.velocity, ForceMode2D.Impulse);
    //}

    //public void MoveToLeft()
    //{
    //    player.obj.transform.localScale = new Vector2(-1, 1);
    //    player.box.enabled = true;
    //    player.rigid.AddForce(-player.velocity, ForceMode2D.Impulse);
    //}

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

    //public void OnEvent(EventType eventType, string eventParameter)
    //{
    //    Debug.Log("OnEvent 호출");
    //    switch (eventParameter) {
    //        case "RightArrow":
    //            //myEvent.Move();
    //            player.obj.transform.Translate(1, 0, 0);
    //            break;
    //        case "AddScore":
    //            ++m_score;
    //            //myEvent.AddScore(m_score);
    //            break;
    //        default:
    //            throw new NotImplementedException();
    //    }
    //}
}
