using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

 class Entity : MonoBehaviour
{
    [Inject]
    ISculptor _sculptor;
    [Inject]
    IPosition _position;
    [Inject]
    IpathFinding pathFinding;
    [Inject]
    IBehaviourEntity behaviourEntity;
    [Inject]
    LinkedActor who;
    [Inject]
    QuestManager questManager;
    string _name;
    string _id;
    GameObject entity;

    public void setUp()
    {
        Debug.Log(string.Format("questManager: {0}", questManager == null ? "is null" : "is not null"));
        _name = who.name;
        _id = who.id;
        entity = PrefabByName(_name);
        entity.transform.position = getPosition(); // get the Iposition Vector3 and set the scupltor tranform
    }

    public  GameObject PrefabByName(string name)
    {
        Debug.Log("getprefab");
        return _sculptor.PrefabByName(name);
    }

    public Vector3 getPosition()
    {
        return _position.getPosition();
    }

    public void OnTriggerEnter(Collider other)
    {
    }
}
