using UnityEngine;
using UnityEngine.UI;

public class MyControlButton
{
    Button m_rightButton;
    Button m_leftButton;

    public void Init(MyPlayerController playerController)
    {
        m_rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        m_leftButton = GameObject.Find("LeftButton").GetComponent<Button>();

        m_rightButton.onClick.AddListener(() => RightBTN(playerController));
        m_leftButton.onClick.AddListener(() => LeftBTN(playerController));
    }

    void RightBTN(MyPlayerController playerController)
    {

        //if (playerController.player.rigid.velocity == Vector2.zero)
        //    playerController.MoveToRight();
    }

    void LeftBTN(MyPlayerController playerController)
    {
        //if (playerController.player.rigid.velocity == Vector2.zero)
        //    playerController.MoveToLeft();
    }
}
