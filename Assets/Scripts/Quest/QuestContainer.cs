using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.Collections;
using UnityEngine;


[XmlRoot("QuestContainer")]
public class QuestContainer
{
    [XmlArray("QuestCollection")]
    [XmlArrayItem("Quest")]
    public List<Quest> questCollection = new List<Quest>();
    public string nameOfcurrentQuest;
}

public class Quest
{

    [XmlAttribute("nameOfQuest")]
    public string nameOfQuest;
    public int id;
    List<UsefulEntityForThisQuest> usefulEntityForThisQuest = new List<UsefulEntityForThisQuest>();
    public List<Action> action = new List<Action>();
    String nameOfcurrentAction;

}

public class UsefulEntityForThisQuest
{
    string name;
    int id;
}

public class Action
{
    public string nameofAction;
    string typeOfAction; // choix multiple ou serie d'action (ActionJump or ActionNext)
    int actionFunc;

    //public Dictionary<string, bool> actionBooleenByEntity = new Dictionary<string, bool>();
    public List<KeyValuePair<string, bool>> actionBooleenByEntity = new List<KeyValuePair<string, bool>>();

    enum EnumActionFunc
    {
        dialogue = 0, // Displays a dialog between the entity and the player
        toggle = 1, // validate a booleen.
        jump = 2,   // if player choose an action , jump to it.
        next = 3,   // when all booleen are validate , jump to the next Action.
        end = 4 // Obligates the end of the action
    }
}

