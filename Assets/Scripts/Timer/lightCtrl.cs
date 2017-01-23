using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCtrl : MonoBehaviour {

    private List<GameObject> streetLights = new List<GameObject>();
    private float timer;
    private bool isLightOn;
    private bool isPreviousLightOn;
    float seuil;

    // Use this for initialization
    void Start () {
        seuil = 0.75f;
        //get the lamps and the time
        streetLights.AddRange(GameObject.FindGameObjectsWithTag("StreetLight"));
        timer = GetComponent<Timer>().CurrentTimeOfDay;

        ///set up the lamps
        isLightOn = false;
        isPreviousLightOn = isLightOn;
        switchLight();
    }	
	// Update is called once per frame
	void Update () {
        //set the state
        isPreviousLightOn = isLightOn;
        timer = GetComponent<Timer>().CurrentTimeOfDay;

        //is it time to switch the light ?
        isLightOn = (timer > seuil) ? true:false;
        if (isPreviousLightOn != isLightOn) switchLight();
        //Debug.Log(timer);
    }

    private void switchLight()
    {
        MeshRenderer renderer;
        Light light;
        foreach (GameObject lamp in streetLights)
        {
            //disable the renderer of the halo
            renderer = lamp.GetComponent<MeshRenderer>();
            renderer.enabled = isLightOn;
            //disable the light
            light = lamp.GetComponent<Light>();
            light.enabled = isLightOn;
        }
    }
}
