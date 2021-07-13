using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static Transform rootUI, titleCanvas, maingameCanvas, resultCanvas;

    private void Awake()
    {
        rootUI = transform.Find("UIRoot");
        titleCanvas = transform.Find("TitleCanvas");
        maingameCanvas = transform.Find("MaingameCanvas");
        resultCanvas = transform.Find("ResultCanvas");
    }
}
