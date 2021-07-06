using UnityEngine;
using UnityEngine.SceneManagement;

public class UIRoot : MonoBehaviour
{
    public static Transform titleCanvas, maingameCanvas;

    private void Awake()
    {
        titleCanvas = transform.Find("TitleCanvas");
        maingameCanvas = transform.Find("MaingameCanvas");
    }
}
