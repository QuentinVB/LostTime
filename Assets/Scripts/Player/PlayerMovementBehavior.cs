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
            move.x = move.x / 15;
            move.z = move.z / 15;
            transform.Translate(move);

            PlayerRotation(RightJoystick.RightHorizontal());
            //Rotation

        }
    }
    private void PlayerRotation(float xAxis)
    {
        
        //To the right
        if (xAxis <= 0.9) { transform.Rotate(Vector3.down, Time.deltaTime * 100); }
        if (xAxis <= 0.7) { transform.Rotate(Vector3.down, Time.deltaTime * 75); }
        if (xAxis <= 0.5) { transform.Rotate(Vector3.down, Time.deltaTime * 50); }
        //if (xAxis >= 0.5 && xAxis > 0) { transform.Rotate(Vector3.up, Time.deltaTime * 15); }
        //To the left
        if (xAxis >= -0.9) { transform.Rotate(Vector3.up, Time.deltaTime * 100); }
        if (xAxis >= -0.7) { transform.Rotate(Vector3.up, Time.deltaTime * 75); }
        if (xAxis >= -0.5) { transform.Rotate(Vector3.up, Time.deltaTime * 50); }
        //if (xAxis >= -0.5 && xAxis < 0) { }
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

