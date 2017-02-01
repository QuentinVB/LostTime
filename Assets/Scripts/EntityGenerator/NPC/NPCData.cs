using UnityEngine;

public class NPCData
{
    public readonly string name;
    public readonly string job;
    public readonly string id;
    public readonly bool willMove;
    public readonly WalkMode walkmode;
    public readonly bool canDie;
    readonly Vector3 position;
    readonly Quaternion rotation;

    public NPCData(string name,string job,Vector3 initialPos,Quaternion initialRot, bool willMove, WalkMode walkmode, bool canDie)
    {
        this.name = name;
        this.job= job;
        this.position = initialPos;
        this.rotation = initialRot;
        this.willMove = willMove;
        this.walkmode = walkmode;
        this.canDie = canDie;
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