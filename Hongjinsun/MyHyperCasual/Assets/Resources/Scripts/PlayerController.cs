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
    //    Debug.Log("������!");

    //    player.getPlayerObj().transform.localScale = new Vector2(1, 1);
    //    player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
    //}
    //void LeftMove()
    //{
    //    player.getBoxCollider().enabled = true;
    //    Debug.Log("����!");
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







        // x��ǥ�� 4�̻��̸� �������� ������ ����� ���ƿ�
        if (player.getPlayerObj().transform.position.x >= 4)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getRigidbody().AddForce(-player.myVelocity, ForceMode2D.Impulse);
            player.setMoveState(2);
        }

        // x��ǥ�� -4�� ���������� ������ ����� ���ƿ�
        else if (player.getPlayerObj().transform.position.x <= -4)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
            player.setMoveState(1);
        }

        // �����ʿ��� �������� ���� moveState == 2
        if (player.getMoveState() == 2 && player.getPlayerObj().transform.position.x <= 0)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getPlayerObj().transform.position = new Vector2(0, -2.89f);
            player.setMoveState(0);
        }

        // ���ʿ��� ���������� ���� moveState == 1
        else if (player.getMoveState() == 1 && player.getPlayerObj().transform.position.x >= 0)
        {
            player.getRigidbody().velocity = Vector2.zero;
            player.getPlayerObj().transform.position = new Vector2(0, -2.89f);
            player.setMoveState(0);
        }

        if ( Input.GetKeyDown(KeyCode.RightArrow) && player.getRigidbody().velocity == Vector2.zero)
        {
            player.getBoxCollider().enabled = true;
            Debug.Log("������!");

            player.getPlayerObj().transform.localScale = new Vector2(1, 1);
            player.getRigidbody().AddForce(player.myVelocity, ForceMode2D.Impulse);
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.getRigidbody().velocity == Vector2.zero)
        {
            player.getBoxCollider().enabled = true;
            Debug.Log("����!");
            player.getPlayerObj().transform.localScale = new Vector2(-1, 1);
            player.getRigidbody().AddForce(-player.myVelocity, ForceMode2D.Impulse);
        }

        //colliderManager.OnTriggerEnterToSide();
        //colliderManager.OnTriggerEnterToEnermy();
    }
}

/*
�� �ε�����, x��ǥ�� 4, -4 �� ����� ���ƿ;���.
�����ʿ��� �� �ε����ų� x��ǥ�� 4 �� �������� ���� �ش�.
���ʿ��� �� �ε����ų� x��ǥ�� -4 �� ���������� ���� �ش�.

����� �����ϸ� �������.
 */
