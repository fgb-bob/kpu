using UnityEngine;

public class ObstacleManager
{
    ObstacleData obstacleData = Resources.Load("ScriptableObject/Obstacle Data") as ObstacleData;

    Obstacle[] obstacle;
    int maxObstacleNum = 0; // ���� ��ֹ� ���� 

    public void Init()
    {
        obstacle = new Obstacle[obstacleData.maxObstacle];
    }

    public void Generate(int newObstacleIndexNum)
    {
        if (newObstacleIndexNum < obstacleData.maxObstacle)
        {
            obstacle[newObstacleIndexNum] = new Obstacle();
            if ((newObstacleIndexNum % obstacleData.obstacleTypeDelay) != 1) // obstacleData.obstacleTypeDelay ���� 1���� ��Ʈ ����
                obstacle[newObstacleIndexNum].SetType(false);
            else
                obstacle[newObstacleIndexNum].SetType(true);

            obstacle[newObstacleIndexNum].Generate();
            obstacle[newObstacleIndexNum].SetPosDir();
            maxObstacleNum = ++newObstacleIndexNum;
        }
    }

    public void DestroyObject()
    {
        for (int i = 0; i < maxObstacleNum; ++i)
        {
            GameObject.Destroy(obstacle[i].GetgoObstacle());
        }
    }

    public int GetObstacleNum()
    {
        return maxObstacleNum;
    }

    public void ResetObstacleNum()
    {
        maxObstacleNum = 0;
    }

    public Obstacle[] GetObstacles()
    {
        return obstacle;
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

    public void Moving()
    {
        for (int i = 0; i < maxObstacleNum; ++i)
        {
            obstacle[i].Move();
            if (CalcResetRange(obstacle[i].GetgoObstacle()))
                obstacle[i].SetPosDir();
        }
    }
}
