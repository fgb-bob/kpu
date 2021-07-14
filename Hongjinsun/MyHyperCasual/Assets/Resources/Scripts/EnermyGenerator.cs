using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyGenerator
{
    List<Enermy> enermies;
    int cntEnermy = 0;
    int maxEnermy;
    float spawntime = 1.0f;
    float delta = 0;
    float spawnSpeed = 0;
    int spawnInt;
    bool enermyGen;

    public void Init()
    {
        enermies = new List<Enermy>();
        enermyGen = false;
    }

    // Resume, NextStage 버튼을 누르면 호출 될 함수
    public void resetData()
    {
        setMaxEnermy();
        enermies.Clear();
        enermyGen = true;
        cntEnermy = 0;
        delta = 0;
        spawnSpeed = 0;
    }

    public int getMaxEnermy()
    {
        return maxEnermy;
    }

    public void setMaxEnermy()
    {
        maxEnermy = Random.Range(20, 50);
        Debug.Log("적의 수 - " + maxEnermy);
    }

    public void setCntEnermy(int n)
    {
        cntEnermy = n;
    }

    public int getCntEnermy()
    {
        return cntEnermy;
    }

    public void spawnEnermy()
    {
        if (this.enermyGen == true)
        {
            spawntime = Random.Range(1.0f, 3.0f);

            delta += Time.deltaTime;

            if (delta > spawntime - spawnSpeed && cntEnermy < maxEnermy)
            {
                Enermy enermy = new Enermy();
                enermy.Init(); 

                spawnInt = Random.Range(0, 2);
                
                if (spawnInt == 0)
                    enermy.getEnermyObj().transform.position = new Vector2(-10, -2.89f);
                else
                    enermy.getEnermyObj().transform.position = new Vector2(10, -2.89f);

                enermies.Add(enermy);
                ++cntEnermy;

                delta = 0f;
                if (spawntime - spawnSpeed > 0)
                    spawnSpeed += 0.00005f;


            }
            if (cntEnermy == maxEnermy)
                this.enermyGen = false;
        }
    }

    public void deleteEnermy()
    {
        enermies.Clear();
        cntEnermy = 0;
    }

    public List<Enermy> getEnermies()
    {
        return enermies;
    }

    public void setEnermyGen(bool state) 
    {
        enermyGen = state;
    }

    public void setDelta(float f)
    {
        delta = f;
    }
    
}
