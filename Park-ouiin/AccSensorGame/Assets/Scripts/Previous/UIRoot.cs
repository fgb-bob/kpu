using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static Transform titleCanvas, maingameCanvas, resultCanvas;

    private void Awake()
    {
        titleCanvas = transform.Find("TitleCanvas");
        maingameCanvas = transform.Find("MaingameCanvas");
        resultCanvas = transform.Find("ResultCanvas");
    }
}
