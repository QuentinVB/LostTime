using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public interface IEvent
{
    void doSomething();
}


/// <summary>
/// 
/// Récepteur
/// 
/// </summary>
public class EventValue : IEvent
{
    [Inject]
    QuestManager _questnager;
    public string _value;
    public string _target;


    public EventValue(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void doSomething()
    {

    }
}

public class EventDialogue : IEvent
{
    [Inject]
    QuestManager _questnager;
    private int _dialogueId;

    public EventDialogue(string nameEvent, string dialogueId)
    {
        _dialogueId = int.Parse(dialogueId);
    }

    public void doSomething()
    {
    }
}

public class SwitchQuest : IEvent
{
    [Inject]
    QuestManager _questManager;
    public string _value;
    public string _target;
    int indexQuest = 0;


    public SwitchQuest(string value, string target)
    {

        _value = value;
        _target = target;
    }

    public void doSomething()
    {
        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _value)
            {
                _questManager.questContainer.currentQuest = _value;
                _questManager.questContainer.questCollection[indexQuest].currentState = _questManager.questContainer.questCollection[indexQuest].stateArray[0].name;

                // _questManager.questContainer.questCollection[indexQuest].stateArray[0].actorArray; //  create entity ; appel a entityManager
            }
        }
    }
}

public class SwitchState : IEvent
{
    [Inject]
    QuestManager _questManager;
    public string _value;
    public string _target;
    int indexQuest;
    int indexState;


    public SwitchState(string value, string target)
    {
        _value = value;
        _target = target;
    }


    public void doSomething()
    {

        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _questManager.questContainer.currentQuest)
                for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name == _value)
                    {
                        _questManager.questContainer.questCollection[indexQuest].currentState = _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name;
                        //  _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].LinkedActor // create entity;  appel a entityManager
                    }
                }
        }
    }
}

public class SwitchAction : IEvent
{
    [Inject]
    QuestManager _questManager;
    int indexQuest = 0;
    int indexState = 0;
    int indexActor = 0;
    int indexAction = 0;
    public string _value;
    public string _target;


    public SwitchAction(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void doSomething()
    {
        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _questManager.questContainer.currentQuest)
                for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name == _questManager.questContainer.questCollection[indexQuest].currentState)
                        for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor] != null; indexActor++)
                        {
                            if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].name == _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].currentActor)
                                for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListActive[indexAction] != null; indexAction++)
                                {
                                    if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListActive[indexAction].name == _value)
                                        _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentAction = _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListActive[indexAction];
                                }
                        }
                }
        }
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
