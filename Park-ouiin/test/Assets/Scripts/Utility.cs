using UnityEngine;
public static class Utility
{
    public static class Object
    {
        public static void Invisible(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void Visible(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static GameObject FindVisibleGameobjectWithName(GameObject gameObject, string findObjectName)
        {
            return gameObject = GameObject.Find(findObjectName);
        }

        public static GameObject FindInvisibleGameobjectWithName(GameObject gameObject, string rootUIName, string findObjectName)
        {
            gameObject = FindVisibleGameobjectWithName(gameObject, rootUIName);
            return gameObject.transform.Find(findObjectName).gameObject;
        }
    }

    public static class Mode
    {
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

        public static void NoSleepMode()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }

    public static class Judge
    {
        //public static void NoScreenRangeOut(GameObject gameObject, PlayerController.GameType gameType)
        //{
        //    Vector3 worldpos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        //    if (gameType == PlayerController.GameType.DODGE)
        //    {
        //        if (worldpos.x < 0f) worldpos.x = 0f;
        //        if (worldpos.y < 0f) worldpos.y = 0f;
        //        if (worldpos.x > 1f) worldpos.x = 1f;
        //        if (worldpos.y > 1f) worldpos.y = 1f;
        //    }
        //    else
        //    {
        //        if (worldpos.x < 0f) worldpos.x = 0f;
        //        if (worldpos.x > 1f) worldpos.x = 1f;
        //    }
        //    gameObject.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
        //}

        public static bool Touching(Collider2D colA, Collider2D colB)
        {
            return colA.IsTouching(colB);
        }
    }
}
