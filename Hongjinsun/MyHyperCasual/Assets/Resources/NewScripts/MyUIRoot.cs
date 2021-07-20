using UnityEngine;

public class MyUIRoot : MonoBehaviour
{
    public static Transform canvas;

    private void Awake()
    {
        canvas = transform.Find("Canvas");
    }
}