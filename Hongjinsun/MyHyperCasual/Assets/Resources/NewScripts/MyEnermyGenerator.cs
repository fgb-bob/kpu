using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnermyGenerator
{
    public List<MyEnermy> enermies;
    public MyEnermyController enermyController;
    public bool enermyGen;
    float m_spawnTime;
    float m_delta;
    float m_spawnSpeed;
    int spawnInt;
    int maxEnermy;
    int cntEnermy;

    public void Init()
    {
        enermyController = new MyEnermyController();
        ResetData();
        enermyGen = false;
    }

    public void ResetData()
    {
        if ( enermies != null)
            enermies.Clear();
        enermies = new List<MyEnermy>();
        enermyGen = true;
        m_delta = 0;
        m_spawnSpeed = 0;
        spawnInt = 0;
        cntEnermy = 0;
        SetMaxEnermy();
    }

    public void SetMaxEnermy()
    {
        maxEnermy = Random.Range(20, 50);
        Debug.Log(maxEnermy + "付府 利 积己");
    }

    public void CheckSpawn()
    {
        if (this.enermyGen == true)
        {
            m_spawnTime = Random.Range(0.5f, 2.0f);

            m_delta += Time.deltaTime;

            if (m_delta > m_spawnTime - m_spawnSpeed && cntEnermy < maxEnermy)
            {
                MyEnermy enermy = new MyEnermy();
                enermy.Init();
                enermy.isMove = true;

                spawnInt = Random.Range(0, 2);

                if (spawnInt == 0)
                    enermy.obj.transform.position = new Vector2(-10, -2.89f);
                else
                    enermy.obj.transform.position = new Vector2(10, -2.89f);

                enermies.Add(enermy);
                enermyController.Init(enermies);

                ++cntEnermy;

                m_delta = 0f;
                if (m_spawnTime - m_spawnSpeed > 0)
                    m_spawnSpeed += 0.00005f;

            }
            if (cntEnermy == maxEnermy)
            {
                this.enermyGen = false;
            }
        }
    }

    public void Update(float deltaTime)
    {
        if (enermies.Count > 0)
        {
            enermyController.Move(deltaTime);
        }

        CheckSpawn();
    }

    public int GetCntEnermy()
    {
        return cntEnermy;
    }
    
    public int GetMaxEnermy()
    {
        return maxEnermy;
    }
}
