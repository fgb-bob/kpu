using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_Scene
{
    public FGB_ObjectManager m_ObjectManager;

    private static FGB_TitleUI titleUI;
  
    
    public void Init()
    {
        Share.Util.Data.Init();
        FGB_ObjectManager.PlayerInit();
        FGB_ObjectManager.MapInit();

        FGB_UIManager.SetCanvas();


        FGB_UIManager.TitleUI_Init();

    }


    // 맵의 오브젝트 위치 정보 전달.

    public void Update()
    {
        FGB_ObjectManager.Update();
        
    }
    

}

