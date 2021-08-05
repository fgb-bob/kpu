using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_Scene
{
    public FGB_ObjectManager m_ObjectManager = new FGB_ObjectManager();


    public void Init()
    {
        FGB_UIManager.SetCanvas();
        FGB_UIManager.TitleInit();

        m_ObjectManager.Init();

    }


    // 맵의 오브젝트 위치 정보 전달.

    public void Update(float Time)
    {
        m_ObjectManager.Update(Time);

    }


}

