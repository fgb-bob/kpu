using UnityEngine;

public class NObstacleManager
{
    public NObstacle[] nObstacle;    
    public int num = 0;
    public void Init()
    {
        nObstacle = new NObstacle[num];

        for (int i = 0; i < num; ++i)
        {
            nObstacle[i] = new NObstacle();
            nObstacle[i].Init();
            if ((i % 10) != 1)
                nObstacle[i].SetType(false);
            else
                nObstacle[i].SetType(true);
            nObstacle[i].Generate();
            nObstacle[i].SetPosDir();
        }
    }

    public bool OutOfRange(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -10f ||
            gameObject.transform.position.x > 10f ||
            gameObject.transform.position.y < -7f ||
            gameObject.transform.position.y > 7f)
            return true;
        return false;
    }
}
