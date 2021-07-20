using UnityEngine;

public class PlayerController
{
    //enum State { MOVE, STOP};

    //State state = new State();

    Player player;
    ColliderManager colliderManager;

    public void Init(Player player)
    {
        this.player = player;
        //state = State.STOP;
    }

    public Player getPlayer()
    {
        return player;
    }

    public void setColliderManager(ColliderManager colliderManager)
    {
        this.colliderManager = colliderManager;
    }

    //void RightMove()
    //{
    //    player.getBoxCollider().enabled = true;
    //    Debug.Log("오른쪽!");

    //    player.getPlayerObj().transform.localScale = new Vector2(1, 1);
    //    player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
    //}
    //void LeftMove()
    //{
    //    player.getBoxCollider().enabled = true;
    //    Debug.Log("왼쪽!");
    //    player.getPlayerObj().transform.localScale = new Vector2(-1, 1);
    //    player.getRigidbody().AddForce(-player.myVelocity, ForceMode2D.Impulse);
    //}

    public void move()
    {   
        if (player.getRigidbody().velocity == Vector2.zero)
            player.getBoxCollider().enabled = false;

        //Debug.Log(player.getPlayerObj().transform.position);

        //if (Input.GetKeyDown(KeyCode.RightArrow) && state == State.STOP)
        //{
        //    RightMove();
        //    state = State.MOVE;
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) && state == State.STOP)
        //{
        //    LeftMove();
        //    state = State.MOVE;
        //}
        //else if (state == State.MOVE)
        //{ 
        //    if(player.getPlayerObj().transform.position.x >= 4 || )
        //}







        // x좌표가 4이상이면 왼쪽으로 움직여 가운데로 돌아옴
        if (player.getPlayerObj().transform.position.x >= 4)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getRigidbody().AddForce(-player.myVelocity, ForceMode2D.Impulse);
            player.setMoveState(2);
        }

        // x좌표가 -4면 오른쪽으로 움직여 가운데로 돌아옴
        else if (player.getPlayerObj().transform.position.x <= -4)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
            player.setMoveState(1);
        }

        // 오른쪽에서 왼쪽으로 오는 moveState == 2
        if (player.getMoveState() == 2 && player.getPlayerObj().transform.position.x <= 0)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getPlayerObj().transform.position = new Vector2(0, -2.89f);
            player.setMoveState(0);
        }

        // 왼쪽에서 오른쪽으로 오는 moveState == 1
        else if (player.getMoveState() == 1 && player.getPlayerObj().transform.position.x >= 0)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getPlayerObj().transform.position = new Vector2(0, -2.89f);
            player.setMoveState(0);
        }

        if ( Input.GetKeyDown(KeyCode.RightArrow) && player.getRigidbody().velocity == Vector2.zero)
        {
            player.getBoxCollider().enabled = true;
            Debug.Log("오른쪽!");

            player.getPlayerObj().transform.localScale = new Vector2(1, 1);
            player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.getRigidbody().velocity == Vector2.zero)
        {
            player.getBoxCollider().enabled = true;
            Debug.Log("왼쪽!");
            player.getPlayerObj().transform.localScale = new Vector2(-1, 1);
            player.getRigidbody().AddForce(-player.myVelocity, ForceMode2D.Impulse);
        }

        //colliderManager.OnTriggerEnterToSide();
        //colliderManager.OnTriggerEnterToEnermy();
    }
}

/*
적 부딪히면, x좌표가 4, -4 면 가운데로 돌아와야함.
오른쪽에서 적 부딪히거나 x좌표가 4 면 왼쪽으로 힘을 준다.
왼쪽에서 적 부딪히거나 x좌표가 -4 면 오른쪽으로 힘을 준다.

가운데에 도착하면 멈춰야해.
 */
