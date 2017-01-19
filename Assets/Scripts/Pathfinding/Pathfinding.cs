using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Vector3 target;
    private NavMeshAgent agent;
    public List<GameObject> AllWaypoints = new List<GameObject>();
    public List<GameObject> NPCWaypoints = new List<GameObject>();
    public Rigidbody npcRigidbody;
    private Collider last;
    int _job = 0;
    bool _willMove = true;

    public Pathfinding(int job, bool willMove)
    {
        _job = job;
        _willMove = willMove;
    }
    
    // Use this for initialization
    void Start()
    {
        //If NPC never moves, remove Pathfinding script
        /*if(_willMove == false)
        {
            Destroy(GetComponent("Pathfinding"));
        }
        else*/
        {
            //Search for rigidbody - If not, create one.
            if (GetComponent<Rigidbody>() == null)
            {
                GetRigidBody();
            }

            //Sets NavMeshAgent values
            if (GetComponent<NavMeshAgent>() == null)
            {
                GetNavMeshAgent();
            }
            SetWaypoints();                 //Set waypoints
            target = SetDestination();      //Set destination
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(target);
    }

    //Will set another waypoint when destination is reached
    private void OnTriggerEnter(Collider other)
    {
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
        //Get random waypoint
        int w = Random.Range(0, NPCWaypoints.Count);
        //Set target to said waypoint
        return NPCWaypoints[w].transform.position;
    }

    private void MoveTo(Vector3 target)
    {
        agent.SetDestination(target);
    }

    //Will set the NavMeshAgent and its properties
    private void GetNavMeshAgent()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(10, 50);
        agent.speed = 2;
    }
    //Will set the Rigidbody and its properties
    private void GetRigidBody()
    {
        npcRigidbody = gameObject.AddComponent<Rigidbody>();
        npcRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    //Generates the list of waypoints for the NPC movement patern
    private void SetWaypoints()
    {
        //AllWaypoints list
        AllWaypoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
        //SpecificWaypoints list
        foreach (GameObject way in AllWaypoints)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(way.name, Toolbox.JobToString(_job), System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                NPCWaypoints.Add(way);
            }
        }
    }
}
