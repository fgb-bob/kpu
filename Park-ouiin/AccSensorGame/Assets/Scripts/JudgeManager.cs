using UnityEngine;

public class JudgeManager
{
    ObstacleManager obstacleManager;
    LifeManager lifeManager;
    UIManager uiManager;

    public void Init(ObstacleManager obstacleManager,LifeManager lifeManager, UIManager uiManager)
    {
        this.obstacleManager = obstacleManager;
        this.lifeManager = lifeManager;
        this.uiManager = uiManager;
    }

    public void judging(GameObject playerGameObject)
    {
        for (int i = 0; i < obstacleManager.GetObstacleNum(); ++i)
        {
            if (Utility.Judge.Touching(playerGameObject.GetComponent<Collider2D>(), obstacleManager.GetGameObjectObstacle(i).gameObject.GetComponent<Collider2D>()))
            {
                obstacleManager.SetPosDir(i);
                if (obstacleManager.GetType(i)) // 하트 장애물일 경우
                {
                    lifeManager.IncreaseLife(1);
                    uiManager.SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                }
                else // 그외 장애물일 경우
                {
                    lifeManager.DecreaseLife(1);
                    uiManager.SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                }
            }
        }
    }
}
