using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


//public class CommandPattern
//{

//        EventDialogue lamp = new EventDialogue();
//        EventValue v = new EventValue { ID = 11, value = "ceci est mon age" };
//        Command switchToDialogue = new DialogueCommand(lamp);
//        Command switchToValue = new ValueCommand(v);

//        ProcessEvent s = new ProcessEvent(switchToDialogue);
//        s.executeCmd();
//        Console.ReadLine();

//        s.setCommand(switchToValue);
//        s.executeCmd();
//        Console.ReadLine();
//}

public class Behaviour : MonoBehaviour
{
    public string _name;
    [Inject]
    QuestManager _questManager;
    Command _concreteCommand = null;
    IEvent _event = null;
    private void Start()
    {
        _name = "Forgeron";
    }

    private void OnTriggerEnter(Collider other)
    {
        catchEvent();
    }

    public void catchEvent()
    {
        _event = getEvent();
        _concreteCommand = new ConcreteCommand(_event);
        _questManager._processEvent.setCommand(_concreteCommand);
        _questManager._processEvent.executeCmd();

    }

    public IEvent getEvent()
    {
        ActorAction action = _questManager.getcurrentAction();

        switch (action.switchValue)
        {
            case "editValue":
              return   new EventValue(action.value, action.target);
            case "getDialogue":
                return new EventDialogue(action.value, action.target);
            case "switchQuest":
                return new SwitchQuest(action.value, action.target);
            case "switchState":
                return new SwitchState(action.value, action.target);
            case "switchAction":
                return new SwitchAction(action.value, action.target);
            default:
                Debug.Log("Bad name of function");
                break;
        }
        return null;
    }
}