using System;
using System.Collections.Generic;

namespace Minesweeper_App
{
     public static class HintGenerator
    {
        public static int GetNumberOfMinesFromNeighbourSquares(Board board, Position squarePosition)
        {
            var numberOfMinesFromNeighbourSquares = 0;

            var neighbourSquares = GetPositionOfNeighbourSquares(board, squarePosition);

            foreach(Position neighbourSquare in neighbourSquares)
            {
                
                if(board.Grid[neighbourSquare.X,neighbourSquare.Y] == SquareType.Mine)
                {
                    numberOfMinesFromNeighbourSquares++;
                }
            }
            return numberOfMinesFromNeighbourSquares;
        }

        private static List<Position> GetPositionOfNeighbourSquares(Board board,Position squarePosition)
        {
            var potentialNeighbourSquares = GetPositionOfPotentialNeighbourSquares(squarePosition);
            var neighbourSquares = new List<Position>();
            foreach (Position potentialNeighbourSquare in potentialNeighbourSquares)
            {
                var isOutOfField  = potentialNeighbourSquare.X < 0 || potentialNeighbourSquare.X > board.Width - 1 || potentialNeighbourSquare.Y < 0 || potentialNeighbourSquare.Y > board.Height - 1;

                if(!isOutOfField)
                {
                    neighbourSquares.Add(potentialNeighbourSquare);
                }
            }
            return neighbourSquares; 
        }
        
        private static List<Position> GetPositionOfPotentialNeighbourSquares(Position squarePosition)
        {
            var aboveRow = squarePosition.X - 1;
            var belowRow = squarePosition.X + 1;
            var leftCol = squarePosition.Y - 1;
            var rightCol = squarePosition.Y + 1;
            var potentialNeighbourSquares = new List<Position>
            {
                new Position(aboveRow, leftCol),
                new Position(aboveRow, squarePosition.Y),
                new Position(aboveRow, rightCol),
                new Position(squarePosition.X , leftCol),
                new Position(squarePosition.X , rightCol),
                new Position(belowRow, leftCol),
                new Position(belowRow, squarePosition.Y),
                new Position(belowRow, rightCol),
            }; 
            return potentialNeighbourSquares;
        }

    }
}
