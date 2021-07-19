using UnityEngine;
using UnityEngine.UI;

public class MyButtonManager
{
    MyControlButton m_controlButton;
    MyUIButton m_uiButton;

    public void Init(MyPlayerController playerController, MyUIManager uiManager)
    {
        m_controlButton = new MyControlButton();
        m_controlButton.Init(playerController);

        m_uiButton = new MyUIButton();
        m_uiButton.Init(uiManager);
    }
}