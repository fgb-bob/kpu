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
                if (obstacleManager.GetObstacles()[i].GetBool()) // ��Ʈ ��ֹ��� ���
                {
                    lifeManager.IncreaseLife(1);
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                }
                else // �׿� ��ֹ��� ���
                {
                    lifeManager.DecreaseLife(1);
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife());
                }
            }
        }
    }
}
