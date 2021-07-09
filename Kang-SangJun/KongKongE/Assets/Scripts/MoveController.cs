using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController
{
    private Rigidbody rigid;
    public void PlayerMove(GameObject Obj)
    {
        rigid = Obj.GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.W))
        {
           // Obj.transform.Rotate(new Vector3(0.5f, 0, 0));
            Obj.transform.eulerAngles += new Vector3(1, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
           // Obj.transform.Rotate(new Vector3(-0.5f, 0, 0));
            Obj.transform.eulerAngles += new Vector3(-1, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            Obj.transform.eulerAngles += new Vector3(0, 0, 1);

        }
        if (Input.GetKey(KeyCode.D))
        {
            Obj.transform.eulerAngles += new Vector3(0, 0, -1);

        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rigid.AddRelativeForce(Vector3.up * 10, ForceMode.Impulse);
        //}
 
    }
    public void PlayerJump(GameObject Obj)
    {
        rigid = Obj.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.AddRelativeForce(Vector3.up*10, ForceMode.Impulse);
    }

    private   void MoveMap(GameObject Obj)
    {
       
    }
    private   void MouseMove()
    {
        
    }
}
 
