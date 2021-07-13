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
                pos.x = Random.Range(-obstacleSpawnData.max_pos_x, obstacleSpawnData.max_pos_x);
                pos.y = Random.Range(obstacleSpawnData.min_pos_y, obstacleSpawnData.max_pos_y);
                dir.x = Random.Range(-obstacleSpawnData.max_speed, obstacleSpawnData.max_speed);
                dir.y = Random.Range(-obstacleSpawnData.max_speed, -obstacleSpawnData.min_speed);
                break;
            case 2:
                pos.x = Random.Range(obstacleSpawnData.min_pos_x, obstacleSpawnData.max_pos_x);
                pos.y = Random.Range(-obstacleSpawnData.max_pos_y, obstacleSpawnData.max_pos_y);
                dir.x = Random.Range(-obstacleSpawnData.max_speed, -obstacleSpawnData.min_speed);
                dir.y = Random.Range(-obstacleSpawnData.max_speed, obstacleSpawnData.max_speed);
                break;
            case 3:
                pos.x = Random.Range(-obstacleSpawnData.max_pos_x, obstacleSpawnData.max_pos_x);
                pos.y = Random.Range(-obstacleSpawnData.max_pos_y, -obstacleSpawnData.min_pos_y);
                dir.x = Random.Range(-obstacleSpawnData.max_speed, obstacleSpawnData.max_speed);
                dir.y = Random.Range(obstacleSpawnData.min_speed, obstacleSpawnData.max_speed);
                break;
            case 4:
                pos.x = Random.Range(-obstacleSpawnData.max_pos_x, -obstacleSpawnData.min_pos_x);
                pos.y = Random.Range(-obstacleSpawnData.min_pos_y, obstacleSpawnData.max_pos_y);
                dir.x = Random.Range(obstacleSpawnData.min_speed, obstacleSpawnData.max_speed);
                dir.y = Random.Range(-obstacleSpawnData.max_speed, obstacleSpawnData.max_speed);
                break;
        }
        goObstacle.transform.position = pos;
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
