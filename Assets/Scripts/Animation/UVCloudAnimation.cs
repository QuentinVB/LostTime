using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVCloudAnimation : MonoBehaviour
{
    public Material mat;
    private Vector2 offset;
    private Vector2 size;

    private Renderer renderer;
    private float add;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;

        add = 10;      
    }
    // Update is called once per frame
    void Update()
    {
        
        offset = new Vector2(add++, 0);

        mat.mainTextureOffset = offset;

        Debug.Log(mat.mainTextureOffset);
        //offset the uv at the position and rescale based ont the size of the tile
        // renderer.material.SetTextureOffset("_MainTex", offset);
    }
}
