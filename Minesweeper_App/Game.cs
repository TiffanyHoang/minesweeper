using System;
using System.Linq;
namespace Minesweeper_App
{
    public class Game
    {
        private readonly Board _board;
        private readonly IIO _io;

        private int _moveOnSafeSquareCount = 0;
        public Game(Board board, IIO io)
        {
            _board = board;
            _io = io;
        }

        public void Run()
        {
            PrintHiddenSquaresBoard();
            var selectedSquarePosition = ReadSelectedSquarePosition();
            var isSelectedSquareMineSquare = IsSelectedSquareMineSquare(selectedSquarePosition);
           
            var isLastSafeSquare = _moveOnSafeSquareCount == GetTotalNumberOfSafeSquareOfABoard();
            if(isSelectedSquareMineSquare)
            {
                _io.Write(Instruction.LoseMessage());
            } 
            else if (isLastSafeSquare)
            {
                _io.Write(Instruction.WinMessage());
            } 
            else
            {
                _io.Write("Next move.");
            }

            PrintRevealedBoard(selectedSquarePosition);
        }

        private void PrintHiddenSquaresBoard()
        {
            var hiddenSquaresBoard = "";
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                   hiddenSquaresBoard += ".";
                }
                hiddenSquaresBoard += "\n";
            }
            _io.Write(hiddenSquaresBoard);
        }

        private void PrintRevealedBoard(Position selectedSquarePosition)
        {
            var hiddenSquaresBoard = "";
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                    if(selectedSquarePosition.Equals(new Position(i, j)))
                   {
                        if (_board.Grid[i, j] == SquareType.Safe)
                        {
                            var hint = HintGenerator.GetNumberOfMinesFromNeighbourSquares(_board, new Position(i, j)).ToString();
                            hiddenSquaresBoard += hint;
                        }
                        else
                        {
                            hiddenSquaresBoard += "*";
                        }
                   }
                   else 
                   {
                        hiddenSquaresBoard += ".";
                   }
                   
                }
                hiddenSquaresBoard += "\n";
            }
            _io.Write(hiddenSquaresBoard);
        }

        private bool IsSelectedSquareMineSquare(Position selectedSquarePosition)
        {
            if(_board.Grid[selectedSquarePosition.X,selectedSquarePosition.Y] == SquareType.Mine)
            {
                return true;
            } 
            else
            {
                _moveOnSafeSquareCount +=1;
                return false;
            }
        }
        private Position ReadSelectedSquarePosition()
        {
            _io.Write(Instruction.RequestSelectSquareToReveal());
            var input = _io.Read();
            var inputArray = input.Split(",").Select(int.Parse).ToArray();
            var selectedSquarePosition = new Position(inputArray[0], inputArray[1]);
            return selectedSquarePosition;
        }

        private int GetTotalNumberOfSafeSquareOfABoard()
        {
            var totalNumberOfSafeSquareOfABoard = 0;
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                   if(_board.Grid[i, j] == SquareType.Safe)
                   {
                       totalNumberOfSafeSquareOfABoard += 1; 
                   }
                }
            }
            return totalNumberOfSafeSquareOfABoard;

        }
    }
}
