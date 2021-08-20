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

    public void Generate(int newObstacleIndexNum, UIManager uIManager)
    {
        if (newObstacleIndexNum < obstacleData.maxObstacle)
        {
            obstacle[newObstacleIndexNum] = new Obstacle();
            if ((newObstacleIndexNum % obstacleData.obstacleTypeDelay) != 1) // obstacleData.obstacleTypeDelay ���� 1���� ��Ʈ ����
                obstacle[newObstacleIndexNum].SetType(false);
            else
                obstacle[newObstacleIndexNum].SetType(true);

            obstacle[newObstacleIndexNum].Generate();
            GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
            obstacle[newObstacleIndexNum].SetPosDir(uIManager.GetState(), gameObject.GetComponent<Transform>().position.y);
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

    public bool GetType(int index)
    {
        return obstacle[index].GetBool();
    }

    public void SetPosDir(int index, UIManager.State state)
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        obstacle[index].SetPosDir(state, gameObject.GetComponent<Transform>().position.y);
    }

    public GameObject GetGameObjectObstacle(int index)
    {
        return obstacle[index].GetgoObstacle();
    }

    // ��ֹ� Ư�� ���� ������� Ȯ�� �Լ�
    bool CalcResetRange(GameObject gameObject, UIManager uiManager)
    {
        if (uiManager.GetState() == UIManager.State.DODGEMAINGAME)
        {
            if (gameObject.transform.position.x < -obstacleData.pos_x ||
                gameObject.transform.position.x > obstacleData.pos_x ||
                gameObject.transform.position.y < -obstacleData.pos_y ||
                gameObject.transform.position.y > obstacleData.pos_y)
                return true;
            return false;
        }
        else
        {
            if (gameObject.transform.position.x < -obstacleData.pos_x ||
                gameObject.transform.position.x > obstacleData.pos_x)
                return true;
            return false;
        }
    }

    public void Moving(UIManager uiManager)
    {
        for (int i = 0; i < maxObstacleNum; ++i)
        {
            obstacle[i].Move();
            if (CalcResetRange(obstacle[i].GetgoObstacle(), uiManager))
            {
                GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
                obstacle[i].SetPosDir(uiManager.GetState(), gameObject.GetComponent<Transform>().position.y);
            }
        }
    }
}
