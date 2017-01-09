using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationMoveByJoystick : MonoBehaviour, IWalk
{
    public float turnSpeed;
    public float runSpeed;
    private Vector3 position;
    private Vector3 rotation;
    private float inputH;
    private float inputV;
    private float baseinputH;
    private float baseinputV;
    private Rigidbody rbody;
    private bool isJumping;
    private bool isRunning;
    private readonly int delayForJump = 125;
    private int awaitForJumpAgain;
    public VirtualLeftJoystick joystick;
    private float x;
    private float y;

    // Use this for initialization
    void Start()
    {
        turnSpeed = 1.1f;
        runSpeed = 0.08f;
        inputH = 0;
        inputV = 0;
        awaitForJumpAgain = delayForJump;
        rbody = GetComponent<Rigidbody>();
    }
    //properties
    public bool IsJumping { get { return isJumping; } internal set { isJumping = value; } }
    public bool IsRunning { get { return isRunning; } internal set { isRunning = value; } }
    /// <summary>
    /// Gets the input horizontal normalized.
    /// </summary>
    /// <value>
    /// The input horizontal.
    /// </value>
    public float InputH { get { return inputH; } internal set { inputH = Mathf.Clamp(value, -1.0f, 1.0f) ; } }
    /// <summary>
    /// Gets the input vertical normalized.
    /// </summary>
    /// <value>
    /// The input vertical.
    /// </value>
    public float InputV { get { return inputV; } internal set { inputV = Mathf.Clamp(value, -1.0f, 1.0f); } }
    // Update is called once per frame
    void Update()
    {
        
        //is the space bare pressed ?
        IsJumping = Input.GetKey(KeyCode.Space) ? true : false;
        if (IsJumping == true && awaitForJumpAgain == delayForJump)
        {
            awaitForJumpAgain--;
            rbody.AddForce(0, 20, 0);
        }
        if (awaitForJumpAgain < delayForJump * 0.78 && awaitForJumpAgain > delayForJump * 0.5)
        {
            transform.Translate(-0.1f, 0, 0, Space.Self);
        }

        if (awaitForJumpAgain < delayForJump)
        {
            awaitForJumpAgain--;
            //reset the jump waiting delay if to 0
            awaitForJumpAgain = awaitForJumpAgain <= 0 ? delayForJump : awaitForJumpAgain;
        }
        //inputs
        InputH = joystick.LeftHorizontal();
        InputV = joystick.LeftVertical();

        //if rotate
        if (InputH != 0)
        {
            InputV *= 1.2f;
            transform.Rotate(new Vector3(0, InputH * turnSpeed, 0));
        }

        if (InputV >= 0.2f)
        {
            //InputV *= 1.2f;
            //InputH *= 1.2f;
            transform.Translate(- runSpeed , 0, 0, Space.Self);
        }

        IsRunning = (InputH != 0 || InputV != 0) ? true : false;

    }

}