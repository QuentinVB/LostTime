using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCAnimCtrl : IAnimCtrl, INPCComponent
{
    NPC NPCLinked;
    NPCData data;
    Animator animator;

    private float walkSpeed;
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
    private int waitForBoringDelay;

    private bool awaitThisUpdate;

    private float waitForActionCounter = 0; //in s
    private float waitForActionDelay; //in s

    private Transform transformOfTheCharacter;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float computedVelocity;


    public NPCAnimCtrl(NPCData data)
    {
        this.data = data;
        //Debug.Log("New NPCAnimCtrl Created");
        this.walkmode = data.walkmode;
        waitForBoringDelay = Toolbox.optimizedRand(10, 800); ;
        awaitThisUpdate = false;
        waitForActionDelay = 1.0f;
        waitForActionCounter = WaitForActionDelay;

        waitForBoringDelay = 800;
        walkSpeed = 5f;
    }
    public void setup(NPC NPCToBeLinked)
    {
        NPCLinked = NPCToBeLinked;
        animator = NPCLinked.GetComponent<Animator>();
        //Debug.Log("EndBinding NPCAnimCtrl");

        transformOfTheCharacter = NPCLinked.GetComponent<Transform>();

        isWalking = animator.GetBool("isWalking");
        isRunning = animator.GetBool("isRunning");
        isJumping = animator.GetBool("isJumping");
        isCatchingGround = animator.GetBool("isCatchingGround");
        isCatchingTable = animator.GetBool("isCatchingTable");   
    }

    public void update()
    {
        //check if the avatar get bored.
        getBored();

        //change the state of the animCtrl according to the environnement
        normalizedHorizontal =  Horizontal();
        normalizedVertical = Vertical() ;

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
        animator.SetFloat("horizontal", normalizedHorizontal);
        animator.SetFloat("vertical", normalizedVertical);

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);

        animator.SetBool("isCatchingGround", isCatchingGround);
        animator.SetBool("isCatchingTable", isCatchingTable);

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
    public float WaitForActionDelay { get { return waitForActionDelay; } private set { waitForActionDelay = value; } }
    private float WaitForActionResetAt { get { return waitForActionDelay; } set { waitForActionDelay = value; waitForActionCounter = waitForActionDelay; } }
    public WalkMode WalkMode { get { return walkmode; } internal set { walkmode = value; } }
    private float Horizontal()
    {
        return 0.0f;
    }
    private float Vertical()
    {
        computedVelocity = (lastPosition.magnitude - transformOfTheCharacter.position.magnitude) * Time.deltaTime * walkSpeed*100;
        //Debug.Log(computedVelocity);
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
                int randomNumber = UnityEngine.Random.Range(0, 2);
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
                animator.Play(idleState, -1, 0f);
                waitForBoringCounter = 0;
            }
        }
        else
        {
            waitForBoringCounter = 0;
        }
        //Debug.Log(String.Format("{0},{1}", waitForBoringDelay, waitForBoringCounter));

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
