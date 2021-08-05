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


    // ���� ������Ʈ ��ġ ���� ����.

    public void Update(float Time)
    {
        m_ObjectManager.Update(Time);

    }


}

