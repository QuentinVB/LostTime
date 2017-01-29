using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathFinding
{
}
public class Pathfinder : IPathFinding
{
    public Pathfinder()
    {
        Debug.Log(string.Format("pathfinder check"));
    }
    public Component Path(bool willMove)
    {
        return new Pathfinding(willMove);
    }
}


