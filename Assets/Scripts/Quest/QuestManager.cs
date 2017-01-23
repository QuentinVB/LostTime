using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuestManager : MonoBehaviour
{

    private EntitysInstaller installer;
    public int count;
    public List<LinkedActor> NPCList;
    private QuestContainer questContainer;

    private void Start()
    {
        questContainer = new QuestContainer();
        NPCList = questContainer.setUpActorList;
        installer = new EntitysInstaller();
        setUP();
    }

    void editValue(Value Event)
    {
        int index = questContainer.questCollection.IndexOf(questContainer.currentQuest);
        if (questContainer.questCollection[index].valuesList[0] == Event.ID)
            questContainer.questCollection[index].valuesList[1] = Event.value;
    }

    void dialogue(DialogueData Event)
    {

        // get interactionwithUser and t
    }
    void addNPC(NPCData Event)
    {
        NPCList.Clear();
        NPCList.Add(new LinkedActor {id = Event.id, name = Event.name, job = Event.job, position = Event.Position });
        count = 0;
        installer.InstallBindings();
    }
    void addNPCs(NPCsData Event)
    {
        NPCList.Clear();
        foreach (NPCData NPC in Event.NPCList )
        NPCList.Add(new LinkedActor { id = NPC.id, name = NPC.name, job = NPC.job, position = NPC.Position });
        count = 0;
        installer.InstallBindings();
    }
    void switchState(IEvent Event)
    {

    }

    void switchQuest(IEvent Event)
    {

    }

    void setUP()
    {
        // LOAD xmlconteneur
        count = 0;
        installer.InstallBindings();
    }

    //public void ProcessEvent(string functionName, IEvent Event)
    //{
    //    switch (functionName)
    //    {
    //        case "editValue":
    //            editValue(Event);
    //            break;
    //        case "dialogue":
    //            dialogue(Event);
    //            break;
    //        case "addNPC":
    //            addNPC(Event);
    //            break;
    //        case "addNPCs":
    //            addNPCs(Event);
    //            break;
    //        case "switchState":
    //            switchState(Event);
    //            break;
    //        case "switchQuest":
    //            switchQuest(Event);
    //            break;
    //        default:
    //            Debug.Log("Bad name of fuction");
    //            break;
    //    }
    //}


}
