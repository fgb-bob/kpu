using UnityEngine;

public class Obstacle
{
    // ��ֹ� �������� ������ �ҷ�����
    ObstacleSpawnData obstacleSpawnData = Resources.Load("ScriptableObject/Obstacle Spawn Data") as ObstacleSpawnData;

    GameObject goObstacle;
    Vector2 pos;
    Vector2 dir;
    bool type;

    // Ÿ�Կ� ���� ��ֹ� �����Լ�
    public void Generate()
    {
        if (type)
            goObstacle = Share.Util.InstantiatePrefab(Share.Path.Prefab.ItemHeart, null);
        else
            goObstacle = Share.Util.InstantiatePrefab(Share.Path.Prefab.Obstacle, null);
    }

    // ��ֹ� ���� ��ġ �� ���ư� ����� �ӵ� ���� �Լ�
    public void SetPosDir()
    {
        pos = goObstacle.transform.position;
        switch (Random.Range(1, 5))
        {
            case 1:
                pos = RandomVector2(obstacleSpawnData.max_pos_x, -obstacleSpawnData.max_pos_x, obstacleSpawnData.max_pos_y, obstacleSpawnData.min_pos_y);
                dir = RandomVector2(obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed, -obstacleSpawnData.min_speed, -obstacleSpawnData.max_speed);
                break;
            case 2:
                pos = RandomVector2(obstacleSpawnData.max_pos_x, obstacleSpawnData.min_pos_x, obstacleSpawnData.max_pos_y, -obstacleSpawnData.max_pos_y);
                dir = RandomVector2(-obstacleSpawnData.min_speed, -obstacleSpawnData.max_speed, obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed);
                break;
            case 3:
                pos = RandomVector2(obstacleSpawnData.max_pos_x, -obstacleSpawnData.max_pos_x, -obstacleSpawnData.min_pos_y, -obstacleSpawnData.max_pos_y);
                dir = RandomVector2(obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed, obstacleSpawnData.max_speed, obstacleSpawnData.min_speed);
                break;
            case 4:
                pos = RandomVector2(-obstacleSpawnData.min_pos_x, -obstacleSpawnData.max_pos_x, obstacleSpawnData.max_pos_y, -obstacleSpawnData.min_pos_y);
                dir = RandomVector2(obstacleSpawnData.max_speed, obstacleSpawnData.min_speed, obstacleSpawnData.max_speed, -obstacleSpawnData.max_speed);
                break;
        }
        goObstacle.transform.position = pos;
    }

    // Vector2 ���� �Լ�
    Vector2 RandomVector2(float max_pos_x, float min_pos_x, float max_pos_y, float min_pos_y)
    {
        Vector2 vector;
        vector.x = Random.Range(min_pos_x, max_pos_x);
        vector.y = Random.Range(min_pos_y, max_pos_y);
        return vector;
    }

    // ��ֹ� �̵� �Լ�
    public void Move()
    {
        goObstacle.GetComponent<Rigidbody2D>().velocity = dir;
    }

    // ��ֹ� ������Ʈ ��ȯ
    public GameObject GetgoObstacle()
    {
        return goObstacle;
    }

    // ��ֹ� Ÿ�� ��ȯ
    public bool GetBool()
    {
        return type;
    }

    // ��ֹ� Ÿ�� ����
    public void SetType(bool type)
    {
        this.type = type;
    }
}
