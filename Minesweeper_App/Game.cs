using System;
using System.Linq;
using System.Collections.Generic;
namespace Minesweeper_App
{
    public class Game
    {
        private readonly Board _board;
        private readonly IIO _io;
        private readonly string[,] _displayBoard;

        private readonly int _totalNumberOfSafeSquares;
        public Game(Board board, IIO io)
        {
            _board = board;
            _io = io;
            _displayBoard = new string[board.Width, board.Height];
            _totalNumberOfSafeSquares = _board.Width * _board.Height - _board.NumberOfMines;
        }

        public void Run()
        {
            PrintDisplayBoard();
            var revealedSafeSquareCount = 0;
            while (true)
            {
                var selectedSquarePosition = ReadSelectedSquarePosition();

                var isSelectedSquareMineSquare = IsMineSquare(selectedSquarePosition);
                if (isSelectedSquareMineSquare)
                {
                    FillEntireDisplayBoard();
                    PrintDisplayBoard();
                    _io.Write(Instruction.LoseMessage);
                    break;
                }

                UpdateDisplayBoard(selectedSquarePosition);
                PrintDisplayBoard();

                revealedSafeSquareCount += 1;

                var areAllSafeSquareRevealed = revealedSafeSquareCount == _totalNumberOfSafeSquares;
                if (areAllSafeSquareRevealed)
                {
                    _io.Write(Instruction.WinMessage);
                    break;
                }
            }
        }

        private void PrintDisplayBoard()
        {
            _io.Write(Instruction.CurrentBoard);
            var outputString = "";
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                    outputString += _displayBoard[i, j] ?? Instruction.HiddenSquareDisplayValue;
                }
                outputString += "\n";
            }
            _io.Write(outputString);
        }

        private void UpdateDisplayBoard(Position selectedSquarePosition)
        {
            var hint = HintGenerator.GetNumberOfMinesFromNeighbourSquares(_board, selectedSquarePosition).ToString();

            _displayBoard[selectedSquarePosition.X, selectedSquarePosition.Y] = hint;
        }

        private void FillEntireDisplayBoard()
        {
            for (int i = 0; i < _board.Width; i++)
            {
                for (int j = 0; j < _board.Height; j++)
                {
                    _displayBoard[i, j] = IsMineSquare(new Position(i, j)) ? Instruction.MineDisplayValue : HintGenerator.GetNumberOfMinesFromNeighbourSquares(_board, new Position(i, j)).ToString();
                }
            }
        }

        private bool IsMineSquare(Position squarePosition)
        {
            return _board.Grid[squarePosition.X, squarePosition.Y] == SquareType.Mine;
        }

        private Position ReadSelectedSquarePosition()
        {
            var input = "";
            while (true)
            {
                _io.Write(Instruction.RequestSelectSquareToReveal);
                input = _io.Read();
                var isValidInput = InputValidator.IsPositionInputValid(input, _board.Width, _board.Height);
                if (isValidInput)
                {
                    break;
                }
                _io.Write(Instruction.InvalidInputMessage);
            }
            var inputArray = input.Split(",").Select(int.Parse).ToArray();
            var selectedSquarePosition = new Position(inputArray[0], inputArray[1]);
            return selectedSquarePosition;
        }
    }
}
