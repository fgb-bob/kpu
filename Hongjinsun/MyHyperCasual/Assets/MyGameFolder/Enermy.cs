using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy
{
    EnermyController ec;
    public GameObject enermy;
    

    int spawnInt;

    public void Init()
    {
        enermy = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Enermy"));
        ec = new EnermyController();
        spawnInt = Random.Range(0, 20);

        if (spawnInt % 2 == 0)
            enermy.transform.position = new Vector2(-10, -2.89f);
        else
            enermy.transform.position = new Vector2(10, -2.89f);

        enermy.AddComponent<Rigidbody2D>();
        enermy.GetComponent<Rigidbody2D>().freezeRotation = true;
        enermy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        enermy.AddComponent<CapsuleCollider2D>();
        enermy.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.2f);
        enermy.GetComponent<CapsuleCollider2D>().size = new Vector2(0.8f, 2.8f);
        enermy.GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    public EnermyController getEC()
    {
        return ec;
    }

    public GameObject getEnermy()
    {
        return enermy;
    }
    public void DestroyObj()
    {
        GameObject.Destroy(enermy);
    }
}
