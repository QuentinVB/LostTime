using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class OddCorridor : IMazeAlgorithm
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
                    westDoor = (y % 2 > 0) ? true : false,
                    eastDoor = (y % 2 > 0) ? true : false,
                    xPos = x,
                    yPos = y
                };
            }
        }

        return outputCellDatas;
    }
}

