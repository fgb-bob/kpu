using UnityEngine;

public class Obstacle
{
    ObstacleSpawnData obstacleSpawnData = Resources.Load("ScriptableObject/Obstacle Spawn Data") as ObstacleSpawnData;

    GameObject goObstacle;
    Vector2 pos;
    Vector2 dir;
    bool type;

    public void Generate()
    {
        if (type)
            goObstacle = Share.Util.InstantiatePrefab(Share.Path.Prefab.ItemHeart, null);
        else
        {
            goObstacle = Share.Util.InstantiatePrefab(Share.Path.Prefab.Obstacle, null);
            SetAnimator();
        }
    }

    void SetAnimator()
    {
        switch (Random.Range(1, 9))
        {
            case 2:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Banana") as RuntimeAnimatorController;
                break;
            case 3:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Cherry") as RuntimeAnimatorController;
                break;
            case 4:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Kiwi") as RuntimeAnimatorController;
                break;
            case 5:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Melon") as RuntimeAnimatorController;
                break;
            case 6:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Orange") as RuntimeAnimatorController;
                break;
            case 7:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Pineapple") as RuntimeAnimatorController;
                break;
            case 8:
                goObstacle.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animation/Strawberry") as RuntimeAnimatorController;
                break;
        }
    }

    public void SetPosDir(UIManager.State state, float y)
    {
        pos = goObstacle.transform.position;
        if (state == UIManager.State.DODGEMAINGAME)
        {
            switch (Random.Range(1, 5))
            {
                case 1:
                    pos = RandomVector(obstacleSpawnData.max_pos_x, -obstacleSpawnData.max_pos_x, obstacleSpawnData.max_pos_y, obstacleSpawnData.min_pos_y);
                    dir = RandomVector(obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed, -obstacleSpawnData.min_speed, -obstacleSpawnData.max_speed);
                    break;
                case 2:
                    pos = RandomVector(obstacleSpawnData.max_pos_x, obstacleSpawnData.min_pos_x, obstacleSpawnData.max_pos_y, -obstacleSpawnData.max_pos_y);
                    dir = RandomVector(-obstacleSpawnData.min_speed, -obstacleSpawnData.max_speed, obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed);
                    break;
                case 3:
                    pos = RandomVector(obstacleSpawnData.max_pos_x, -obstacleSpawnData.max_pos_x, -obstacleSpawnData.min_pos_y, -obstacleSpawnData.max_pos_y);
                    dir = RandomVector(obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed, obstacleSpawnData.max_speed, obstacleSpawnData.min_speed);
                    break;
                case 4:
                    pos = RandomVector(-obstacleSpawnData.min_pos_x, -obstacleSpawnData.max_pos_x, obstacleSpawnData.max_pos_y, -obstacleSpawnData.min_pos_y);
                    dir = RandomVector(obstacleSpawnData.max_speed, obstacleSpawnData.min_speed, obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed);
                    break;
            }
        }
        else
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    pos = RandomVector(-obstacleSpawnData.min_pos_x, -obstacleSpawnData.max_pos_x, y + 3, y + 5);
                    dir.x = -pos.x;
                    break;
                case 2:
                    pos = RandomVector(obstacleSpawnData.max_pos_x, obstacleSpawnData.min_pos_x, y + 3, y + 5);
                    dir.x = -pos.x;
                    break;
            }
        }
        goObstacle.transform.position = pos;
    }

    Vector2 RandomVector(float max_pos_x, float min_pos_x, float max_pos_y, float min_pos_y)
    {
        Vector2 vector;
        vector.x = Random.Range(min_pos_x, max_pos_x);
        vector.y = Random.Range(min_pos_y, max_pos_y);
        return vector;
    }

    public void Move()
    {
        goObstacle.GetComponent<Rigidbody2D>().velocity = dir;
    }

    public GameObject GetgoObstacle()
    {
        return goObstacle;
    }

    public bool GetBool()
    {
        return type;
    }

    // ?????? ???? ????
    public void SetType(bool type)
    {
        this.type = type;
    }
}
