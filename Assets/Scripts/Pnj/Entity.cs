using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

 class Entity : MonoBehaviour
{
    ISculptor _sculptor;
    IPosition _position;
    IpathFinding _pathFinding;
    LinkedActor _who;

    QuestManager _questManager;
    string _name;
    string _id;
    GameObject entity;

    public Entity(ISculptor sculptor, IPosition position, IpathFinding pathFinding, LinkedActor who, QuestManager questManager)
    {
        Debug.Log("lol");
        _sculptor = sculptor;
        _position = position;
        _who = who;
        _questManager = questManager;
        setUp();
    }
    public void setUp()
    {
        Debug.Log(string.Format("sculptor: {0}", _sculptor == null ? "is null" : "is not null"));
        _name = _who.name;
        _id = _who.id;
        entity = PrefabByJob(_name);
        entity.transform.position = _position.getPosition( 0); // get the Iposition Vector3 and set the scupltor tranform
    }

    public  GameObject PrefabByJob(string name)
    {
        Debug.Log("getprefab");
        return _sculptor.PrefabByJob(name);
    }

  

    //public void OnTriggerEnter(Collider other)
    //{
    //}
}
