using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Value 
{
    public string ID;
    public string value;
    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}





public struct DialogueData 
{
    string TargetEntity;
    int DialogueID;
    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}



public struct NPCData 
{
    public float[] Position;
    public string name;
    public string id;
    public string job;
    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}

public struct NPCsData 
{
    public NPCData[] NPCList;
    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}

public struct ChangeBehaviorData 
{
    //string functionName;
    string BehaviorType;
    int valueListToMatch;

    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}

public struct StateData 
{
    public string QuestToSwitchAction;
    public string TargetState;

    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}


public interface IEvent
{
    string getNameEvent();
    void doSomething();
}


/// <summary>
/// 
/// Récepteur
/// 
/// </summary>
public class EventValue : IEvent
{
    public string _nameEvent;
    public int ID;
    public string value;

    public EventValue() { }

    public string getNameEvent()
    {
        return this._nameEvent;
    }

    public void doSomething()
    {

        Debug.Log(string.Format("id = {0}, value = {1}", ID, value));
    }
}

public class EventDialogue : IEvent
{
    public string _nameEvent;
    private int _dialogueId;

    public EventDialogue(int dialogueId)
    {
        _dialogueId = dialogueId;
    }

    public string getNameEvent()
    {
        return this._nameEvent;
    }

    public void doSomething()
    {
        Debug.Log(string.Format("{0}", toto));
    }
}


public interface Command
{
    void execute();
}


/// <summary>
/// 
/// Commande concrète
/// 
/// </summary>
/// 

public class ConcreteCommand : Command
{
    private IEvent _action;

    public ConcreteCommand(IEvent action)
    {
        this._action = action;
    }

    public void execute()
    {
        this._action.doSomething();
    }
}
