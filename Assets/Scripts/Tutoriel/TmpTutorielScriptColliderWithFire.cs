using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpTutorielScriptColliderWithFire : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "AstridPlayer")
        {
            if (GameObject.Find("TemporelleTutorielQuestController") == true)
            {
                if (GameObject.Find("TemporelleTutorielQuestController").GetComponent<TmpTutorielScript>().getSetTutorialStep <= 2.5f)
                {
                    GameObject.Find("TemporelleTutorielQuestController").GetComponent<TmpTutorielScript>().getSetTutorialStep = 3;
                }
            }
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
