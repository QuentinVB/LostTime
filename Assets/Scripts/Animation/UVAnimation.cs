using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVAnimation : MonoBehaviour {
    public int UVTileX = 4;
    public int UVTileY = 4;
    public int fps = 30;
    private int uIndex = 0;
    private int vIndex = 0;
    private int index;
    private Vector2 size;
    private Vector2 offset;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        //size of each tile
        size = new Vector2(1.0f / UVTileY, 1.0f / UVTileX);
        objectRenderer.material.SetTextureScale("_MainTex", size);
    }
    // Update is called once per frame
    void Update () {
        //set index
        index = (int)(Time.time * fps);

        //cut index based on the current frame from the begining
        index = index % (UVTileX * UVTileY);  
        uIndex = index % UVTileY;
        vIndex = index / UVTileX;

        offset = new Vector2(uIndex * size.x, 1.0f - size.y - vIndex * size.y);

        //offset the uv at the position and rescale based ont the size of the tile
        objectRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
