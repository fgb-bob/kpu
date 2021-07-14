using UnityEngine;

public class Obstacle
{
    // 장애물 스폰관련 데이터 불러오기
    ObstacleSpawnData obstacleSpawnData = Resources.Load("ScriptableObject/Obstacle Spawn Data") as ObstacleSpawnData;

    GameObject goObstacle;
    Vector2 pos;
    Vector2 dir;
    bool type;

    // 타입에 따른 장애물 생성함수
    public void Generate()
    {
        if (type)
            goObstacle = Share.Util.InstantiatePrefab(Share.Path.Prefab.ItemHeart, null);
        else
            goObstacle = Share.Util.InstantiatePrefab(Share.Path.Prefab.Obstacle, null);
    }

    // 장애물 생성 위치 및 나아갈 방향과 속도 설정 함수
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

    // Vector2 생성 함수
    Vector2 RandomVector2(float max_pos_x, float min_pos_x, float max_pos_y, float min_pos_y)
    {
        Vector2 vector;
        vector.x = Random.Range(min_pos_x, max_pos_x);
        vector.y = Random.Range(min_pos_y, max_pos_y);
        return vector;
    }

    // 장애물 이동 함수
    public void Move()
    {
        goObstacle.GetComponent<Rigidbody2D>().velocity = dir;
    }

    // 장애물 오브젝트 반환
    public GameObject GetgoObstacle()
    {
        return goObstacle;
    }

    // 장애물 타입 반환
    public bool GetBool()
    {
        return type;
    }

    // 장애물 타입 설정
    public void SetType(bool type)
    {
        this.type = type;
    }
}
