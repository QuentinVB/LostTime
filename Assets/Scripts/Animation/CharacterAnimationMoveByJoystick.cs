using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationMoveByJoystick : MonoBehaviour
{
    private float inputH;
    private float inputV;

    private float sendH;
    private float sendV;

    public VirtualLeftJoystick joystick;
    public IAnimation AnimationCtrl;

    private WalkMode walkmode;

    // Use this for initialization
    void Start()
    {
        inputH = 0;
        inputV = 0;
        AnimationCtrl = GetComponent<IAnimation>();
    }
    //properties
  // Update is called once per frame
    void Update()
    {
        //inputs
        inputH = joystick.LeftHorizontal();
        inputV = joystick.LeftVertical();

        //if rotate
        if (Math.Abs(inputH) < 0.4f)
        {
            inputV *= 1.2f;            
        }
        //if run
        if (inputH != 0 || inputV >= AnimationCtrl.ValueVminThreshold)
        {
            walkmode = WalkMode.running;
        }
        else
        {
            walkmode = WalkMode.idle;
        }

        sendH = inputH;
        sendV = inputV;

        AnimationCtrl.UpdateAnimData(inputH, inputV,walkmode);
    }

}