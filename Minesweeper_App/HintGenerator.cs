using System;
using System.Collections.Generic;

namespace Minesweeper_App
{
    public static class HintGenerator
    {
        public static int GetNumberOfMinesFromNeighbourSquares(Board board, Position squarePosition)
        {
            var numberOfMinesFromNeighbourSquares = 0;

            var neighbourSquares = GetValidNeighbourSquarePositions(board, squarePosition);

            foreach (Position neighbourSquare in neighbourSquares)
            {
                if (board.Grid[neighbourSquare.X, neighbourSquare.Y] == SquareType.Mine)
                {
                    numberOfMinesFromNeighbourSquares++;
                }
            }
            return numberOfMinesFromNeighbourSquares;
        }

        private static List<Position> GetValidNeighbourSquarePositions(Board board, Position squarePosition)
        {
            var allNeighbourSquarePositions = GetAllNeighbourSquarePositions(squarePosition);
            var neighbourSquares = new List<Position>();
            foreach (Position neighbourSquarePosition in allNeighbourSquarePositions)
            {
                var isOutOfField = neighbourSquarePosition.X < 0 || neighbourSquarePosition.X > board.Width - 1 || neighbourSquarePosition.Y < 0 || neighbourSquarePosition.Y > board.Height - 1;

                if (!isOutOfField)
                {
                    neighbourSquares.Add(neighbourSquarePosition);
                }
            }
            return neighbourSquares;
        }

        private static List<Position> GetAllNeighbourSquarePositions(Position squarePosition)
        {
            var aboveRow = squarePosition.X - 1;
            var belowRow = squarePosition.X + 1;
            var leftCol = squarePosition.Y - 1;
            var rightCol = squarePosition.Y + 1;
            var allNeighbourSquarePositions = new List<Position>
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
            return allNeighbourSquarePositions;
        }
    }
}
