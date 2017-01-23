
public interface IEvent
{
    string functionName { get; }
}

public struct Value : IEvent
{
    string ID;
    bool value;
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
    float[] Position;
    string name;
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

