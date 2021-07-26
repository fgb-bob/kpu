using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnermyController
{
    public List<MyEnermy> enermies;
    public Vector2 velocity = new Vector2(5, 0);

    public void Init(List<MyEnermy> enermies)
    {
        this.enermies = enermies;
    }

    public void Move(float deltaTime)
    {
        for (int i = 0; i < enermies.Count; ++i)
        {
            if (enermies[i].obj)
            {
                if (enermies[i].obj.transform.position.x == 0)
                    enermies[i].isMove = false;

                if (enermies[i].isMove == true)
                {
                    enermies[i].rigid.transform.position = Vector2.MoveTowards(enermies[i].obj.transform.position, new Vector2(0, -2.8f), enermies[i].speed * deltaTime);
                }
            }
        }
    }

}
