using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


[XmlRoot("QuestContainer")]
public class QuestContainer
{
    [XmlArray("QuestCollection")]
    [XmlArrayItem("Quest")]
    public Quest[] questCollection;
    //public List<Quest> questCollection = new List<Quest>();

    public string currentQuest;
    public List<LinkedActor> setUpActorList = new List<LinkedActor>();
}

public class Quest
{

    [XmlAttribute("valuesList")]
    public string [] valuesList;
    [XmlAttribute("currentState")]
    public string currentState;
    [XmlAttribute("currentActivity")]
    string currentActivity;
    [XmlAttribute("questDescritpionID")]
    int questDescritpionID;
    [XmlAttribute("nameOfQuest")]
    public string questID;

    
    
    [XmlArray("stateArray")]
    [XmlArrayItem("State")]
    public State[] stateArray;
}

public class LinkedActor
{
    public string id;
    public string name;
    public string job;
    public float[] position;
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
    public Actor[] actorArray;
    public string currentActor;
    public LinkedActor[] LinkedActor;

    bool get()
    {
        return this.isSetUp;
    }
    void set()
    {
        this.isSetUp = true;
    }
}

public class Actor
{
    public string name;
    bool isSetUp { get; set; }
    void Update()
    {
    }
    
   // List<ActorAction> actionListSetUp = new List<ActorAction>(); //  ??
    public ActorAction [] actionListActive; // ??
    public ActorAction currentAction;
    bool get()
    {
        return this.isSetUp;
    }
    void set()
    {
        this.isSetUp = true;
    }
}

public class ActorAction
{
    public string name;
    public string switchValue;
    public string value;
    public string target;
}