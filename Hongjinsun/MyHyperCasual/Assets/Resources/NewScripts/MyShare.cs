using UnityEngine;
public class MyShare
{
    public static class Path
    {
        public static class Prefab
        {
            public static readonly string Root = "Prefabs/UIRoot";
            public static readonly string Background = "Prefabs/Background";
            public static readonly string Map = "Prefabs/Map";
            public static readonly string Title = "Prefabs/TitleUI";
            public static readonly string Dead = "Prefabs/DeadUI";
            public static readonly string Clear = "Prefabs/ClearUI";
            public static readonly string Button = "Prefabs/ButtonUI";
            public static string Player = "Prefabs/Player";
            public static string Enermy = "Prefabs/Enermy";
            public static readonly string StopSide = "Prefabs/CollisionObject";
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