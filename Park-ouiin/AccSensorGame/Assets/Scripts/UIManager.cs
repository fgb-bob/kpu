using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameObject uiRoot;

    private void Awake()
    {
        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

        TitleUI.MakeTitle();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void OpenUI(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public static void CloseUI(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
