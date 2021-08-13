using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static Transform rootUI, noneUIGameObject;

    private void Awake()
    {
        rootUI = transform.Find("UIRoot");
        noneUIGameObject = transform.Find("NoneUIGameObject");
        //titleCanvas = transform.Find("TitleCanvas");
        //maingameCanvas = transform.Find("MaingameCanvas");
        //resultCanvas = transform.Find("ResultCanvas");        
    }
}
