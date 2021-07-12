using UnityEngine;

public class PlayerController
{
    static Rigidbody2D rigid;
    static BoxCollider2D boxCollider;
    public Vector2 myVelocity = new Vector2(5, 0);

    public void init(GameObject player)
    {
        rigid = player.GetComponent<Rigidbody2D>();
        boxCollider = player.GetComponent<BoxCollider2D>();
    }

    public void move(GameObject player)
    {
        if ( Input.GetKeyDown(KeyCode.RightArrow) && rigid.velocity.x == 0)
        {
            boxCollider.enabled = true;
            Debug.Log("오른쪽!");
            player.transform.localScale = new Vector2(1, 1);
            rigid.AddForce(myVelocity * 1, ForceMode2D.Impulse);
            rigid.velocity = myVelocity * 2;
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && rigid.velocity.x == 0)
        {
            boxCollider.enabled = true;
            Debug.Log("왼쪽!");
            player.transform.localScale = new Vector2(-1, 1);
            rigid.AddForce(myVelocity * -1, ForceMode2D.Impulse);
            rigid.velocity = myVelocity * -2;
        }

    }

    public void OnTriggerEnter2DToSide(Collider2D other)
    {
        if (other.transform.position.x > 0)
        {
            rigid.velocity = myVelocity * 0;
            rigid.AddForce(myVelocity * -1, ForceMode2D.Impulse);
            rigid.velocity = myVelocity * -2;
        }

        else if (other.transform.position.x < 0)
        {
            rigid.velocity = myVelocity * 0;
            rigid.AddForce(myVelocity * 1, ForceMode2D.Impulse);
            rigid.velocity = myVelocity * 2;
        }
        else
        {
            rigid.transform.position = new Vector2(0, -2.89f);
            rigid.velocity = myVelocity * 0;
            boxCollider.enabled = false;    // 멈추면 공격을 못해......
        }

        //if ( other.gameObject.tag == "rightside" || other.gameObject.tag == "enermy" )
        //{
        //    rigid.velocity = myVelocity * 0;
        //    rigid.AddForce(myVelocity * -1, ForceMode2D.Impulse);
        //    rigid.velocity = myVelocity * -2;
        //}
        //else if (other.gameObject.tag == "leftside" || other.gameObject.tag == "enermy")
        //{
        //    rigid.velocity = myVelocity * 0;
        //    rigid.AddForce(myVelocity * 1, ForceMode2D.Impulse);
        //    rigid.velocity = myVelocity * 2;
        //}
        //else if (other.gameObject.tag == "centerside")
        //{
        //    rigid.velocity = myVelocity * 0;
        //    Debug.Log(rigid.velocity);
        //}

    }
}
