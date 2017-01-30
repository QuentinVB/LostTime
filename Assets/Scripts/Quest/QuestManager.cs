using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuestManager : MonoBehaviour
{
    public QuestContainer questContainer;
    public ProcessEvent _processEvent;

    public QuestManager()
    {
        _processEvent = new ProcessEvent();
        setUP();
    }



    public ActorAction getcurrentAction()
    {
        int indexQuest = 0;
        int indexState = 0;
        int indexActor = 0;
        ActorAction actorAction = null;


        for (; questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (questContainer.questCollection[indexQuest].questID == questContainer.currentQuest)
                for (; questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (questContainer.questCollection[indexQuest].stateArray[indexState].name == questContainer.questCollection[indexQuest].currentState)
                        for (; questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor] != null; indexActor++)
                        {
                            if (questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].name == questContainer.questCollection[indexQuest].stateArray[indexState].currentActor)
                                actorAction = questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentAction;
                        }
                }
        }

        return actorAction;
    }

    void setUP()
    {

    }

    /* Invocateur */
    public class ProcessEvent
    {
        private Command Command;

        public ProcessEvent()
        {
            this.Command = null;
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
}
