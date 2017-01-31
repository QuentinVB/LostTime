using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuestManager
{
    PositionEntity positionStorage;
    public QuestManager()
    {
        positionStorage = new PositionEntity(); 
        Debug.Log("Created QuestManager");
        //DO THINGs HERE
    }
    /// <summary>
    /// VERY DIRTY THING TO CREATE RANDOMLY NPC WADERING ACROSS THE MAP
    /// </summary>
    /// <returns></returns>
    public NPCData createNewNpc()
    {
        string uuid = Guid.NewGuid().ToString();
        
        int randomJobNumber = UnityEngine.Random.Range(1, 10);
        string job = jobTranslator.jobEnumToString((job)randomJobNumber);

        Vector3 pos = positionStorage.getPosition(Mathf.Clamp(randomJobNumber,1,10));
        //Vector3 pos = new Vector3(UnityEngine.Random.Range(-2, 2), 1, UnityEngine.Random.Range(-2, 2));

        Debug.Log(string.Format("uuid : {0}, pos {1}, job : {2}", uuid, pos.ToString(), job));

        return new NPCData(uuid, job, pos, Quaternion.Euler(0, 0, 0));
    }
}
