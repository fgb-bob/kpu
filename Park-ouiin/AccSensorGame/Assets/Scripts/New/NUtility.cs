using UnityEngine;

public class NUtility
{
    public static void Invisible(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " 안보이게!");
        gameObject.SetActive(false);
    }

    public static void Visible(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " 보이게!");
        gameObject.SetActive(true);
    }

    public static void Pause()
    {
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public static void Resume()
    {
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public static GameObject FindVisibleGameobjectWithName(GameObject gameObject, string name)
    {
        return gameObject = GameObject.Find(name);
    }

    public static GameObject FindInvisibleGameobjectWithName(GameObject gameObject, string name)
    {
        GameObject uiRoot = new GameObject();
        uiRoot = FindVisibleGameobjectWithName(uiRoot, "UIRoot(Clone)");        
        return gameObject = uiRoot.transform.Find(name).gameObject;
    }

    public static void NoSleepMode()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public static void NoScreenRangeOut(GameObject gameObject)
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        if (worldpos.y > 1f) worldpos.y = 1f;

        gameObject.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
