using UnityEngine;
using UnityEngine.UI;

public class NTextMaker
{
    public void SetText(GameObject gameObject, string setText)
    {
        gameObject.GetComponent<Text>().text = setText;
    }
}
