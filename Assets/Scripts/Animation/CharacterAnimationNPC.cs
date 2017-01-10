using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationNPC : MonoBehaviour
{
    public Animator anim;
    private int waitForToLong = 0;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player avatar get bored...
        getBored();
    }
    private void getBored()
    {      
            waitForToLong++;
            if (waitForToLong > 900)
            {
                anim.Play("Idle2cough", -1, 0f);
                waitForToLong = 0;
            }
    }
}
