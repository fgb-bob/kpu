using UnityEngine;

public class ObstacleManager
{
    ObstacleData obstacleData = Resources.Load("ScriptableObject/Obstacle Data") as ObstacleData;

    Obstacle[] obstacle;
    int maxObstacleNum = 0; // 현재 장애물 갯수

    public void Init()
    {
        obstacle = new Obstacle[obstacleData.maxObstacle];
    }

    public void Generate(int newObstacleIndexNum, UIManager uIManager)
    {
        if (newObstacleIndexNum < obstacleData.maxObstacle)
        {
            obstacle[newObstacleIndexNum] = new Obstacle();
            if ((newObstacleIndexNum % obstacleData.obstacleTypeDelay) != 1) // obstacleData.obstacleTypeDelay 마다 1개씩 하트 생성
                obstacle[newObstacleIndexNum].SetType(false);
            else
                obstacle[newObstacleIndexNum].SetType(true);

            obstacle[newObstacleIndexNum].Generate();
            if (uIManager.GetState() == UIManager.State.DODGEMAINGAME)
                obstacle[newObstacleIndexNum].SetPosDir();
            else
            {
                GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
                obstacle[newObstacleIndexNum].SetPosDir2(gameObject.GetComponent<Transform>().position.y);
            }
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

    public void SetPosDir(int index)
    {
        obstacle[index].SetPosDir();
    }

    public GameObject GetGameObjectObstacle(int index)
    {
        return obstacle[index].GetgoObstacle();
    }

    // 장애물 특정 범위 벗어났는지 확인 함수
    bool CalcResetRange(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -obstacleData.pos_x ||
            gameObject.transform.position.x > obstacleData.pos_x ||
            gameObject.transform.position.y < -obstacleData.pos_y ||
            gameObject.transform.position.y > obstacleData.pos_y)
            return true;
        return false;
    }

    bool CalcResetRange2(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -obstacleData.pos_x ||
            gameObject.transform.position.x > obstacleData.pos_x)
            return true;
        return false;
    }

    public void Moving(UIManager uiManager)
    {
        if (uiManager.GetState() == UIManager.State.DODGEMAINGAME)
        {
            for (int i = 0; i < maxObstacleNum; ++i)
            {
                obstacle[i].Move();
                if (CalcResetRange(obstacle[i].GetgoObstacle()))
                    obstacle[i].SetPosDir();
            }
        }
        else 
        {
            for (int i = 0; i < maxObstacleNum; ++i)
            {
                obstacle[i].Move();
                if (CalcResetRange2(obstacle[i].GetgoObstacle()))
                {
                    GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
                    obstacle[i].SetPosDir2(gameObject.GetComponent<Transform>().position.y);
                }
            }
        }
    }
}
