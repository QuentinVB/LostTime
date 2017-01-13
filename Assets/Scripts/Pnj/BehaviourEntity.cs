using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IbehaviourEntity
{

}

public class BehaviourEntity : MonoBehaviour, IbehaviourEntity
{

    delegate void ActionFunc();
    //declarer un enum EnumActionFunc et le setter avec l'xml 

    // Use this for initialization
    void Start () {

        Dictionary<int, Delegate> actionFuncTab = new Dictionary<int, Delegate>();
        ActionFunc dialogue = dialogueFunction;
        ActionFunc toggle = toggleFunction;
        ActionFunc jump = jumpFunction;
        ActionFunc next = nextFunction;

        actionFuncTab.Add(0, dialogue);
        actionFuncTab.Add(1, toggle);
        actionFuncTab.Add(2, jump);
        actionFuncTab.Add(3, next);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
    }

    public void dialogueFunction()
    {

    }
    public void toggleFunction()
    {

    }

    public void jumpFunction()
    {

    }
    public void nextFunction()
    {

    }
}
