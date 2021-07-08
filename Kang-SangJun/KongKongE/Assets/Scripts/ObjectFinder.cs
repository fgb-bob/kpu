//using UnityEngine;

//public   class ObjectFinder
//{
//    public   class Path
//    {
//        public   class Prefab
//        {
//            public   readonly string Root = "Prefabs/UIRoot";
//            public   readonly string Title = "Prefabs/Title";
//            public   readonly string Player = "Prefabs/Test";
//        }
//    }

//    publicclass Bundle
//    {
//        public   T LoadAsset<T>(string path) where T : Object
//        {
//            return Resources.Load<T>(path);
//        }
//    }

//    public   class Util
//    {
//        public   GameObject InstantiatePrefab(string path, Transform parent)
//        {
//            return GameObject.Instantiate(Bundle.LoadAsset<GameObject>(path), parent);
//        }
//    }
//}
