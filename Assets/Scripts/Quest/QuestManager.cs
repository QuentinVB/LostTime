using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.IO;

public class QuestManager : MonoBehaviour
{
    public QuestContainer questContainer;
    public ProcessEvent _processEvent;
    public DialogueCollection dialogueCollection;

    public QuestManager()
    {
        _processEvent = new ProcessEvent();
        setUP();
    }



    void setUP()
    {
        questContainer = loadQuest();
        Debug.Log(questContainer.currentQuest);
        dialogueCollection = loadDialogue();
        Debug.Log(dialogueCollection.dialogueArray[0]);

        //  questContainer.questCollection[0].stateArray
    }

    public static QuestContainer loadQuest()
    {
        var serializer = new XmlSerializer(typeof(QuestContainer));
        using (var stream = new FileStream("C:\\Users\\Camille\\Desktop\\Quest1.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as QuestContainer;
        }
    }

    public static DialogueCollection loadDialogue()
    {
        var serializer = new XmlSerializer(typeof(DialogueCollection));
        using (var stream = new FileStream("C:\\Users\\Camille\\Desktop\\Dialogue.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as DialogueCollection;
        }
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

    public ActorAction [] getcurrentActionList(string name)
    {
        int indexQuest = 0;
        int indexState = 0;
        int indexActor = 0;

        for (; questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (questContainer.questCollection[indexQuest].questID == questContainer.currentQuest)
                for (; questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (questContainer.questCollection[indexQuest].stateArray[indexState].name == questContainer.questCollection[indexQuest].currentState)
                        for (; questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor] != null; indexActor++)
                        {
                            if (questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].name == name)
                                return questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentActions; // modifier pour renvoyer une liste d'Action
                        }
                }
        }

        return null;
    }
}

