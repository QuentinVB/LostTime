using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


[XmlRoot("QuestContainer")]
class QuestContainer
{
    [XmlArray("QuestCollection")]
    [XmlArrayItem("Quest")]
    public List<Quest> questCollection = new List<Quest>();
    public Quest currentQuest;
    public List<LinkedActor> setUpActorList = new List<LinkedActor>();
}

class Quest
{

    [XmlAttribute("valuesList")]
    public string [] valuesList;
    [XmlAttribute("currentState")]
    public State currentState;
    [XmlAttribute("currentActivity")]
    string currentActivity;
    [XmlAttribute("questDescritpionID")]
    int questDescritpionID;
    [XmlAttribute("questID")]
    public string questID;

    [XmlAttribute("nameOfQuest")]
    List<LinkedActor> LinkedActorList = new List<LinkedActor>();
    [XmlArray("stateArray")]
    [XmlArrayItem("State")]
    public State[] stateArray;
}

public class LinkedActor
{
    public string id;
    public string name;
    public string job;
    //public float[] position;
}

public class KeyValue
{
    public string key;
    public string value;
}

public class State
{
    public string name;
    bool isSetUp { get; set; }
    List<Actor> actor = new List<Actor>();

    bool get()
    {
        return this.isSetUp;
    }
    void set()
    {
        this.isSetUp = true;
    }
}

class Actor
{
    string id;
    bool isSetUp { get; set; }
    void Update()
    {
    }

    List<IEvent> actionListSetUp = new List<IEvent>(); //  ??
    List<IEvent> actionListActive = new List<IEvent>(); // ??
    IEvent currentAction;
    bool get()
    {
        return this.isSetUp;
    }
    void set()
    {
        this.isSetUp = true;
    }
}
