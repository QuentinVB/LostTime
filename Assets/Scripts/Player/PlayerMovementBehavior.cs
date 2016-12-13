using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementBehavior : MonoBehaviour {
    public VirtualRightJoystick RightJoystick;
   // public  Rigidbody playerRigidbody;

    // Use this for initialization
    void Start () {
      //  playerRigidbody = gameObject.AddComponent<Rigidbody>();
      //  playerRigidbody.mass = 150;
    }

    // Update is called once per frame
    void Update ()
    {
        if(RightJoystick._isJoystickUsed == true)
        {
            Vector3 move = new Vector3();
            move.x = RightJoystick.RightHorizontal();
            move.z = RightJoystick.RightVertical();

            move.x = move.x / 10;
            move.z = move.z / 10;

            transform.position += move;
        }
    }
}
