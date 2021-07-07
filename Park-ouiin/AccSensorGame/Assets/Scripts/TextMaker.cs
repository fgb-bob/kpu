using UnityEngine;
using UnityEngine.UI;

public class TextMaker
{
    public static void SetText(GameObject gameObject, string setText)
    {
        gameObject.GetComponent<Text>().text = setText;        
    }

    public static void SetTextSize(GameObject gameObject, int size)
    {
        gameObject.GetComponent<Text>().fontSize = size;
    }
}
