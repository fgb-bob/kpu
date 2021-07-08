using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    PlayerController pc;
    int moveState;

    private int id;
    public void setPhysics(GameObject obj)
    {
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().freezeRotation = true;
        Debug.Log("ridigbody 컴포넌트 추가");
        obj.AddComponent<CapsuleCollider2D>();
        obj.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, -0.5f);
        obj.GetComponent<CapsuleCollider2D>().size = new Vector2(1, 1.4f);
        obj.AddComponent<BoxCollider2D>();
        obj.GetComponent<BoxCollider2D>().offset = new Vector2(0.7f, -0.5f);
        obj.GetComponent<BoxCollider2D>().size = new Vector2(1, 1.4f);
        obj.GetComponent<BoxCollider2D>().isTrigger = true;
        Debug.Log("collider 컴포넌트 추가");
    }

    public void setPC(PlayerController setPC)
    {
        pc = setPC;
    }

    public PlayerController getPC()
    {
        return pc;
    }

    public void setMoveState(int n)
    {
        moveState = n;
    }

    public int getMoveState()
    {
        return moveState;
    }

}
