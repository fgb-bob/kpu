using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_MoveController
{
    private static Rigidbody rigid;
    private static bool DirChange;
    private static float DirChangeCount = 0;
    public static void PlayerMove(GameObject Obj, float Time)
    {
        rigid = Obj.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.W))
        {
            Obj.transform.eulerAngles += new Vector3(100f, 0, 0) * Time;

        }
        if (Input.GetKey(KeyCode.S))
        {
            Obj.transform.eulerAngles += new Vector3(-100f, 0, 0) * Time;

        }
        if (Input.GetKey(KeyCode.A))
        {
            Obj.transform.eulerAngles += new Vector3(0, 0, 100) * Time;

        }
        if (Input.GetKey(KeyCode.D))
        {
            Obj.transform.eulerAngles += new Vector3(0, 0, -100f) * Time;

        }
    }
    public static void PlayerJump(GameObject Obj)
    {
        rigid = Obj.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.AddRelativeForce(Vector3.up * 10, ForceMode.Impulse);
    }

    public static void MoveMap(GameObject Obj , float Time)
    {
        rigid = Obj.GetComponent<Rigidbody>();

        if (DirChange)
        {
            Obj.transform.position += new Vector3(-10, 0, 0) * Time;
        }
        else 
        {
            Obj.transform.position += new Vector3(10, 0, 0) * Time;

        }
        if (DirChangeCount > 4)
        {
            DirChangeCount = 0;
            DirChange = !DirChange;
            rigid.velocity = Vector3.zero;

        }
        else DirChangeCount += Time;


    }

   

    private static void RandDir(GameObject Obj)
    {
    }
    private static void MouseMove()
    {

    }
}

