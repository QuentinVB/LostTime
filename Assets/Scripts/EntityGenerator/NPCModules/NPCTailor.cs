using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCTailor : ITailor, INPCComponent
{
    NPC NPCLinked;
    Material materialToSetUp;
    NPCData data;

    private Material defaultMaterial;

    public NPCTailor(NPCData data)
    {
        this.data = data;
        defaultMaterial = (Material)Resources.Load("CharacterLowPo/Materials/citizen1");
        //Debug.Log("New NPCTailor Created");
    }

    public void setup(NPC NPCToBeLinked)
    {
        NPCLinked = NPCToBeLinked;
        materialToSetUp = setTheTexture(data.job);
        NPCLinked.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = materialToSetUp;
        NPCLinked.name = data.name;
        //Debug.Log(String.Format("Tailor:{0}, job : {1}", materialToSetUp.ToString(), data.job));
    }

    private Material setTheTexture(string characterJob)
    {
        Material returned = defaultMaterial;
        string craft = string.Format("CharacterLowPo/Materials/{0}", characterJob);
        returned = (Material)Resources.Load(craft);
        if (returned == null)
        {
            Debug.Log(string.Format("Texture .{0}. does not exist, use default instead", characterJob));
            returned = (Material)Resources.Load("CharacterLowPo/Materials/citizen1");
        }
        return returned;
    }

    public void update()
    {
        throw new NotImplementedException();
    }
}

