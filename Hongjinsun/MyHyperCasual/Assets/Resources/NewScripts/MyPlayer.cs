using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer
{
    public GameObject obj;
    public Rigidbody2D rigid;
    public CapsuleCollider2D capsule;
    public BoxCollider2D box;
    public Vector2 velocity;
    int m_moveState;

    public void Init()
    {
        obj = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Player, null);
        SetPhysics();
        velocity = new Vector2(20, 0);
        m_moveState = 0;
    }

    public void SetPhysics()
    {
        obj.AddComponent<Rigidbody2D>();
        rigid = obj.GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;

        obj.AddComponent<CapsuleCollider2D>();
        capsule = obj.GetComponent<CapsuleCollider2D>();
        capsule.offset = new Vector2(0, -0.5f);
        capsule.size = new Vector2(1, 1.4f);

        obj.AddComponent<BoxCollider2D>();
        box = obj.GetComponent<BoxCollider2D>();
        box.offset = new Vector2(0.7f, -0.5f);
        box.size = new Vector2(1, 1.4f);
        box.isTrigger = true;
        box.enabled = false;
    }

    public void ResetData()
    {
        obj.transform.localScale = new Vector2(1, 1);
        obj.SetActive(true);
        obj.transform.position = new Vector2(0, -2.89f);
        rigid.velocity = Vector2.zero;
        m_moveState = 0;
    }

    public void SetMoveState(int n)
    {
        m_moveState = n;
    }

    public int GetMoveState()
    {
        return m_moveState;
    }
}