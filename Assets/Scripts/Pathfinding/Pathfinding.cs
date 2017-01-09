using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Vector3 target;
    private NavMeshAgent agent;
    public List<GameObject> Waypoints = new List<GameObject>();
    public Rigidbody npcRigidbody;
    private Collider last;

    // Use this for initialization
    void Start()
    {
        GetNavMeshAgent();
        target = SetDestination();
        npcRigidbody = gameObject.AddComponent<Rigidbody>();
        agent.avoidancePriority = Random.Range(10, 50);
        agent.speed = 2;        //temp
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(target);
    }

    //Will set another waypoint when destination is reached
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this);
        if(other != last)
        {
            do {
                target = SetDestination();
            }
            while (target == other.transform.position);
            last = other;
        }
    }

    //Will set the destination of the NPC
    public Vector3 SetDestination()
    {
        //Stack waypoints in list
        Waypoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
        //Get random waypoint
        int w = Random.Range(0, Waypoints.Count);
        //Set target to said waypoint
        return Waypoints[w].transform.position;
    }

    private void MoveTo(Vector3 target)
    {
        agent.SetDestination(target);
    }

    //Will set the NavMeshAgent and its properties
    private void GetNavMeshAgent()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
    }
}
