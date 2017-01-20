using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Value : IAction
{
    string functionName;
    string ID;
    bool value;
}

public struct DialogueData : IAction
{
    string functionName;
    string TargetEntity;
    int DialogueID;

}

public struct NPCData : IAction
{
    string functionName;
    float[] Position;
    string name;
}

public struct ChangeBehaviorData : IAction
{
    string functionName;
    string BehaviorType;
    int valueListToMatch;
}

public struct StateData : IAction
{
    string functionName;
    string QuestToSwitchAction;
    string TargetState;
}

