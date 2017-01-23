using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour {

    Entity toto;
	// Use this for initialization
	void Start () {
        toto = new Entity(new HumanSculptor(), new PositionEntity(), new Pathfinding(), new prout());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
