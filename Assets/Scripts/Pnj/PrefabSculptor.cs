using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSculptor : MonoBehaviour {

    // Use this for initialization
    //public Transform cubetest;
    public Transform characterLowPo;
    public Object clone;
    public GameObject cloned;

    Object myPrefab;
    

    void Start()
    {
        myPrefab = Resources.Load("CharacterLowPo/CharacterLowPo");
        //for (int y = 0; y < 5; y++)
        //{
        //    for (int x = 0; x < 5; x++)
        //    {
        //        Instantiate(cubetest, new Vector3(x, y, 0), Quaternion.identity);
        //    }
        //}
        for (int i = 0; i < 3; i++)
        {
            clone = Instantiate(myPrefab, new Vector3(i + 0.8f, 0, 0), Quaternion.identity);
            clone.name = i.ToString();
            cloned = GameObject.Find(i.ToString());
            cloned.GetComponent<Transform>().Translate(0, 1.0f + i, 0);
        }
    }
        // Update is called once per frame
    void Update () 
    {
		
	}
}
