using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class EmptyRooms : IMazeAlgorithm
{
    public CellData[,] GetCells(int xMax, int yMax)
    {
        CellData[,] outputCellDatas = new CellData[xMax,yMax];
        for (int x = 0; x < xMax; x++)
        {
            for (int y = 0; y < yMax; y++)
            {
                outputCellDatas[x, y] = new CellData
                {
                    northDoor = false,
                    southDoor = false,
                    westDoor = false,
                    eastDoor = false,
                    xPos = x,
                    yPos = y
                };
            }
        }
        return outputCellDatas;
    }
    
}

