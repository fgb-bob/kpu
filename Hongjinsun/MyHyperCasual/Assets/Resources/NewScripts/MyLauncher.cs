using UnityEngine;

public class MyLauncher : MonoBehaviour
{
    MySceneManager m_mySceneManager;
    private void Awake()
    {
        m_mySceneManager = new MySceneManager();
        m_mySceneManager.Init();

    }
    private void Update()
    {
        m_mySceneManager.Update();
       
    }
}

