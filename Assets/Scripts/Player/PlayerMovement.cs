using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public VirtualLeftJoystick leftJoystick;
    public CharaAnimCtrl animCtrl;
    public float speed;

    private Rigidbody playerRigidbody;
    private Transform targetMovement;
    private Vector3 direction;
        
    private NavMeshObstacle playerObstacle;

    // Use this for initialization
    void Start()
    {
        speed = 4.0f;

        //playerRigidbody = gameObject.AddComponent<Rigidbody>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.mass = 150;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        animCtrl = GetComponent<CharaAnimCtrl>();
        playerObstacle = GetComponent<NavMeshObstacle>();

        SetPlayerObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        //send to the animator
        animCtrl.InputH = leftJoystick.LeftHorizontal();
        animCtrl.InputV = leftJoystick.LeftVertical();
   
        animCtrl.WalkMode = WalkMode.running;
        //Movement
        Vector3 move = new Vector3();
        move.z = leftJoystick.LeftVertical() * Time.deltaTime * speed;
        transform.Translate(move, Space.Self);

        //Rotation   
        PlayerRotation(leftJoystick.LeftHorizontal());
        //Debug.Log(string.Format("H: {0}, V : {1}, LJS : {2}", LeftJoystick.LeftHorizontal(), LeftJoystick.LeftVertical(), LeftJoystick.IsLeftJoystickUsed));
    }
    //initialize and sets property of the NavMeshObstacle
    private void SetPlayerObstacle()
    {
        playerObstacle.radius = 1;
        playerObstacle.carving = true;
        playerObstacle.carvingMoveThreshold = 0.1f;
        playerObstacle.carvingTimeToStationary = 0.2f;
        playerObstacle.carveOnlyStationary = true;
    }
    private void PlayerRotation(float xAxis)
    {
        transform.Rotate(Vector3.up, Time.deltaTime * xAxis * 100);       
    }
    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {

    }
}

