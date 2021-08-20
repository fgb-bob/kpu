using UnityEngine;

public static class Share
{
    public static class Path
    {
        public static class Prefab
        {
            public static readonly string rootUI = "Prefabs/UIRoot";
            public static readonly string player = "Prefabs/Player";
            public static readonly string map = "Prefabs/Map";
        }
    }

    public static class Bundle
    {
        public static T LoadAsset<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }

    public static class Util
    {
        public static GameObject InstantiatePrefab(string path, Transform parent)
        {
            return GameObject.Instantiate(Bundle.LoadAsset<GameObject>(path), parent);
        }
    }
}
