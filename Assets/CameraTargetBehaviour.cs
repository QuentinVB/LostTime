using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CameraTargetBehaviour : MonoBehaviour
{
    public VirtualRightJoystick rightJoystick;
    private float verticalInput;
    private float horizontalInput;
    private Transform initialPos;

    // Use this for initialization
    void Start()
    {
        initialPos.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = rightJoystick.RightVertical();
        horizontalInput = rightJoystick.RightHorizontal();
        if(verticalInput > 0.5 && transform.position.y <= 2.5)
        {
            transform.Translate(Vector3.up * 0.1f);
        }
        if (verticalInput < -0.5 && transform.position.y >= 0)
        {
            transform.Translate(Vector3.down * 0.1f);

        }
    }
}
