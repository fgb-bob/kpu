using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static Transform rootUI, noneUIGameObject;

    private void Awake()
    {
        rootUI = transform.Find("UIRoot");
        noneUIGameObject = transform.Find("NoneUIGameObject");        
    }
}
