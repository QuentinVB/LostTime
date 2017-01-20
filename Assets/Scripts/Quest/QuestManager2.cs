using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


interface IAction
{
}

public class QuestManager2 : MonoBehaviour
{

    delegate void Action(IAction Action);
    Dictionary<int, Delegate> ProcessAction;

    private void Start()
    {
        Dictionary<int, Delegate> actionFuncTab = new Dictionary<int, Delegate>();
        Action dialogue = dialogueFunction;
        Action editValue = editValueFunction;
        Action addNPC = addNPCFunction;
        Action switchState = switchStateFunction;


        actionFuncTab.Add(0, dialogue);
        actionFuncTab.Add(1, editValue);
        actionFuncTab.Add(2, addNPC);
        actionFuncTab.Add(3, switchState);
    }

    void editValueFunction(IAction action)
    {

    }

    void dialogueFunction(IAction action)
    {

    }
    void addNPCFunction(IAction action)
    {

    }
    void switchStateFunction(IAction action)
    {

    }

    void setUP()
    {

    }
}
