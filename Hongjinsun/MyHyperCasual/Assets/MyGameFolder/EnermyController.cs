using UnityEngine;

public class EnermyController
{
    float max = 0.2f;
    float min = 0.01f;
    public void move(GameObject enermy)
    {
        if (enermy.transform.position.x < 0)
            enermy.transform.Translate(Random.Range(min, max), 0, 0);
        else if (enermy.transform.position.x > 0)
            enermy.transform.Translate(-Random.Range(min, max), 0, 0);
        else
            enermy.transform.position = new Vector2(0, -2.89f);
    }


}
