using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Allow to chose a specified tile on the tileset based on the X/Y division of the tileset
/// </summary>
public class UVTileSelect : MonoBehaviour {
    public int UVTileX = 4;
    public int UVTileY = 4;
    private int uIndex = 0;
    private int vIndex = 0;
    public int index = 1;
    private Vector2 size;
    private Vector2 offset;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        //size of each tile
        size = new Vector2(1.0f / UVTileY, 1.0f / UVTileX);
        renderer.material.SetTextureScale("_MainTex", size);
    }
    // Update is called once per frame
    void Update () {
        //set index
        //cut index based on the current frame from the begining
        
        index = index % (UVTileX * UVTileY);
        uIndex = index % UVTileY;
        vIndex = index / UVTileX;

        offset = new Vector2(uIndex * size.x, 1.0f - size.y - vIndex * size.y);

        //offset the uv at the position and rescale based ont the size of the tile
        renderer.material.SetTextureOffset("_MainTex", offset);       
    }
}
