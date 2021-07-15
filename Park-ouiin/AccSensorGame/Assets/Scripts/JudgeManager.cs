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
            if (Utility.Touching(playerGameObject.GetComponent<Collider2D>(), obstacleManager.GetObstacles()[i].GetgoObstacle().gameObject.GetComponent<Collider2D>()))
            {
                obstacleManager.GetObstacles()[i].SetPosDir();
                if (obstacleManager.GetObstacles()[i].GetBool()) // 하트 장애물일 경우
                {
                    lifeManager.IncreaseLife(1);
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                }
                else // 그외 장애물일 경우
                {
                    lifeManager.DecreaseLife(1);
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                }
            }
        }
    }
}
