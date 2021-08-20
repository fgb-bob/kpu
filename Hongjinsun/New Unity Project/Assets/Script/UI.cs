using UnityEngine;
using UnityEngine.UI;

public class UI
{ 
        Button m_button;
   public void Init()
    {
        m_button = GameObject.Find("Button").GetComponent<Button>();
        m_button.onClick.AddListener(() => OnClickJumpBTN());
    }

    void OnClickJumpBTN()
    {
        Debug.Log("OnClickJumpBTN호출");
        EventTrigger.Do(new JumpEvent());
    }
}
