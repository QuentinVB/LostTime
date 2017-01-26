using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// Allow to generate a maze based on the given algorithm
/// global Z+ : "+y value" and North direction
/// global Z- : "-y value" and South direction
/// global X+ : "+x value" and East direction
/// global X- : "-x value" and West direction 
/// </summary>
public class mazeGenerator : MonoBehaviour {

    Room[,] labyrinth;
    public int xMax;
    public int yMax;
    public Algo choosedAlgorithm;

    /// <summary>
    /// Initializes a new instance of the <see cref="mazeGenerator"/> class.
    /// </summary>
    /// <param name="xMax">The x maximum.</param>
    /// <param name="yMax">The y maximum.</param>
    public mazeGenerator(int xMax,int yMax)
    {
        this.xMax = xMax;
        this.yMax = yMax;
        useThisAlgorithm(Algo.empty);
    }


    /// <summary>
    /// Use this for initialization and start the instance, 
    /// change the line choosedAlgorithm with your enum linked to your algorithm to test
    /// on start the maze is genreated
    /// </summary>
    void Start()
    {
        xMax = 8;
        yMax = 8;
        choosedAlgorithm = Algo.odd;
        labyrinth = new Room[xMax, yMax];

        //fill the labyrinth with rooms according to the algorithm wanted
        useThisAlgorithm(choosedAlgorithm);
    }

    /// <summary>
    /// Uses this algorithm. 
    /// Switch function allowing to switch the maze generator algorithm
    /// </summary>
    /// <param name="choosedAlgorithm">The choosed algorithm.</param>
    private void useThisAlgorithm(Algo choosedAlgorithm)
    {
        IMazeAlgorithm algoToUse = new EmptyRooms(); ;
        switch (choosedAlgorithm)
        {
            case Algo.empty:
                algoToUse = new EmptyRooms();
                break;
            case Algo.odd:
                algoToUse = new OddCorridor();
                break;
            default:
                algoToUse = new EmptyRooms();
                break;
        }
        GenerateBasedOnAlgorithm(algoToUse,xMax,yMax);
    }

    private void GenerateBasedOnAlgorithm(IMazeAlgorithm source, int xMax, int yMax)
    {
        CellData[,] sourcesCells = source.GetCells(xMax,yMax);
        for (int x = 0; x < xMax; x++)
        {
            for (int y = 0; y < yMax; y++)
            {
                labyrinth[x, y] = new Room(
                    new CellData
                    {
                        northDoor = (y == yMax - 1) ? true : sourcesCells[x, y].northDoor,
                        southDoor = (y == 0) ? true : sourcesCells[x, y].southDoor,
                        westDoor = (x == 0) ? true : sourcesCells[x, y].westDoor,
                        eastDoor = (x == xMax - 1) ? true : sourcesCells[x, y].eastDoor,
                        xPos = x,
                        yPos = y
                    }
                    );
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //TODO : regenerate the labyrinth on change of the inspector
		
	}
}
//toolbox
/// <summary>
/// A simple class made to store the datas of a maze cell
/// </summary>
public class CellData
{
    public bool northDoor;
    public bool southDoor;
    public bool westDoor;
    public bool eastDoor;
    public int xPos;
    public int yPos;
}
/// <summary>
/// add your algorithm into the enum
/// </summary>
public enum Algo
{
    empty,
    odd,

}