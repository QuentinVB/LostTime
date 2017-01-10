using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WalkMode
{
    idle,
    walking,
    running,
    sneaking
}
public enum InputMode
{
    byTransform,
    byInput,
}

public class CharacterAnimationFree : MonoBehaviour, IAnimation {

    public Animator anim;
    public float turnSpeed;
    public float runSpeed;
    public float walkSpeed;
    public InputMode inputMode;

    private Rigidbody rbody;
    private Transform transform;

    private Vector3 position;
    private Vector3 rotationEuler;
    private Quaternion rotationQuad;

    private float baseinputH;
    private float baseinputV;

    private float inputH;
    private float inputV;

    private float valueVminThreshold;

    private bool walk;
    private bool jump;
    private bool run;

    private bool isJumping;
    private bool isRunning;
    private WalkMode walkmode;

    private int waitForToLong = 0;
    private float overTurn;


    public CharacterAnimationFree(InputMode inputMode)
    {
        this.inputMode = inputMode;
    }

    public bool Jump { get { return jump; } internal set { jump = value; } }
    public bool Walk { get { return walk; } internal set { walk = value; } }
    public bool Run { get { return run; } internal set { run = value; } }
    public float ValueVminThreshold { get { return valueVminThreshold; } }
    public WalkMode WalkMode { get { return walkmode; } internal set { walkmode = value; } }
    /// <summary>
    /// Gets the input horizontal normalized.
    /// </summary>
    /// <value>
    /// The input horizontal.
    /// </value>
    public float InputH { get { return inputH; } private set { inputH = Mathf.Clamp(value, -1.0f, 1.0f); } }
    /// <summary>
    /// Gets the input vertical normalized.
    /// </summary>
    /// <value>
    /// The input vertical.
    /// </value>
    public float InputV { get { return inputV; } private set { inputV = Mathf.Clamp(value, -1.0f, 1.0f); } }

    // Use this for initialization
    void Start()
    {
        turnSpeed = 25.0f;//deg.sec-1
        runSpeed = 4.5f;//m.s-1
        valueVminThreshold = 0.3f;
        overTurn = 0;

        inputMode = InputMode.byTransform;
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rbody = GetComponent<Rigidbody>();


        walk = anim.GetBool("isWalking");
        run = anim.GetBool("isRunning");
        jump = anim.GetBool("isJumping");

        rotationQuad = transform.rotation;
        position = transform.position;
     
    }
    // Update is called once per frame
    void Update()
    {
        //check if the player avatar get bored.
        getBored();

        Debug.Log(string.Format("H: {0}, V : {1}", inputH, inputV));

        //then send the AnimationStatus to the animator
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("isRunning", (WalkMode == WalkMode.running) ? true : false);
        anim.SetBool("isWalking", (WalkMode == WalkMode.walking) ? true : false);


        //anim.SetBool("Jump", walk.IsJumping);
    }
    private void getBored()
    {
        if(WalkMode == WalkMode.idle)
        { 
            waitForToLong++;
            if (waitForToLong > 800)
            {
                anim.Play("Idle2cough", -1, 0f);
                waitForToLong = 0;
            }
        }
        else
        {
            waitForToLong = 0;
        }
    }

    public void UpdateAnimData(float inputH, float inputV, WalkMode walkmode)
    {
        InputH = inputH;
        InputV = inputV;
        WalkMode = walkmode;
        if (walkmode == WalkMode.running)
        {
            if (InputV >= ValueVminThreshold)
            {
                
                transform.Translate(-runSpeed * Math.Abs(InputV) * Time.deltaTime, 0, 0, Space.Self);
            }
            if (InputH != 0)
            {
                overTurn = (InputV < 0.2f) ? 1.8f : 1;
                transform.Rotate(new Vector3(0, InputH * turnSpeed * Time.deltaTime * overTurn, 0));
            }
        }
    }

    public void UpdateAnimData(Transform transformThisUpdate, WalkMode walkmode)
    {
        WalkMode = walkmode;
        float DeltaPos=0;
        float DeltaRot = 0;
        if (WalkMode == WalkMode.running)
        {
            //position
            if (position != transformThisUpdate.position)
            {
                DeltaPos = position.magnitude - transformThisUpdate.position.magnitude;
            }
            InputH = DeltaPos / runSpeed;
            position = transformThisUpdate.position;

            //rotation
            DeltaRot = Quaternion.Angle(rotationQuad, transformThisUpdate.rotation);
            InputV = DeltaRot / turnSpeed;
            rotationQuad = transformThisUpdate.rotation;
        }
        
    }

}
