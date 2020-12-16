using System;
using System.Linq;
using System.Collections.Generic;
namespace Minesweeper_App
{
    public class Game
    {
        private readonly Board _board;
        private readonly IIO _io;
        
        private string[,] _displayBoard;
        private int _moveOnSafeSquareCount = 0;
        public Game(Board board, IIO io)
        {
            _board = board;
            _io = io;
            _displayBoard = new string[board.Width, board.Height];
        }

        public void Run()
        {
            PrintDisplayBoard();
            while (true)
            {
                var selectedSquarePosition = ReadSelectedSquarePosition();
                
                _moveOnSafeSquareCount += 1;

                var isSelectedSquareMineSquare = IsMineSquare(selectedSquarePosition);
                

                var isLastSafeSquare = _moveOnSafeSquareCount == GetTotalNumberOfSafeSquares();
                if (isSelectedSquareMineSquare)
                {
                    _io.Write(Instruction.LoseMessage());
                    FillDisplayBoard();
                    PrintDisplayBoard();
                    break;
                }

                if (isLastSafeSquare)
                {
                    _io.Write(Instruction.WinMessage());
                    FillDisplayBoard();
                    PrintDisplayBoard();

                    break;
                }

                if (!isLastSafeSquare)
                {
                    var hint = HintGenerator.GetNumberOfMinesFromNeighbourSquares(_board, selectedSquarePosition).ToString();
                    _displayBoard[selectedSquarePosition.X, selectedSquarePosition.Y] = hint;

                    PrintDisplayBoard();
                }
            }
        }
        public void PrintDisplayBoard()
        {
            var outputString = "";
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                    outputString += _displayBoard[i,j] ?? Instruction.HiddenSquareDisplayValue;
                }
                outputString += "\n";
            }
            _io.Write(outputString);
        }

        private void FillDisplayBoard()
        {
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                    _displayBoard[i,j] = IsMineSquare(new Position(i,j)) ? Instruction.MineDisplayValue : HintGenerator.GetNumberOfMinesFromNeighbourSquares(_board, new Position(i, j)).ToString();
                }
            }
        }

        private bool IsMineSquare(Position squarePosition)
        {
            return _board.Grid[squarePosition.X, squarePosition.Y] == SquareType.Mine;
            
        }
        private Position ReadSelectedSquarePosition()
        {
            _io.Write(Instruction.RequestSelectSquareToReveal());
            var input = _io.Read();
            var inputArray = input.Split(",").Select(int.Parse).ToArray();
            var selectedSquarePosition = new Position(inputArray[0], inputArray[1]);
            return selectedSquarePosition;
        }

        private int GetTotalNumberOfSafeSquares()
        {
            return _board.Width * _board.Height - _board.NumberOfMines;
        }
    }
}
