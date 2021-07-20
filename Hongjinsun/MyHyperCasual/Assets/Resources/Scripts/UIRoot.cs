using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static Transform canvas;

    private void Awake()
    {
        canvas = transform.Find("Canvas");
    }
}
