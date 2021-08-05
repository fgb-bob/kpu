using System;
using UnityEngine;

public class MyPlayerController : IMyListener
{
    public MyPlayer player;
    int m_score;
    public bool isButtonOnClick;
    public bool isAttack;

    MyEventTrigger myEvent;

    public void Init()
    {
        m_score = 0;
        player = new MyPlayer();
        player.Init();
        isButtonOnClick = false;
        isAttack = false;

        myEvent = new MyEventTrigger();

        try {
            MyEventManager.Instance.AddListener(EVENT_TYPE.SCORE_INCREASE, this);
        } catch(NullReferenceException) {
            Debug.Log("안돼!!");
        }
    }

    private void button_Clicked(object sender, EventArgs e)
    {
        Debug.Log("오른쪽 버튼 클릭");
        //player.obj.transform.Translate(1, 0, 0);
        player.rigid.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
        //throw new NotImplementedException();
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
            myEvent.Clicked += new MyEventHandler(button_Clicked);
            myEvent.OnClicked();
            myEvent.Clicked -= new MyEventHandler(button_Clicked);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("점수 + 1");
            Score += 1;
        }
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

    //void ReturnToCenter(string s)
    //{
    //    player.rigid.velocity = Vector2.zero;
    //    switch (s)
    //    {
    //        case "fromRight":
    //            player.rigid.AddForce(-player.velocity, ForceMode2D.Impulse);
    //            break;
    //        case "fromLeft":
    //            player.rigid.AddForce(player.velocity, ForceMode2D.Impulse);
    //            break;
    //    }
    //}

    public void SetScore(int n)
    {
        m_score = n;
    }

    public int GetScore()
    {
        return m_score;
    }

    public int Score
    {
        get { return m_score; }
        set
        {
            m_score = Mathf.Clamp(value, 0, 100);
            MyEventManager.Instance.PostNotification(EVENT_TYPE.SCORE_INCREASE, player.obj, m_score);
        }
    }

    void OnScoreChange(GameObject Score, int NewScore)
    {
        if (this.player.obj.GetInstanceID() != Score.GetInstanceID())
            return;

        Debug.Log("Object: " + this.player.obj.name + " Score is : " + NewScore.ToString());
    }

    public void OnEvent(EVENT_TYPE Event_Type, GameObject Sender, object Param = null)
    {
        switch(Event_Type)
        {
            case EVENT_TYPE.SCORE_INCREASE:
                OnScoreChange(Sender, (int)Param);
                break;
            default:
                throw new NotImplementedException();
        }
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
