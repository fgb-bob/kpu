using UnityEngine;

public class Launcher : MonoBehaviour
{
    SceneManager sceneManager;
    
    private void Start()
    {
        sceneManager = new SceneManager();
        sceneManager.Init();
        Debug.Log("Ω√¿€!");
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        sceneManager.sceneUpdate();
    }
}