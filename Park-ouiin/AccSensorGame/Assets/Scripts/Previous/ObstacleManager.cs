using UnityEngine;

public class ObstacleManager
{
    public static GameObject[] Obstacles;
    public static Vector3[] ObstaclesVector;
    public static int ObstacleNum, maxObstacleNum;

    public static void Init()
    {
        ObstacleNum = 10;
        maxObstacleNum = 10;

        Obstacles = new GameObject[maxObstacleNum];
        ObstaclesVector = new Vector3[maxObstacleNum];
        for (int i = 0; i < maxObstacleNum; ++i)
        {
            if ((i % 10) != 1)
                Obstacles[i] = Share.Util.InstantiatePrefab(Share.Path.Prefab.Obstacle, null);
            else
                Obstacles[i] = Share.Util.InstantiatePrefab(Share.Path.Prefab.ItemHeart, null);

            Vector2 temp = Obstacles[i].transform.position;            
            switch (Random.Range(1, 5))
            {
                case 1:
                    temp.x = Random.Range(-10.0f, 10.0f);
                    temp.y = Random.Range(6.0f, 7.0f);
                    ObstaclesVector[i].x = Random.Range(-3.0f, 3.0f);
                    ObstaclesVector[i].y = Random.Range(-3.0f, -0.1f);
                    break;
                case 2:
                    temp.x = Random.Range(9.0f, 10.0f);
                    temp.y = Random.Range(-7.0f, 7.0f);
                    ObstaclesVector[i].x = Random.Range(-3.0f, -0.1f);
                    ObstaclesVector[i].y = Random.Range(-3.0f, 3.0f);
                    break;
                case 3:
                    temp.x = Random.Range(-10.0f, 10.0f);
                    temp.y = Random.Range(-7.0f, -6.0f);
                    ObstaclesVector[i].x = Random.Range(-3.0f, 3.0f);
                    ObstaclesVector[i].y = Random.Range(0.1f, 3.0f);                    
                    break;
                case 4:
                    temp.x = Random.Range(-10, -9);
                    temp.y = Random.Range(-7, 7);
                    ObstaclesVector[i].x = Random.Range(0.1f, 3.0f);
                    ObstaclesVector[i].y = Random.Range(-3.0f, 3.0f);
                    break;
            }
            Obstacles[i].transform.position = temp;
            Obstacle.Move(Obstacles[i], ObstaclesVector[i]);
        }
    }

    public static void ReSetPosition(GameObject gameObject, int num)
    {
        Vector2 temp = gameObject.transform.position;
        switch (Random.Range(1, 5))
        {
            case 1:
                temp.x = Random.Range(-10.0f, 10.0f);
                temp.y = Random.Range(6.0f, 7.0f);
                ObstaclesVector[num].x = Random.Range(-3.0f, 3.0f);
                ObstaclesVector[num].y = Random.Range(-3.0f, -0.1f);
                break;
            case 2:
                temp.x = Random.Range(9.0f, 10.0f);
                temp.y = Random.Range(-7.0f, 7.0f);
                ObstaclesVector[num].x = Random.Range(-3.0f, -0.1f);
                ObstaclesVector[num].y = Random.Range(-3.0f, 3.0f);
                break;
            case 3:
                temp.x = Random.Range(-10.0f, 10.0f);
                temp.y = Random.Range(-7.0f, -6.0f);
                ObstaclesVector[num].x = Random.Range(-3.0f, 3.0f);
                ObstaclesVector[num].y = Random.Range(0.1f, 3.0f);                
                break;
            case 4:
                temp.x = Random.Range(-10, -9);
                temp.y = Random.Range(-7, 7);
                ObstaclesVector[num].x = Random.Range(0.1f, 3.0f);
                ObstaclesVector[num].y = Random.Range(-3.0f, 3.0f);
                break;
        }
        gameObject.transform.position = temp;
        Obstacle.Move(gameObject, ObstaclesVector[num]);
    }

    public static bool OutOfRange(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -10f ||
            gameObject.transform.position.x > 10f ||
            gameObject.transform.position.y < -7f ||
            gameObject.transform.position.y > 7f)
            return true;
        return false;
    }
}
