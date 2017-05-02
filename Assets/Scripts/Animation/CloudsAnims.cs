using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsAnims : MonoBehaviour {
    private float seed;
    private float value;
    // Use this for initialization
    void Start () {
       seed = Random.Range(0.1f, 1.0f);
	}	
	// Update is called once per frame
	void Update ()
    {
        value = Mathf.Cos(Time.fixedTime * seed)*0.25f;
        transform.Translate(value, 0, 0);
	}
}
