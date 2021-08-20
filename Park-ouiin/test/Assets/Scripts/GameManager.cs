using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject rootUI;
    GameObject mapGameObject;

    PlayerManager playerManager;

    MapData mapData;
    Vector2 pos;
    private void Awake()
    {
        Utility.Mode.NoSleepMode();

        DontDestroyOnLoad(this.rootUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.rootUI, null));

        mapData = Resources.Load("ScriptableObject/Map Data") as MapData;

        playerManager = new PlayerManager();
        playerManager.Init();

        pos = Vector2.zero;
    }

    private void Start()
    {
        for (int row = 0; row < mapData.map[0].row.Length; ++row)
        {
            for (int col = 0; col < mapData.map[0].row[row].col.Length; ++col)
            {
                switch (mapData.map[0].row[row].col[col])
                {
                    case 0: // 빈 공간
                        break;
                    case 1: // 파괴불가 오브젝트
                        mapGameObject = GameObject.Instantiate(mapData.indestructible);
                        mapGameObject.transform.SetParent(rootUI.transform);
                        pos.x = -8.5f + col * 1.0f;
                        pos.y = 4.5f - row * 1.0f;
                        mapGameObject.GetComponent<Transform>().position = pos;
                        break;
                    case 2: // 파괴가능 오브젝트
                        mapGameObject = GameObject.Instantiate(mapData.destructible);
                        mapGameObject.transform.SetParent(rootUI.transform);
                        pos.x = -8.5f + col * 1.0f;
                        pos.y =4.5f - row * 1.0f;
                        mapGameObject.GetComponent<Transform>().position = pos;
                        break;
                    default:
                        throw new System.NotImplementedException();
                }
            }
        }
    }

    void FixedUpdate()
    {
        playerManager.PlayerMoveUpdate();
    }
}
