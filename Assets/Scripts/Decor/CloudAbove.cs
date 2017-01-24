using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAbove : MonoBehaviour {
    private Renderer render;
    public float scrollSpeed;

    // Use this for initialization
    void Start () {
        render = GetComponent<Renderer>();
        scrollSpeed = 0.1f;

    }
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * scrollSpeed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
