using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject uiRoot;
    public static GameObject titleUI, maingameUI, resultUI;
    public static GameObject[] obstacle;
    public static int state; // 0 - title  1 - ∏ﬁ¿Œ

    private void Awake()
    {
        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));
        UIManager.MakeTitleUI();
        titleUI = GameObject.Find("TitleCanvas");

        UIManager.MakeMaingameUI();
        maingameUI = GameObject.Find("MaingameCanvas");
        UIManager.Invisible(maingameUI);

        UIManager.MakeResultUI();
        resultUI = GameObject.Find("ResultCanvas");
        UIManager.Invisible(resultUI);

        state = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case 1:
                CharacterManager.Player.GetComponent<Player>().Playing();
                MaingameUI.SetScoreText();

                for (int i = 0; i < ObstacleManager.Obstacles.Length; ++i)
                {
                    Obstacle.Move(ObstacleManager.Obstacles[i], ObstacleManager.ObstaclesVector[i]);
                    if (ObstacleManager.OutOfRange(ObstacleManager.Obstacles[i]))
                    {
                        ObstacleManager.ReSetPosition(ObstacleManager.Obstacles[i], i);
                    }
                    if (CharacterManager.Touching(CharacterManager.Player.GetComponent<Collider2D>(), ObstacleManager.Obstacles[i].GetComponent<Collider2D>()))
                    {
                        if (i != ObstacleManager.Obstacles.Length - 1)
                        {
                            ObstacleManager.ReSetPosition(ObstacleManager.Obstacles[i], i);
                            CharacterManager.DecreaseLife(1);
                            if (CharacterManager.life <= 0)
                            {
                                GamePause();
                                UIManager.Visible(resultUI);
                                state = 0;
                            }
                        }
                        else
                        {
                            ObstacleManager.ReSetPosition(ObstacleManager.Obstacles[i], i);
                            CharacterManager.IncreaseLife(1);
                        }
                        break;
                    }
                }
                break;
        }
    }

    public static void GamePause()
    {
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public static void GameResume()
    {
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
