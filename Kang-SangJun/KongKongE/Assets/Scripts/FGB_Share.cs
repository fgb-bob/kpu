using UnityEngine;

public static class Share
{
    public static class Path
    {
        public static class Prefab
        {
            public static readonly string Root = "Prefabs/UIRoot";
            public static readonly string Title = "Prefabs/Title";
            public static readonly string Level = "Prefabs/Level";
            public static readonly string Panel = "Prefabs/Panel";

            public static readonly string Death = "Prefabs/DeathCount";

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
        public class Data
        {
            private FGB_DataManager m_DataManager = new FGB_DataManager(); 
            public void Init()
            {
                m_DataManager.PlayerDataInit();
                m_DataManager.ObjectDataInit();
                //FGB_DataManager.ObjectDataInit(Level);
            }
            public void Set()
            {
                //_DataManager.setPositon();

            }
        }

        public class UIController
        {

        }
        
    

    }
}
