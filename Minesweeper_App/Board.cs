using System;
using System.Collections.Generic;

namespace Minesweeper_App
{
    public enum SquareType
    {
        Safe,
        Mine
    }
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public SquareType[,] Grid { get; }
        public Board(int width, int height, List<Position> minePositions)
        {
            Width = width;
            Height = height;
            Grid = CreateGrid(minePositions);
        }

        private SquareType[,] CreateGrid(List<Position> minePositions)
        {
            var grid = new SquareType[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                   if(minePositions.Contains(new Position(i, j)))
                   {
                        grid[i, j] = SquareType.Mine;
                   }
                   else 
                   {
                        grid[i, j] = SquareType.Safe;
                   }
                }
            }
            return grid;
        }
    }
}
