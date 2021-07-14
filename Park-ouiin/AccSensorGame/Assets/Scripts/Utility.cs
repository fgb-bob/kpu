using UnityEngine;

// 어디서든 쓸 수 있는 함수 모음 클래스
public class Utility
{
    // 게임 오브젝프 보이게 하는 함수
    public static void Invisible(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    // 게임 오브젝트 안보이게 하는 함수
    public static void Visible(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    // 게임 멈추게 하는 함수
    public static void Pause()
    {
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    // 멈춘 게임 다시 움직이게 하는 함수
    public static void Resume()
    {
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    // 보이는 게임 오브젝트를 이름으로 찾는 함수
    public static GameObject FindVisibleGameobjectWithName(GameObject gameObject, string findObjectName)
    {
        return gameObject = GameObject.Find(findObjectName);
    }

    // 안보이는 게임 오브젝트를 이름으로 찾는 함수
    public static GameObject FindInvisibleGameobjectWithName(GameObject gameObject, string rootUIName, string findObjectName)
    {
        gameObject = FindVisibleGameobjectWithName(gameObject, rootUIName);;
        return gameObject.transform.Find(findObjectName).gameObject;
    }

    // 화면이 꺼지지 않도록 하는 함수
    public static void NoSleepMode()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // 게임 오브젝트가 화면 밖으로 못나가게 하는 함수
    public static void NoScreenRangeOut(GameObject gameObject)
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        if (worldpos.y > 1f) worldpos.y = 1f;

        gameObject.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }

    // 두 콜라이더가 충돌하는 지 확인하는 함수
    public static bool Touching(Collider2D colA, Collider2D colB)
    {
        return colA.IsTouching(colB);
    }
}
