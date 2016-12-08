using UnityEngine;
using System.Collections;

public class PlayerMovementBehavior : MonoBehaviour {
    public VirtualLeftJoystick LeftJoystick;
    public float MoveSpeed = 5.0f;
    public float Drag = 0.5f;
    public Vector3 MoveVector { get; set; }
    private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
        playerRigidbody = gameObject.AddComponent<Rigidbody>();
        playerRigidbody.drag = Drag;
        playerRigidbody.mass = 50;
    }

    // Update is called once per frame
    void Update () {
        Vector3 movement = new Vector3();
        movement.x = LeftJoystick.LeftVertical();
        movement.z = LeftJoystick.LeftHorizontal();
        transform.position +=  movement;

        MoveVector = PoolInput();
        Move();
    }
    private void Move()
    {
        playerRigidbody.AddForce(MoveVector * MoveSpeed);
    }

    private Vector3 PoolInput()
    {
        Vector3 movement = Vector3.zero;
        movement.x = LeftJoystick.LeftHorizontal();
        movement.z = movement.x = LeftJoystick.LeftVertical();

        if(movement.magnitude > 1)
        {
            movement.Normalize();
        }
        return movement;
    }
}
