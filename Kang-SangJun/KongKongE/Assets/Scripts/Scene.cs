using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    public ObjectManager m_ObjectManager;

    private static TitleUI titleUI;
  
    
    public void init()
    {
        ObjectManager.Player_init();
        ObjectManager.Map_init();
        
        UIManager.SetCanvas();


        UIManager.TitleUI_init();

    }


    // 맵의 오브젝트 위치 정보 전달.

    public void Update()
    {
        ObjectManager.Update();
        
    }
    

}

