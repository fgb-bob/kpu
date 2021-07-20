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


    // ���� ������Ʈ ��ġ ���� ����.

    public void Update()
    {
        ObjectManager.Update();
        
    }
    

}

