using UnityEngine;
using System.Collections;

public class PlayerMovementBehavior : MonoBehaviour {
    public VirtualLeftJoystick LeftJoystick;
    public float MoveSpeed = 5.0f;
    public float Drag = 0.5f;
    public Vector3 MoveVector { get; set; }
    private Rigidbody playerRigidbody;
    private Vector3 movement;


    // Use this for initialization
    void Start () {
        playerRigidbody = gameObject.AddComponent<Rigidbody>();
        playerRigidbody.drag = Drag;
        playerRigidbody.mass = 50;
    }

    // Update is called once per frame
    void Update () {

        MoveVector = PoolInput();
        Move();
        transform.position += movement;
    }
    private void Move()
    {
        playerRigidbody.AddForce(MoveVector * MoveSpeed);
    }

    private Vector3 PoolInput()
    {
        movement = Vector3.zero;
        movement.z = -LeftJoystick.LeftHorizontal();
        movement.x = LeftJoystick.LeftVertical();

        if(movement.magnitude > 1)
        {
            movement.Normalize();
        }
        return movement;
    }
}
