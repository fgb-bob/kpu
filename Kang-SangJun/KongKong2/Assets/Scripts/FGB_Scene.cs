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


    // ���� ������Ʈ ��ġ ���� ����.

    public void Update()
    {
        FGB_ObjectManager.Update();
        
    }
    

}

