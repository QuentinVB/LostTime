using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationMoveByJoystick : MonoBehaviour, IWalk
{
    public float speed;
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
        speed = 0.7f;
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
            transform.Translate(-0.2f, 0, 0, Space.Self);
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
            transform.Rotate(new Vector3(0, InputH * speed, 0));
        }

        if (InputV >= 0.3f || (InputH>0.3f||InputH<-0.3f))
        {
            InputV = 1.0f;
            InputH = 1.0f;
            transform.Translate(-0.1f, 0, 0, Space.Self);
        }

        //Key
        //reset if needed
        //if (Input.GetKey(KeyCode.Z) == false && Input.GetKey(KeyCode.S) == false)
        //{
        //    if (InputH < 0) InputH += 0.1f;
        //    if (InputH > 0) InputH -= 0.1f;
        //    if (InputH == -0.1f) InputH = 0;
        //}
        //if (Input.GetKey(KeyCode.Q) == false && Input.GetKey(KeyCode.D) == false)
        //{
        //    if (InputV < 0) InputV += 0.1f;
        //    if (InputV > 0) InputV -= 0.1f;
        //    if (InputV == -0.1f) InputV = 0;

        //}
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    if (awaitForJumpAgain == delayForJump)
        //    {
        //        InputH += 0.1f;
        //        transform.Translate(-0.1f, 0, 0, Space.Self);
        //        IsRunning = true;
        //    }
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    if (awaitForJumpAgain == delayForJump)
        //    {
        //        InputH -= 0.1f;
        //    }
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    if (awaitForJumpAgain == delayForJump)
        //    {
        //        inputV -= 0.1f;
        //        transform.Rotate(new Vector3(0, -1f, 0));
        //    }
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    if (awaitForJumpAgain == delayForJump)
        //    {
        //        inputV += 0.1f;
        //        transform.Rotate(new Vector3(0, 1f, 0));
        //    }
        //}

        IsRunning = (InputH != 0 || InputV != 0) ? true : false;

        //set the run (or not)
        //if (Input.GetKey(KeyCode.Z) == false
        //    && Input.GetKey(KeyCode.Q) == false
        //    && Input.GetKey(KeyCode.S) == false
        //    && Input.GetKey(KeyCode.D) == false
        //    ) IsRunning = false;
        ////Debug.Log(inputH);

    }

}