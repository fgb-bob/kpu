using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy
{
    GameObject enermy;
    float speed; // 0.01 ~ 0.2

    public void Init()
    {
        enermy = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enermy"));

        enermy.AddComponent<Rigidbody2D>();
        enermy.GetComponent<Rigidbody2D>().freezeRotation = true;
        enermy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        enermy.AddComponent<CapsuleCollider2D>();
        enermy.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.2f);
        enermy.GetComponent<CapsuleCollider2D>().size = new Vector2(0.8f, 2.8f);
        enermy.GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    public GameObject getEnermyObj()
    {
        return enermy;
    }

    public CapsuleCollider2D getCapsuleCollider()
    {
        return enermy.GetComponent<CapsuleCollider2D>();
    }

    public void DestroyObj()
    {
        GameObject.Destroy(enermy);
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public float getSpeed()
    {
        return speed;
    }
}
