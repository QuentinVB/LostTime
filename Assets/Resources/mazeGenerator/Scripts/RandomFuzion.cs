using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class RandomFuzion : IMazeAlgorithm
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
        int newCellId;
        bool endFlag = false;

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
                    yPos = y
                };
                i++;
            }
        }

        //Loop starting around here
        do
        {
            //Get randoms
            randX = UnityEngine.Random.Range(0, mazeX); ;
            randY = UnityEngine.Random.Range(0, mazeY); ;
            randWall = UnityEngine.Random.Range(0, 3); ;
            if (!hasSameID(randWall))
            {
                //Destroy the wall and get the new cell ID
                newCellId = shatterWall(randWall);
                //Getting the cells to move'id
                foreach (RandomFuzionCellData cell in buildingMaze)
                {
                    if (cell.id == newCellId)
                    {
                        cell.id = buildingMaze[randX, randY].id;
                    }
                }
            }
            //Checking if script has finished.
            int d = 0;
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if(buildingMaze[x,y].id != buildingMaze[randX, randY].id)
                    {
                        d++;
                    }
                }
            }
            if (d == 0) endFlag = true;
        } while (endFlag == false);  //Algo loop end
        
        //Translate to the output.
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



    private bool hasSameID(int randWall)
    {
        switch (randWall)
        {
            case 0: //North (y-1)
                if (buildingMaze[randX, randY].yPos > 1)
                {
                    if (buildingMaze[randX, randY].id == buildingMaze[randX, randY - 1].id) return true;
                    else return false;
                }
                break;

            case 1: //South (y+1)
                if (buildingMaze[randX, randY].yPos < mazeY-1)
                {
                    if (buildingMaze[randX, randY].id == buildingMaze[randX, randY + 1].id) return true;
                    else return false;
                }
                break;

            case 2: //East (x+1)
                if (buildingMaze[randX, randY].xPos < mazeX-1)
                {
                    if (buildingMaze[randX, randY].id == buildingMaze[randX + 1, randY].id) return true;
                    else return false;
                }
                break;

            case 3: //West (x-1)
                if (buildingMaze[randX, randY].xPos > 1)
                {
                    if (buildingMaze[randX, randY].id == buildingMaze[randX - 1, randY].id) return true;
                    else return false;
                }
                break;
        }
        return false;
    }

    private int shatterWall(int randWall)
    {
        switch (randWall)
        {
            case 0: //North (y-1)
                if (buildingMaze[randX, randY].yPos > 1)
                {
                    buildingMaze[randX, randY].northWall = false;
                    buildingMaze[randX, randY - 1].southWall = false;
                    return buildingMaze[randX, randY - 1].id;
                }
                break;

            case 1: //South (y+1)
                if (buildingMaze[randX, randY].yPos < mazeY-1)
                {
                    buildingMaze[randX, randY].southWall = false;
                    buildingMaze[randX, randY + 1].northWall = false;
                    return buildingMaze[randX, randY + 1].id;
                }
                break;

            case 2: //East (x+1)
                if (buildingMaze[randX, randY].xPos < mazeX-1)
                {
                    buildingMaze[randX, randY].eastWall = false;
                    buildingMaze[randX + 1, randY].westWall = false;
                    return buildingMaze[randX + 1, randY].id;
                }
                break;

            case 3: //West (x-1)
                if (buildingMaze[randX, randY].xPos > 1)
                {
                    buildingMaze[randX, randY].westWall = false;
                    buildingMaze[randX - 1, randY].eastWall = false;
                    return buildingMaze[randX - 1, randY].id;
                }
                break;
        }
        return -1;
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
    }
}
