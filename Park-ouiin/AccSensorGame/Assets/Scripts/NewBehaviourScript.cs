using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rig;
    GameObject playerGameObject;
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        rig = playerGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
            dir.x += 0.1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            dir.x -= 0.1f;

        rig.AddForce(dir, ForceMode2D.Impulse);
        //rig.velocity = new Vector2(dir.x, dir.y);
    }
}
