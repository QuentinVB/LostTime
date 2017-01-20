using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;

public class QuestManager : MonoBehaviour
{
    private delegate void ActionFunc(string Entity);
    public QuestContainer questContainer;
    public List<UsefulEntityForCurrentQuest> usefulEntityForCurrentQuest;
    public string currentQuest = null;
    string currentAction = null;

    //declarer un enum EnumActionFunc et le setter avec l'xml 

    void Start()
    {
        questContainer = Load("C:\\Users\\Camille\\Desktop\\Quest.xml");

        Dictionary<int, Delegate> actionFuncTab = new Dictionary<int, Delegate>();
        ActionFunc dialogue = dialogueFunction;
        ActionFunc toggle = toggleFunction;
        ActionFunc jump = jumpFunction;
        ActionFunc next = nextFunction;
        ActionFunc end = endFunction;

        actionFuncTab.Add(0, dialogue);
        actionFuncTab.Add(1, toggle);
        actionFuncTab.Add(2, jump);
        actionFuncTab.Add(3, next);
        actionFuncTab.Add(4, end);
    }

    public void dialogueFunction(string Entity)
    {

    }
    public void toggleFunction(string entityName)
    {
        foreach (Quest quest in questContainer.questCollection) // navigation dans la liste des quest
        {
            if (quest.nameOfQuest.Equals(currentQuest))
            {
                foreach (Action action in quest.action) // navigtion liste action
                {
                    if (action.nameofAction.Equals(currentAction))
                    {
                        foreach (KeyValuePair<string, bool> actionBooleenByEntity in action.actionsBooleenByEntity) // navigation dans la liste des entité concernée par l'action en cours
                        {
                            if (actionBooleenByEntity.Key.Equals(entityName))
                            {
                                int index = action.actionsBooleenByEntity.IndexOf(actionBooleenByEntity); // recupere  dans la liste des entité concernée par l'action en cours , l'entité qui nous interresse
                                action.actionsBooleenByEntity.RemoveAt(index); // supprime l'action
                                action.actionsBooleenByEntity.Insert(index, new KeyValuePair<string, bool>(entityName, true)); // recree l'action et la set

                            }
                        }
                    }
                }
            }
        }
    }


    public void jumpFunction(string entityName)
    {
        foreach (Quest quest in questContainer.questCollection) // navigation dans la liste des quest
        {
            if (quest.nameOfQuest.Equals(currentQuest))
            {
                foreach (Action action in quest.action) // navigtion liste action
                {
                    if (action.nameofAction.Equals(currentAction))
                    {
                        foreach (KeyValuePair<string, bool> actionBooleenByEntity in action.actionsBooleenByEntity) // navigation dans la liste des entité concernée par l'action en cours
                        {
                            if (actionBooleenByEntity.Key.Equals(entityName))
                            {
                                int index = action.actionsBooleenByEntity.IndexOf(actionBooleenByEntity); // recupere  dans la liste des entité concernée par l'action en cours , l'entité qui nous interresse
                                action.actionsBooleenByEntity.RemoveAt(index); // supprime l'action
                                action.actionsBooleenByEntity.Insert(index, new KeyValuePair<string, bool>(entityName, true)); // recree l'action et la set
                                
                               // Write()
                            }
                        }
                    }
                }
            }
        }
    }
    public void nextFunction(string Entity)
    {

    }

    public void endFunction(string Entity)
    {
        // destruction  de l'entité (Idispose)
    }

    public void Write(QuestContainer questContainer, string FileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(QuestContainer));
        TextWriter writer = new StreamWriter(FileName);

        // Serialize the object, and close the TextWriter.
        serializer.Serialize(writer, questContainer);
        writer.Close();
    }

    public QuestContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(QuestContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as QuestContainer;
        }
    }





    public List<UsefulEntityForCurrentQuest> getCurrentEntityList()
    {
        foreach(Quest quest in questContainer.questCollection) // navigation dans la liste des quest
        {
            if (quest.nameOfQuest.Equals(currentQuest))
            {
                usefulEntityForCurrentQuest = quest.usefulEntityForCurrentQuest;
                // a terminer
            }
        }
        return usefulEntityForCurrentQuest;
    }
}