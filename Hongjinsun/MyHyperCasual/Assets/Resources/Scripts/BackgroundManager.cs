using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager
{
    //GameObject background;
    //GameObject collisionObject;
    public Dictionary<string, BoxCollider2D> sideCollider;
    enum Side { left, right, center };
    public void Init()
    {
        //background = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Background"));
        //collisionObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/CollisionObject"));
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Background"));
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/CollisionObject"));

        sideCollider = new Dictionary<string, BoxCollider2D>
        {
            { Side.left.ToString(), GameObject.FindGameObjectWithTag("leftside").GetComponent<BoxCollider2D>() },
            { Side.right.ToString(), GameObject.FindGameObjectWithTag("rightside").GetComponent<BoxCollider2D>() },
            { Side.center.ToString(), GameObject.FindGameObjectWithTag("centerside").GetComponent<BoxCollider2D>() }
        };
    }

    public BoxCollider2D getCollider(string sidename)
    {
        return sideCollider[sidename];
    }
}

