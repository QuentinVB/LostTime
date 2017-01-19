using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSculptor : MonoBehaviour {

    // Use this for initialization
    //public Transform cubetest;
    public Transform characterLowPo;
    public Object clone;
    public GameObject cloned;

    void Start()
    {
        //for (int y = 0; y < 5; y++)
        //{
        //    for (int x = 0; x < 5; x++)
        //    {
        //        Instantiate(cubetest, new Vector3(x, y, 0), Quaternion.identity);
        //    }
        //}
        for (int i = 0; i < 3; i++)
        {
            clone = Instantiate(characterLowPo, new Vector3(i+0.8f, 0, 0), Quaternion.identity);
            clone.name = i.ToString();        
        }
    }
        // Update is called once per frame
    void Update () 
    {
		
	}
}
