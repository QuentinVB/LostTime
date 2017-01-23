
using System.Collections;

public interface IEvent
{
    string functionName { get; }
}

public struct Value : IEvent
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

public struct DialogueData : IEvent
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

public struct NPCData : IEvent
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

public struct NPCsData : IEvent
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

public struct ChangeBehaviorData : IEvent
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

public struct StateData : IEvent
{
    string QuestToSwitchAction;
    string TargetState;

    public string functionName
    {
        get
        {
            return functionName;
        }
    }
}

