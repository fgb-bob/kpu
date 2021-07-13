using UnityEngine;

public class ObstacleManager
{
    // 장애물 관련 데이터 불러오기
    ObstacleData obstacleData = Resources.Load("ScriptableObject/Obstacle Data") as ObstacleData;

    Obstacle[] obstacle;
    int maxObstacleNum = 0; // 현재 장애물 갯수 

    // 최대 장애물 갯수 설정
    public void Init()
    {
        obstacle = new Obstacle[obstacleData.maxObstacle];
    }

    // 생성된 장애물 셋팅 함수
    public void Generate(int newObstacleIndexNum)
    {
        if (newObstacleIndexNum < obstacleData.maxObstacle)
        {
            obstacle[newObstacleIndexNum] = new Obstacle();
            if ((newObstacleIndexNum % obstacleData.obstacleTypeDelay) != 1) // 10개 마다 1개씩 하트 생성
                obstacle[newObstacleIndexNum].SetType(false);
            else
                obstacle[newObstacleIndexNum].SetType(true);

            obstacle[newObstacleIndexNum].Generate();
            obstacle[newObstacleIndexNum].SetPosDir();
            maxObstacleNum = ++newObstacleIndexNum;
        }
    }

    // 모든 장애물 삭제 함수
    public void DestroyObject()
    {
        for (int i = 0; i < maxObstacleNum; ++i)
        {
            GameObject.Destroy(obstacle[i].GetgoObstacle());
        }
    }

    // 장애물 갯수 반환
    public int GetObstacleNum()
    {
        return maxObstacleNum;
    }

    // 장애물 갯수 초기화
    public void ResetObstacleNum()
    {
        maxObstacleNum = 0;
    }

    // 장애물 이동 함수
    public void Moving(int obstacleNum, GameObject playerGameObject, LifeManager lifeManager, UIManager uiManager)
    {
        for (int i = 0; i < obstacleNum; ++i)
        {
            obstacle[i].Move();
            // 일정 범위를 벗어났는 지 판단
            if (CalcResetRange(obstacle[i].GetgoObstacle()))                
                obstacle[i].SetPosDir(); // 위치와 속도 및 방향 재설정
            // 플레이어와의 충돌 확인
            if (Utility.Touching(playerGameObject.GetComponent<Collider2D>(), obstacle[i].GetgoObstacle().gameObject.GetComponent<Collider2D>()))
            {
                // 위치와 속도 및 방향 재설정
                obstacle[i].SetPosDir();
                // 장애물 타입에 따른 다른 효과 적용
                if (obstacle[i].GetBool()) // 하트 장애물일 경우
                {
                    lifeManager.IncreaseLife(1); // 체력 1 회복
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife()); // 체력표시 UI이미지 갱신
                }
                else // 사과 장애물일 경우
                {
                    lifeManager.DecreaseLife(1); // 체력 1 감소
                    uiManager.GetMaingameUI().SetHeartActive(lifeManager.GetLife(), lifeManager.GetMaxLife()); // 체력표시 UI이미지 갱신
                }
            }
        }
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
}
