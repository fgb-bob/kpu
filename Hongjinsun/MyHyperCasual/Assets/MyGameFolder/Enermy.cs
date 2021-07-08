using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy
{
    EnermyController ec;
    public void setPhysics(GameObject obj)
    {
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().freezeRotation = true;
        obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Debug.Log("�� ridigbody ������Ʈ �߰�");
        obj.AddComponent<CapsuleCollider2D>();
        obj.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.2f);
        obj.GetComponent<CapsuleCollider2D>().size = new Vector2(0.8f, 2.8f);
        obj.GetComponent<CapsuleCollider2D>().isTrigger = true;
        Debug.Log("�� collider ������Ʈ �߰�");
    }
    public void setEC(EnermyController setEC)
    {
        ec = setEC;
    }

    public EnermyController getEC()
    {
        return ec;
    }
}
