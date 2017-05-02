using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour {

    private void Start()
    {
        GameObject.Find("letter").GetComponent<MeshRenderer>().enabled = (false);
    }

    public void putLetterenabled()
    {
        GameObject.Find("letter").GetComponent<MeshRenderer>().enabled = (true);
    }

    private void OnMouseDown()
    {
        GameObject.Find("TemporelleTutorielQuestController").GetComponent<TmpTutorielScript>().CreateLetter();
    }
}
