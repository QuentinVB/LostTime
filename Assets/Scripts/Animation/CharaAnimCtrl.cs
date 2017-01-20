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
public class CharaAnimCtrl : MonoBehaviour {

    public Animator anim;
    //public float turnSpeed;
    //public float runSpeed;
    //public float walkSpeed;
    public InputMode inputMode = InputMode.byTransform;
    public WalkMode walkmode = WalkMode.idle;


    private float inputH;
    private float inputV;
    private float normalizedHorizontal;
    private float normalizedVertical;

    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isCatchingGround;
    private bool isCatchingTable;

    private int waitForBoringCounter = 0;
    private int waitForBoringDelay = 800;

    private bool awaitThisUpdate;
    private float waitForActionCounter = 0; //in s
    private float waitForActionDelay = 0; //in s

    private Transform transformOfTheCharacter;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float computedVelocity;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        transformOfTheCharacter= GetComponent<Transform>();

        isWalking = anim.GetBool("isWalking");
        isRunning = anim.GetBool("isRunning");
        isJumping = anim.GetBool("isJumping");
        isCatchingGround = anim.GetBool("isCatchingGround");
        isCatchingTable = anim.GetBool("isCatchingTable");

        awaitThisUpdate = false;
    }

    // Update is called once per frame
    void Update ()
    {

        //check if the player avatar get bored.
        getBored();

        //change the state of the animCtrl according to the environnement
        normalizedHorizontal = (inputMode == InputMode.byTransform) ? Horizontal() : InputH;
        normalizedVertical = (inputMode == InputMode.byTransform) ? Vertical() : InputV;

        resetBool();
        switch (walkmode)
        {
            case WalkMode.idle:
                break;
            case WalkMode.walking:
                isWalking = (normalizedHorizontal != 0 || normalizedVertical != 0) ? true : false;
                break;
            case WalkMode.running:
                isRunning = (normalizedHorizontal != 0 || normalizedVertical != 0) ? true : false;
                break;
            case WalkMode.sneaking:
                break;
            default:
                break;
        }
        

        //set the state of animation
        anim.SetFloat("horizontal", normalizedHorizontal);
        anim.SetFloat("vertical", normalizedVertical);

        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);

        anim.SetBool("isCatchingGround", isCatchingGround);
        anim.SetBool("isCatchingTable", isCatchingTable);

        //if set to true : no move !
        if (AwaitThisUpdate == true)
        {
            transformOfTheCharacter.position = lastPosition;
        }

        //save the last coordinate for computing
        lastPosition = transformOfTheCharacter.position;
        lastRotation = transformOfTheCharacter.rotation;

        //Debug.Log(string.Format("{0},  {1}, {2},{3}", normalizedVertical, normalizedHorizontal, waitForBoringCounter, isRunning));

    }
    public float InputH { get { return inputH; } set { inputH = Mathf.Clamp(value, -1.0f, 1.0f); } }
    public float InputV { get { return inputV; } set { inputV = Mathf.Clamp(value, -1.0f, 1.0f); } }
    public bool AwaitThisUpdate { get { return awaitThisUpdate; } private set { awaitThisUpdate = value; } }
    public WalkMode WalkMode { get { return walkmode; } internal set { walkmode = value; } }

    private float Horizontal()
    {
        return 0.0f;
    }
    private float Vertical()
    {
        computedVelocity = (lastPosition.magnitude - transformOfTheCharacter.position.magnitude)*Time.deltaTime;
        return Mathf.Clamp(computedVelocity, -1.0f, 1.0f); 
    }
    private void getBored()
    {
        if (normalizedHorizontal == 0 || normalizedVertical == 0)
        {
            waitForBoringCounter++;

            if (waitForBoringCounter > waitForBoringDelay)
            {
                string idleState;
                int randomNumber = UnityEngine.Random.Range(0, 1);
                switch (randomNumber)
                {
                    case 0:
                        idleState = "Idle2cough";
                        break;
                    case 1:
                        idleState = "Idle3Crossarm";
                        break;
                    default:
                        idleState = "Idle2cough";
                        break;
                }
                anim.Play(idleState, -1, 0f);
                waitForBoringCounter = 0;
            }
        }
        else
        {
            waitForBoringCounter = 0;
        }
    }
    private void resetBool()
    {
        isWalking = false;
        isRunning = false;
        isJumping = false;
        isCatchingGround = false;
        isCatchingTable = false;
    }
}
