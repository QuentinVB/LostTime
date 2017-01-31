
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FactoryPathfinding
{
    public FactoryPathfinding()
    {

    }
    public IPathfinding Create(NPCData data)
    {
        //Debug.Log("craft NPCPathfinding");
        return new NPCPathfinding(data);
    }
}
