using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FGB_Launcher : MonoBehaviour
{
    private FGB_Scene GameScene;

    // Start is called before the first frame update
    void Start()
    {
        GameScene = new FGB_Scene();
        GameScene.Init();    
    }

    // Update is called once per frame
    void Update()
    {
        GameScene.Update(Time.deltaTime);
    }

}
