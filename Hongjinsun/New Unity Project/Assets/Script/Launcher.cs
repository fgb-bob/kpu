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
        c = new Character();
        c.Init();

        et = new EventTrigger();
        et.Init();

        ui = new UI();
        ui.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetKeyDown(KeyCode.A);
    }
}
