using UnityEngine;

public class ObstacleManager
{
    // ��ֹ� ���� ������ �ҷ�����
    ObstacleData obstacleData = Resources.Load("ScriptableObject/Obstacle Data") as ObstacleData;

    Obstacle[] obstacle;
    int maxObstacleNum = 0; // ���� ��ֹ� ���� 

    // �ִ� ��ֹ� ���� ����
    public void Init()
    {
        obstacle = new Obstacle[obstacleData.maxObstacle];
    }

    // ������ ��ֹ� ���� �Լ�
    public void Generate(int newObstacleIndexNum)
    {
        if (newObstacleIndexNum < obstacleData.maxObstacle)
        {
            obstacle[newObstacleIndexNum] = new Obstacle();
            if ((newObstacleIndexNum % obstacleData.obstacleTypeDelay) != 1) // 10�� ���� 1���� ��Ʈ ����
                obstacle[newObstacleIndexNum].SetType(false);
            else
                obstacle[newObstacleIndexNum].SetType(true);

            obstacle[newObstacleIndexNum].Generate();
            obstacle[newObstacleIndexNum].SetPosDir();
            maxObstacleNum = ++newObstacleIndexNum;
        }
    }

    // ��� ��ֹ� ���� �Լ�
    public void DestroyObject()
    {
        for (int i = 0; i < maxObstacleNum; ++i)
        {
            GameObject.Destroy(obstacle[i].GetgoObstacle());
        }
    }

    // ��ֹ� ���� ��ȯ
    public int GetObstacleNum()
    {
        return maxObstacleNum;
    }

    // ��ֹ� ���� �ʱ�ȭ
    public void ResetObstacleNum()
    {
        maxObstacleNum = 0;
    }

    // ��ֹ� �̵� �Լ�
    public void Moving(int obstacleNum, GameObject playerGameObject, LifeManager lifeManager, UIManager uiManager)
    {
        for (int i = 0; i < obstacleNum; ++i)
        {
            obstacle[i].Move();
            // ���� ������ ����� �� �Ǵ�
            if (CalcResetRange(obstacle[i].GetgoObstacle()))                
                obstacle[i].SetPosDir(); // ��ġ�� �ӵ� �� ���� �缳��
            // �÷��̾���� �浹 Ȯ��
            if (Utility.Touching(playerGameObject.GetComponent<Collider2D>(), obstacle[i].GetgoObstacle().gameObject.GetComponent<Collider2D>()))
            {
                // ��ġ�� �ӵ� �� ���� �缳��
                obstacle[i].SetPosDir();
                // ��ֹ� Ÿ�Կ� ���� �ٸ� ȿ�� ����
                if (obstacle[i].GetBool()) // ��Ʈ ��ֹ��� ���
                {
                    lifeManager.IncreaseLife(1); // ü�� 1 ȸ��
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife()); // ü��ǥ�� UI�̹��� ����
                }
                else // ��� ��ֹ��� ���
                {
                    lifeManager.DecreaseLife(1); // ü�� 1 ����
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife()); // ü��ǥ�� UI�̹��� ����
                }
            }
        }
    }

    // ��ֹ� Ư�� ���� ������� Ȯ�� �Լ�
    bool CalcResetRange(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -obstacleData.pos_x ||
            gameObject.transform.position.x > obstacleData.pos_x ||
            gameObject.transform.position.y < -obstacleData.pos_y ||
            gameObject.transform.position.y > obstacleData.pos_y)
            return true;
        return false;
    }
}
