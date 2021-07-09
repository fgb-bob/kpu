using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour , Interface
{
    private Scene GameScene;
    GameObject uiRoot, uiTitle;
    Button SangJunJAngJang123;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

        uiTitle = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.canvas);

        SangJunJAngJang123 = GameObject.Find("Button").GetComponent<Button>();
        SangJunJAngJang123.onClick.AddListener(() => onClick());

        GameScene = new Scene();
        GameScene.init();

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameScene.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("Sibal");
    }

    public void onClick()
    {
        uiTitle.SetActive(false);
        Time.timeScale = 1;

    }
}
