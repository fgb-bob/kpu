using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyComponentLauncher : MonoBehaviour
{
    MyGameObject obj;
    // Start is called before the first frame update
    void Start()
    {
       obj  = new MyGameObject(new PlayerInputComponent());
    }

    // Update is called once per frame
    void Update()
    {
        obj.Update();
    }
}
