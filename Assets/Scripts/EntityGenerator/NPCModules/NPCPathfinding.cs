using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class NPCPathfinding : IPathfinding, INPCComponent
{
    NPC NPCLinked;
    NPCData data;

    Rigidbody npcRigidbody;
    NavMeshAgent agent;
    private Collider last;

    public List<GameObject> Waypoints = new List<GameObject>();
    public Vector3 target;

    bool _willMove;

    public NPCPathfinding(NPCData data)
    {
        this.data = data;
        _willMove = data.willMove;
        //Debug.Log("New NPCPathfinding Created");
    }
    public void setup(NPC NPCToBeLinked)
    {
        NPCLinked = NPCToBeLinked;
        //Debug.Log("EndBinding NPCPathfinding");
        
        //If NPC never moves, remove Pathfinding script from itself
        if (_willMove == false)
        {
            GameObject.Destroy(NPCLinked.GetComponent("Pathfinding"));
        }
        else
        {
            //Search for rigidbody - If not, create one.
            if (NPCLinked.GetComponent<Rigidbody>() == null)
            {
                GetRigidBody();
            }

            //Sets NavMeshAgent values
            if (NPCLinked.GetComponent<NavMeshAgent>() == null)
            {
                GetNavMeshAgent();
            }
            SetWaypoints();                 //Set waypoints
            target = SetDestination();      //Set destination
        }
    }

    public void update()
    {
        MoveTo(target);
    }

    private void MoveTo(Vector3 target)
    {
        agent.SetDestination(target);
    }
    //Will set another waypoint when destination is reached
    public void collide(Collider other)
    {
        if (other != last)
        {
            do
            {
                target = SetDestination();
            }
            while (target == other.transform.position);
            last = other;
        }
    }

    //Will set the destination of the NPC
    public Vector3 SetDestination()
    {
        //Get random waypoint
        int w = UnityEngine.Random.Range(0, Waypoints.Count);
        //Set target to said waypoint
        return Waypoints[w].transform.position;
    }
    //Will set the NavMeshAgent and its properties
    private void GetNavMeshAgent()
    {
        agent = NPCLinked.gameObject.AddComponent<NavMeshAgent>();
        agent.avoidancePriority = UnityEngine.Random.Range(10, 50);
        agent.speed = 0.8f;
    }
    //Will set the Rigidbody and its properties
    private void GetRigidBody()
    {
        npcRigidbody = NPCLinked.gameObject.AddComponent<Rigidbody>();
        npcRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    //Generates the list of waypoints for the NPC movement patern
    private void SetWaypoints()
    {
        //AllWaypoints list
        Waypoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
    }

    public Vector3 Direction
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public Quaternion Orientation
    {
        get
        {
            throw new NotImplementedException();
        }
    }
}
