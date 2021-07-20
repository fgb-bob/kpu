using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    GameObject player;
    int moveState = 0;
    public Vector2 myVelocity = new Vector2(20, 0);
    int score = 0;

    public void Init()
    {
        player = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));

        player.AddComponent<Rigidbody2D>();
        player.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.AddComponent<CapsuleCollider2D>();
        player.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, -0.5f);
        player.GetComponent<CapsuleCollider2D>().size = new Vector2(1, 1.4f);
        player.AddComponent<BoxCollider2D>();
        player.GetComponent<BoxCollider2D>().offset = new Vector2(0.7f, -0.5f);
        player.GetComponent<BoxCollider2D>().size = new Vector2(1, 1.4f);
        player.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void resetDate()
    {
        player.transform.localScale = new Vector2(1, 1);
        score = 0;
        player.SetActive(true);
        player.transform.position = new Vector2(0, -2.89f);
    }

    public Rigidbody2D getRigidbody()
    {
        return player.GetComponent<Rigidbody2D>();
    }

    public CapsuleCollider2D getCapsuleCollider()
    {
        return player.GetComponent<CapsuleCollider2D>();
    }

    public BoxCollider2D getBoxCollider()
    {
        return player.GetComponent<BoxCollider2D>();
    }

    public void setMoveState(int n)
    {
        moveState = n;
    }

    public int getMoveState()
    {
        return moveState;
    }

    public GameObject getPlayerObj()
    {
        return player;
    }

    public void addScore(int n)
    {
        score += n;
    }

    public int getScore()
    {
        return score;
    }
}
