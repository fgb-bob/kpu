using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class FGB_MoveController
{
    private static Rigidbody rigid;
    public static void PlayerMove(GameObject Obj)
    {
        rigid = Obj.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.W))
        {
           // Obj.transform.Rotate(new Vector3(0.5f, 0, 0));
            Obj.transform.eulerAngles += new Vector3(0.1f, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
           // Obj.transform.Rotate(new Vector3(-0.5f, 0, 0));
            Obj.transform.eulerAngles += new Vector3(-0.1f, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            Obj.transform.eulerAngles += new Vector3(0, 0, 0.1f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            Obj.transform.eulerAngles += new Vector3(0, 0, -0.1f);

        }
    }
    public static void PlayerJump(GameObject Obj)
    {
        rigid = Obj.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.AddRelativeForce(Vector3.up*10, ForceMode.Impulse);
    }

    public static void MoveMap(GameObject Obj)
    {
       // Obj.transform.position += new Vector3(0.01f, 0, 0);
    }
    private static void RandDir(GameObject Obj)
    { 
    }
    private static void MouseMove()
    {
        
    }
}
 
