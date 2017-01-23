using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, ISculptor, Iposition, IpathFinding
{

    ISculptor _sculptor;
    Iposition _position;
    IpathFinding pathFinding;
    IbehaviourEntity behaviourEntity;
    string _name;
    GameObject entity;

    
    Entity(ISculptor sculptor, Iposition position, IpathFinding _pathFinding, IbehaviourEntity _behaviourEntity)
    {
        name = "toto";
        _sculptor = sculptor;
        _position = position;
        pathFinding = _pathFinding;
        behaviourEntity = _behaviourEntity;
        entity = PrefabByName(_name);

        entity.transform.position = getPosition(); // get the Iposition Vector3 and set the scupltor tranform
    }


    public  GameObject PrefabByName(string name)
    {
        return _sculptor.PrefabByName(name);
    }

    public Vector3 getPosition()
    {
        return _position.getPosition();
    }
}
