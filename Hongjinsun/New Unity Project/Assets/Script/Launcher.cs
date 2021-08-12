using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    Character c;
    EventTrigger et;
    UI ui;
    // Start is called before the first frame update
    void Start()
    {      
        et = new EventTrigger();
        et.Init();

        c = new Character();
        c.Init();

        ui = new UI();
        ui.Init();
    }

    // Update is called once per frame
    void Update()
    {
        c.Update();
        Input.GetKeyDown(KeyCode.A);
    }
}
