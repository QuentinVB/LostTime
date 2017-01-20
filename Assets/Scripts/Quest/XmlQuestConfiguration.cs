using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class XmlQuestConfiguration : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

        QuestContainer questContainer = new QuestContainer();
        questContainer.questCollection = new List<Quest>();
        questContainer.questCollection.Add(new Quest { name = "Quest1_Fleuriste", id = 1 });
        questContainer.questCollection.Add(new Quest { name = "Quest2_Forgeron", id = 2 });
        questContainer.questCollection.Add(new Quest { name = "Quest1_Dentiste", id = 3 });

        QuestManager questManager = new QuestManager();
        questContainer = questManager.Load("C:\\Users\\Camille\\Desktop\\Quest.xml");
        questContainer.questCollection.Add(new Quest { name = "Fleuriste", id = 11 });
        questContainer.questCollection.Add(new Quest { name = "Forgeron", id = 22 });
        questContainer.questCollection.Add(new Quest { name = "Dentiste", id = 33 });

        questManager.Write(questContainer, "C:\\Users\\Camille\\Desktop\\Quest1.xml");
    }
}