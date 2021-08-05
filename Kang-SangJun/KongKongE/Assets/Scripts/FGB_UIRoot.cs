using UnityEngine;

public class FGB_UIRoot : MonoBehaviour
{
    public static Transform canvas;

    private void Awake()
    {
        canvas = transform.Find("Canvas");
        Debug.Log(canvas.tag);
    }
}
