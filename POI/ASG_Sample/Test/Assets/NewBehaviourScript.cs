using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    Animator animator;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        animator = GetComponent<Animator>();
        dir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;

        if (Input.acceleration.x >= 0)
            animator.SetBool("WhereLook", false);
        else
            animator.SetBool("WhereLook", true);


        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        rig.velocity = new Vector2(dir.x * speed, dir.y * speed);

        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        if (worldpos.y > 1f) worldpos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
