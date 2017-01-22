using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class QuestManager : MonoBehaviour
{
    private void Start()
    {
        setUP();
    }

    void editValue(IEvent Event)
    {

    }

    void dialogue(IEvent Event)
    {

    }
    void addNPC(IEvent Event)
    {

    }
    void switchState(IEvent Event)
    {

    }

    void setUP()
    {

    }

    public void ProcessEvent(string functionName, IEvent Event)
    {
        switch (functionName)
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
            case "switchState":
                switchState(Event);
                break;
            default:
                Debug.Log("Bad name of fuction");
                break;
        }
    }
}
