using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Pathfinder()
    {

    }
    public Component Path(bool willMove)
    {
        return new Pathfinding(willMove);
    }
}


