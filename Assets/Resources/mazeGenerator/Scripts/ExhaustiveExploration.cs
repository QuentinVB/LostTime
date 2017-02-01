using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class ExhaustiveExploration : IMazeAlgorithm
{
    int mazeX;
    int mazeY;
    RandomFuzionCellData[,] buildingMaze;
    int randX;
    int randY;
    int randWall;


    public CellData[,] GetCells(int xMax, int yMax)
    {
        CellData[,] outputCellDatas = new CellData[xMax, yMax];
        buildingMaze = new RandomFuzionCellData[xMax, yMax];
        int i = 0;
        mazeX = xMax;
        mazeY = yMax;
        int nextCell;

        //Setting the cell's data
        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {
                buildingMaze[x, y] = new RandomFuzionCellData
                {
                    id = i,
                    northWall = true,
                    southWall = true,
                    eastWall = true,
                    westWall = true,
                    xPos = x,
                    yPos = y,
                    visited = false
                };
                i++;
            }
        }

        //Loop starting around here
        //Get a random cell
        //Store it's id
        //Check it as visited
        //Get next moves possible
        //Get one at random
        //Break the wall

        //Translate to the final output.
        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {
                outputCellDatas[x, y] = new CellData
                {
                    northDoor = buildingMaze[x, y].northWall,
                    southDoor = buildingMaze[x, y].southWall,
                    eastDoor = buildingMaze[x, y].eastWall,
                    westDoor = buildingMaze[x, y].westWall,
                    xPos = buildingMaze[x, y].xPos,
                    yPos = buildingMaze[x, y].yPos
                };
            }
        }
        return outputCellDatas;
    }

    public class RandomFuzionCellData
    {
        public bool northWall;
        public bool southWall;
        public bool westWall;
        public bool eastWall;
        public int xPos;
        public int yPos;
        public int id;
        public bool visited;
    }
}
