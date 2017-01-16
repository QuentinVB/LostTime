using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;

public class QuestManager : MonoBehaviour
{
    private delegate void ActionFunc();
    public QuestContainer questContainer { get { return questContainer; } set { questContainer = value; } }
    string currentQuest = null;
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

    public void dialogueFunction()
    {

    }

    public void toggleFunction()
    {

    }

    public void jumpFunction()
    {

    }
    public void nextFunction()
    {

    }

    public void endFunction()
    {

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

    public void setCurrentActionList(string entityName)
    {

        foreach (Quest quest in questContainer.questCollection)
        {
            if (quest.nameOfQuest == currentQuest)
            {
                foreach (Action action in quest.action)
                {
                    if (action.nameofAction == currentAction)
                    {
                        int cpt = 0;
                        foreach (actionBooleenByEntityPair actionBooleenByEntity in action.actionsBooleenByEntity)
                        {
                            int index = action.actionsBooleenByEntity.IndexOf(actionBooleenByEntity);
                            action.actionsBooleenByEntity[index] = true;
                        }
                    }
                }
            }
        }


        // getCurrentActionEntityList()
    }
}