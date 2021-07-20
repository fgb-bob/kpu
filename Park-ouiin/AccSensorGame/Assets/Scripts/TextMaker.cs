using UnityEngine;
using UnityEngine.UI;

public class TextMaker
{
    public void SetText(GameObject gameObject, string setText)
    {
        gameObject.GetComponent<Text>().text = setText;
    }
}
