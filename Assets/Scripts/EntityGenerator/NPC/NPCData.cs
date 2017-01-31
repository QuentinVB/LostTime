using UnityEngine;

public class NPCData : IEvent
{
    public readonly string name;
    public readonly string job;
    public readonly string id;
    public readonly bool willMove;
    public readonly WalkMode walkmode;
    readonly Vector3 position;
    readonly Quaternion rotation;

    public NPCData(string name,string job,Vector3 initialPos,Quaternion initialRot)
    {
        this.name = name;
        this.job= job;
        this.position = initialPos;
        this.rotation = initialRot;
        willMove = true;
        walkmode = WalkMode.walking;
        //Debug.Log("craft NPCData");
    }
    public Vector3 Position
    {
        get
        {
            return position;
        }
    }

    public Quaternion Rotation
    {
        get
        {
            return rotation;
        }
    }
    public override string ToString()
    {
        return string.Format("uuid : {0}, pos {1}, job : {2}", name, position.ToString(), job);

    }
}