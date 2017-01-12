using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public VirtualLeftJoystick LeftJoystick;
    public CharaAnimCtrl animCtrl;
    private Rigidbody playerRigidbody;
    private Transform targetMovement;
    private Vector3 direction;
        
    private NavMeshObstacle playerObstacle;

    private float speed;

    // Use this for initialization
    void Start()
    {
        speed = 4.0f;

        //playerRigidbody = gameObject.AddComponent<Rigidbody>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.mass = 150;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        animCtrl = GetComponent<CharaAnimCtrl>();

        SetPlayerObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        //send to the animator
        animCtrl.InputH = LeftJoystick.LeftHorizontal();
        animCtrl.InputV = LeftJoystick.LeftVertical();
   
        animCtrl.WalkMode = WalkMode.running;
        //Movement
        Vector3 move = new Vector3();
        move.x = -LeftJoystick.LeftVertical() * Time.deltaTime * speed;
        transform.Translate(move, Space.Self);

        //Rotation   
        PlayerRotation(LeftJoystick.LeftHorizontal());
        //Debug.Log(string.Format("H: {0}, V : {1}, LJS : {2}", LeftJoystick.LeftHorizontal(), LeftJoystick.LeftVertical(), LeftJoystick.IsLeftJoystickUsed));
        //Debug.Log(string.Format("X: {0}", move.x));

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

