using UnityEngine;
using UnityEngine.UI;

public class TextMaker
{
    // �ؽ�Ʈ ���� �Լ�
    public void SetText(GameObject gameObject, string setText)
    {
        gameObject.GetComponent<Text>().text = setText;
    }
}
