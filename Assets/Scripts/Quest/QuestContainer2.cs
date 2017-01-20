using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class QuestContainer2 : MonoBehaviour
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
        public string id;
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
        void Update() {
        }

        List<IAction> actionListSetUp = new List<IAction>(); //  ??
        List<IAction> actionListActive = new List<IAction>(); // ??

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
