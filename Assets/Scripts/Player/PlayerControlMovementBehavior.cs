using UnityEngine;
using System.Collections;

public class PlayerControlMovementBehavior : MonoBehaviour {
    public VirtualRightJoystick RightJoystick;
    


    // Use this for initialization
    void Start () {
        
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
/* to do
 * move  rigid body to player - check
 * move player towards playercontrol - check
 * rename script to PlayerControlMovementBehavior
 * create new PlayerMovementBehavior script */