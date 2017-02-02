using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storm : MonoBehaviour
{
    public int outrand;
    private Image image;
    private bool clak;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        outrand = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (clak == true) { image.color = new Color(1, 1, 1, 0); }

        outrand = Random.Range(0, 300);
        //Debug.Log(outrand); ;
        if (outrand == 1)
        {
            image.color = new Color(1, 1, 1, 1);
            clak = true;
        }
        
    }
}
