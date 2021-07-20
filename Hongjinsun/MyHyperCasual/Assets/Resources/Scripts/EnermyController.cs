using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyController
{
    bool speedState;
    List<Enermy> enermies;
    int cnt;

    public void Init()
    {
        speedState = false;
    }

    public void setEnermies(List<Enermy> enermies)
    {
        this.enermies = enermies;
    }

    public void setSpeedState(bool state)
    {
        speedState = state;
    }

    public void move()
    {
        if (speedState)
        {
            for (int i = enermies.Count - 1; i < enermies.Count ; ++i)
            {
                if (i == -1 || enermies.Count == cnt)
                    break;

                enermies[i].setSpeed(Random.Range(0.01f, 0.15f));
                cnt = enermies.Count;
            }
        }

        for (int i = 0; i < enermies.Count; ++i)
        {
            if (enermies[i].getEnermyObj())
            {
                if (enermies[i].getEnermyObj().transform.position.x < 0)
                    enermies[i].getEnermyObj().transform.Translate(enermies[i].getSpeed(), 0, 0);
                else if (enermies[i].getEnermyObj().transform.position.x > 0)
                    enermies[i].getEnermyObj().transform.Translate(-enermies[i].getSpeed(), 0, 0);
                else
                    enermies[i].getEnermyObj().transform.position = new Vector2(0, -2.89f);
            }
        }
    }

}
