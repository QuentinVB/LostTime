using UnityEngine;
using System.Collections;

public class PlayerMovementBehavior : MonoBehaviour
{
    public VirtualRightJoystick RightJoystick;
    private Rigidbody playerRigidbody;
    private Transform targetMovement;
    private Vector3 direction;
    float lockPos = 0;

    // Use this for initialization
    void Start()
    {
        playerRigidbody = gameObject.AddComponent<Rigidbody>();
        playerRigidbody.mass = 150;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

    }

    // Update is called once per frame
    void Update()
    {
        if (RightJoystick._isJoystickUsed == true)
        {
            //Movement
            Vector3 move = new Vector3();
            move.x = RightJoystick.RightHorizontal();
            move.z = RightJoystick.RightVertical();
            move.x = move.x / 10;
            move.z = move.z / 10;
            transform.position += move;
            //Rotation

        }
    }
    private void PlayerRotation()
    {
        //Long bunch of if, depending on the horizontal input for the force speed of the rotation
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

