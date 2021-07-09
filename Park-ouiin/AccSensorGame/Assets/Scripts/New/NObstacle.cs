using UnityEngine;

public class NObstacle
{
    public GameObject goObstacle;
    Vector2 pos;
    Vector2 dir;
    bool type;

    public void Init()
    {
        goObstacle = new GameObject();
        pos = new Vector2();
        dir = new Vector2();
        type = new bool();
    }

    public bool GetBool()
    {
        return type;
    }

    public void SetType(bool type)
    {
        this.type = type;
    }

    public void Generate ()
    {
        if (type)
            goObstacle = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.ItemHeart, null);
        else
            goObstacle = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Obstacle, null);
    }

    public void SetPosDir()
    {
        pos = goObstacle.transform.position;
        switch (Random.Range(1, 5))
        {
            case 1:
                pos.x = Random.Range(-10.0f, 10.0f);
                pos.y = Random.Range(6.0f, 7.0f);
                dir.x = Random.Range(-3.0f, 3.0f);
                dir.y = Random.Range(-3.0f, -0.1f);
                break;
            case 2:
                pos.x = Random.Range(9.0f, 10.0f);
                pos.y = Random.Range(-7.0f, 7.0f);
                dir.x = Random.Range(-3.0f, -0.1f);
                dir.y = Random.Range(-3.0f, 3.0f);
                break;
            case 3:
                pos.x = Random.Range(-10.0f, 10.0f);
                pos.y = Random.Range(-7.0f, -6.0f);
                dir.x = Random.Range(-3.0f, 3.0f);
                dir.y = Random.Range(0.1f, 3.0f);
                break;
            case 4:
                pos.x = Random.Range(-10, -9);
                pos.y = Random.Range(-7, 7);
                dir.x = Random.Range(0.1f, 3.0f);
                dir.y = Random.Range(-3.0f, 3.0f);
                break;
        }
        goObstacle.transform.position = pos;
    }

    public void Move()
    {
        goObstacle.GetComponent<Rigidbody2D>().velocity = dir;
    }
}
