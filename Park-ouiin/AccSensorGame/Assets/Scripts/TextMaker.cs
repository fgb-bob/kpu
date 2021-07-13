using UnityEngine;
using UnityEngine.UI;

public class TextMaker
{
    // 텍스트 변경 함수
    public void SetText(GameObject gameObject, string setText)
    {
        gameObject.GetComponent<Text>().text = setText;
    }
}
