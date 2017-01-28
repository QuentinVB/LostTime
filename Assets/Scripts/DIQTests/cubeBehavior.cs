using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class cubeBehavior : MonoBehaviour {
    [Inject]
    public bool proof;

    [Inject]
    public IBar bar;

    [Inject]
    public IPathFinding pathfinder;
    //public cubeBehavior(bool proof, IBar bar)
    //{

    //    this.proof = proof;
    //}
    // Use this for initialization
    void Start () {
        Debug.Log(string.Format("cube is alive, proof : {0}",proof));
        Debug.Log(string.Format("cube has bar,  : {0}",bar.Msg));
        
        
    }
    	
	// Update is called once per frame
	void Update () {
	    	
	}
    

}
