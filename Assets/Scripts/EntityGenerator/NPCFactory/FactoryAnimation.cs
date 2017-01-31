using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FactoryAnimation
{
    public FactoryAnimation()
    {

    }
    public IAnimCtrl Create(NPCData data)
    {
        //Debug.Log("craft NPCAnimCtrl");
        return new NPCAnimCtrl(data);
    }
}
