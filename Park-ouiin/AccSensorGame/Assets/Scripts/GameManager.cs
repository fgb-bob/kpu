using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject uiRoot, player;
    GameObject[] obstacle;
    public static int state; // 0 - title  1 - 메인

    private void Awake()
    {
        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));
        UIManager.MakeTitleUI();
        state = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case 0:
                break;
            case 1:
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Player>().Playing();
                MaingameUI.SetScoreText();

                obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
                for (int i = 0; i < obstacle.Length; ++i)
                {
                    Obstacle.Move(obstacle[i], ObstacleManager.ObstaclesVector[i]);
                    if (ObstacleManager.OutOfRange(obstacle[i]))
                    {
                        ObstacleManager.ReSetPosition(obstacle[i], i);
                    }
                    if (CharacterManager.Touching(player.GetComponent<Collider2D>(), obstacle[i].GetComponent<Collider2D>()))
                    {
                        if (i != obstacle.Length - 1)
                        {
                            ObstacleManager.ReSetPosition(obstacle[i], i);
                            Debug.Log("충돌");
                            CharacterManager.DecreaseLife(1);
                            Debug.Log("체력 1개 감소");                            
                        }
                        else
                        {
                            ObstacleManager.ReSetPosition(obstacle[i], i);
                            Debug.Log("충돌");
                            CharacterManager.IncreaseLife(1);
                            Debug.Log("체력 1개 증가");                            
                        }
                        break;
                    }
                }

                break;
        }
    }
}
