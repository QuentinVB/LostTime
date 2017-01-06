using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationMoveByPass : MonoBehaviour, IWalk
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


    // Use this for initialization
    void Start()
    {
        speed = 1.5f;
        inputH = 0;
        inputV = 0;
        awaitForJumpAgain = delayForJump;
        rbody = GetComponent<Rigidbody>();
    }
    //properties
    public bool IsJumping { get { return isJumping; } internal set { isJumping = value; } }
    public bool IsRunning { get { return isRunning; } internal set { isRunning = value; } }
    public float InputH { get { return inputH; } internal set { inputH = value; } }
    public float InputV { get { return inputV; } internal set { inputV = value; } }
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

        //Key
        //reset if needed
        if (Input.GetKey(KeyCode.Z) == false && Input.GetKey(KeyCode.S) == false)
        {
            if (InputH < 0) InputH += 0.1f;
            if (InputH > 0) InputH -= 0.1f;
            if (InputH == -0.1f) InputH = 0;
        }
        if (Input.GetKey(KeyCode.Q) == false && Input.GetKey(KeyCode.D) == false)
        {
            if (InputV < 0) InputV += 0.1f;
            if (InputV > 0) InputV -= 0.1f;
            if (InputV == -0.1f) InputV = 0;

        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (awaitForJumpAgain == delayForJump)
            {
                InputH += 0.1f;
                transform.Translate(-0.1f, 0, 0, Space.Self);
                IsRunning = true;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (awaitForJumpAgain == delayForJump)
            {
                InputH -= 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (awaitForJumpAgain == delayForJump)
            {
                inputV -= 0.1f;
                transform.Rotate(new Vector3(0, -1f, 0));
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (awaitForJumpAgain == delayForJump)
            {
                inputV += 0.1f;
                transform.Rotate(new Vector3(0, 1f, 0));
            }
        }
        //clamp the inputs
        inputH = Mathf.Clamp(inputH, -1.0f, 1.0f);
        inputV = Mathf.Clamp(inputV, -1.0f, 1.0f);
        //set the run (or not)
        if (Input.GetKey(KeyCode.Z) == false
            && Input.GetKey(KeyCode.Q) == false
            && Input.GetKey(KeyCode.S) == false
            && Input.GetKey(KeyCode.D) == false
            ) IsRunning = false;
        //Debug.Log(inputH);
    
}

}