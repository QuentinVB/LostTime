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

    QuestManager _questManager;
    [Inject]
    Command _concreteCommand;
    IEvent _event;
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        catchEvent();
    }

    public void catchEvent()
    {
        _event = getEvent();
        _concreteCommand = new ConcreteCommand(_event);
        
        
        switch (_event.getNameEvent())
        {
            case "editValue":
                editValue(Event);
                break;
            case "dialogue":
                dialogue(Event);
                break;
            case "addNPC":
                addNPC(Event);
                break;
            case "addNPCs":
                addNPCs(Event);
                break;
            case "switchState":
                switchState(Event);
                break;
            case "switchQuest":
                switchQuest(Event);
                break;
            default:
                Debug.Log("Bad name of function");
                break;
        }

        s.setCommand(_concreteCommand);
        s.executeCmd();
    }
    public IEvent getEvent()
    {
        return new 
    }
}