using UnityEngine;

public static class Share
{
    public static class Path
    {
        public static class Prefab
        {
            public static readonly string Root = "Prefabs/UIRoot";
            public static readonly string Title = "Prefabs/Title";
            public static readonly string DodgeStartbtn = "Prefabs/DodgeStartbtn";
            public static readonly string Maingame = "Prefabs/Maingame";
            public static readonly string Character = "Prefabs/Character";
            public static readonly string ScoreText = "Prefabs/ScoreText";
            public static readonly string Obstacle = "Prefabs/Obstacle";
            public static readonly string Heart = "Prefabs/Heart";
            public static readonly string ItemHeart = "Prefabs/ItemHeart";
            public static readonly string Restartbtn = "Prefabs/Restartbtn";
            public static readonly string Quitbtn = "Prefabs/Quitbtn";
            public static readonly string UpStartbtn = "Prefabs/UpStartbtn";
            public static readonly string Scaffolding = "Prefabs/Scaffolding";
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
