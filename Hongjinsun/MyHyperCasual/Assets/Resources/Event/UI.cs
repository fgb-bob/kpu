using UnityEngine;
using UnityEngine.UI;

public class UI
{ 
        Button m_button;
   void Init()
    {
        //m_button = ;
        m_button.onClick.AddListener(() => OnClickJumpBTN());
    }

    void OnClickJumpBTN()
    {
        EventTrigger.Do(new JumpEvent());
    }
}
