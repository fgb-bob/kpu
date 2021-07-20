using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    private Scene GameScene;

    // Start is called before the first frame update
    void Start()
    {
        GameScene = new Scene();

        GameScene.init();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameScene.Update();
    }


}
