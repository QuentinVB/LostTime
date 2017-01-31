using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuestManager
{
    PositionEntity positionStorage;
    int amountOfCrowdToSpawn = 20;
    int jobPointer=0;

    public int AmountOfCrownToSpawn
    {
        get
        {
            return amountOfCrowdToSpawn;
        }
    }

    public QuestManager()
    {
        positionStorage = new PositionEntity(); 
        Debug.Log("Created QuestManager");
        //DO THINGs HERE
    }
    /// <summary>
    /// VERY DIRTY THING TO CREATE RANDOMLY NPC WANDERING ACROSS THE MAP
    /// </summary>
    /// <returns></returns>
    public NPCData createNewNpc()
    {
        string uuid = Guid.NewGuid().ToString();


        //int randomJobNumber = Toolbox.optimizedRand(0, 11);
        int randomJobNumber = jobTick();
        string job = Toolbox.jobEnumToString((job)randomJobNumber);

        Vector3 pos = positionStorage.getPosition(Mathf.Clamp(randomJobNumber,0,9));
        //Vector3 pos = new Vector3(UnityEngine.Random.Range(-2, 2), 1, UnityEngine.Random.Range(-2, 2));


        return new NPCData(uuid, job, pos, Quaternion.Euler(0, 0, 0));
    }
    private int jobTick()
    {
        int ret = jobPointer;
        jobPointer++;
        if (jobPointer > 11) jobPointer = 0;
        return ret;
    }
}
