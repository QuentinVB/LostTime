using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDefaultCtrl : MonoBehaviour {
    public Animator anim;
    public IWalk walk;
    public bool toggle;
    public bool jump;

    private int waitForToLong = 0;
    private float inputH;
    private float inputV;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        toggle = anim.GetBool("isRunning");
        walk = GetComponent<CharacterAnimationMoveByJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player avatar get bored...
        getBored();
        inputH = walk.InputH;
        inputV = walk.InputV;

        //Debug.Log(string.Format("H: {0}, V : {1}", inputH, inputV));

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        anim.SetBool("isRunning", walk.IsRunning);

        anim.SetBool("jump", walk.IsJumping);
        //anim.Play("Run", -1, 0f);
        //print(waitForToLong);
    }
    private void getBored()
    {
        if (walk.IsRunning == false && walk.IsJumping == false)
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
            waitForToLong = 0; //reset timer
        }
    }
}
