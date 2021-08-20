using System;
using UnityEngine;

public class MyPlayerController
{
    public MyPlayer player;
    int m_score;
    public bool isButtonOnClick;
    public bool isAttack;
    public bool isReturn;
    public bool isMove;
    MyEventTrigger myEvent;
    Animator m_attackAnim;


    public void Init()
    {
        m_score = 0;
        player = new MyPlayer();
        player.Init();
        isButtonOnClick = false;
        isAttack = false;
        isReturn = false;
        isMove = true;
        myEvent = new MyEventTrigger();

        m_attackAnim = player.obj.GetComponent<Animator>();
    }

    public int Score
    {
        get { return m_score; }
        set
        {
            m_score = Mathf.Clamp(value, 0, 100);
            //MyEventManager.Instance.PostNotification(EVENT_TYPE.SCORE_INCREASE, player.obj, m_score);
        }
    }

    void OnScoreChange(GameObject Score, int NewScore)
    {
        if (this.player.obj.GetInstanceID() != Score.GetInstanceID())
            return;

        Debug.Log("Object: " + this.player.obj.name + " Score is : " + NewScore.ToString());
    }
    private void button_Clicked(object sender, EventArgs e)
    {
        Debug.Log("오른쪽 버튼 클릭");
        player.obj.transform.Translate(1, 0, 0);
        //throw new NotImplementedException();
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow) && player.rigid.velocity == Vector2.zero)
        //{
        //    myEvent.Clicked += new MyEventHandler(button_Clicked);
        //    myEvent.OnClicked();
        //    myEvent.Clicked -= new MyEventHandler(button_Clicked);

        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("점수 + 1");
        //    Score += 1;
        //}

        if (Input.GetKeyDown(KeyCode.RightArrow) && player.rigid.velocity == Vector2.zero)
            Move();

        if (player.obj.transform.position.x >= 15)
        {
            isMove = false;
            player.rigid.velocity = Vector2.zero;
            player.rigid.AddForce(-player.velocity, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Block(true);
            //m_attackAnim.SetBool("block", true);
            //player.box.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Block(false);
            //m_attackAnim.SetBool("block", false);
            //player.box.enabled = false;
        }


        if (isReturn == true)
        {
            player.rigid.AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);
            isReturn = false;
        }
    }

    void Move()
    {
        Debug.Log("Move호출");
        float deltaTime = Time.deltaTime;
        player.rigid.AddForce(player.velocity, ForceMode2D.Impulse);
    }

    void Attack()
    {
        Debug.Log("공격!");
        m_attackAnim.SetTrigger("attack");
        player.polygon.enabled = true;
    }

    void Block(bool state)
    {
        m_attackAnim.SetBool("block", state);
        player.box.enabled = state;
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
