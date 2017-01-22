using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class QuestContainer : MonoBehaviour
{

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

        [XmlAttribute("valuesList")]
        string valuesList;
        [XmlAttribute("currentState")]
        string currentState;
        [XmlAttribute("currentActivity")]
        string currentActivity;
        [XmlAttribute("questDescritpionID")]
        int questDescritpionID;
        [XmlAttribute("questID")]
        int questID;

        [XmlAttribute("nameOfQuest")]
        List<LinkedActor> LinkedActorList = new List<LinkedActor>();
        [XmlArray("StateArray")]
        [XmlArrayItem("State")]
        State[] StateArray;


    }

    public class LinkedActor
    {

        string id;
        string name;
        string job;
    }


    public class State
    {
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
}
