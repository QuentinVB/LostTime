﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuestManager : MonoBehaviour
{

    //private EntitysInstaller installer;
    public int count = 0;
    public List<LinkedActor> NPCList = new List<LinkedActor>();
    //private QuestContainer questContainer;
    List<Entity> entityList = new List<Entity>();

    public QuestManager()
    {
        ProcessEvent s = new ProcessEvent(switchToDialogue);
    }
    private void Start()
    {

        //questContainer = new QuestContainer();
        //NPCList = questContainer.setUpActorList;
        setUP();

    }

    //void editValue(Value Event)
    //{
    //    int index = questContainer.questCollection.IndexOf(questContainer.currentQuest);
    //    if (questContainer.questCollection[index].valuesList[0] == Event.ID)
    //        questContainer.questCollection[index].valuesList[1] = Event.value;
    //}

    void dialogue(DialogueData Event)
    {

        // get interactionwithUser and t
    }
    //void addNPC(NPCData Event)
    //{
    //    NPCList.Clear();
    //    NPCList.Add(new LinkedActor {id = Event.id, name = Event.name, job = Event.job, position = Event.Position });
    //    count = 0;
    //    installer.InstallBindings();
    //}
    //void addNPCs(NPCsData Event)
    //{
    //    NPCList.Clear();
    //    foreach (NPCData NPC in Event.NPCList )
    //    NPCList.Add(new LinkedActor { id = NPC.id, name = NPC.name, job = NPC.job, position = NPC.Position });
    //    count = 0;
    //    installer.InstallBindings();
    //}
    //void switchState(StateData Event)
    //{
    //    int IndexOfQuest = 0;
    //    foreach (Quest quest in questContainer.questCollection) {
    //        if (quest.questID == Event.QuestToSwitchAction)
    //        {
    //            IndexOfQuest =  questContainer.questCollection.IndexOf(quest);
    //        }
    //    }

    //    for (int index = 0 ;questContainer.questCollection[IndexOfQuest].stateArray[index] != null; index++)
    //    {
    //        if (questContainer.questCollection[IndexOfQuest].stateArray[index].name == Event.TargetState)
    //        {
    //            questContainer.questCollection[IndexOfQuest].currentState = questContainer.currentQuest.stateArray[index];
    //        }
    //    }
    //}

    void setUP()
    {

    }

    /* Invocateur */
    public class ProcessEvent
    {
        private Command Command;

        public ProcessEvent(Command Cmd)
        {
            this.Command = Cmd;
        }

        public void executeCmd()
        {
            Command.execute();
        }

        public void setCommand(Command cmd)
        {
            this.Command = cmd;
        }
    }

    //public void ProcessEvent(string functionName, IEvent Event)
    //{
    //    
    //}


}
