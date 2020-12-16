using System;

namespace Minesweeper_App
{
    public class Game
    {
        private readonly Board _board;
        private readonly IIO _io;
        public Game(Board board, IIO io)
        {
            _board = board;
            _io = io;
        }

        public void Run()
        {
            PrintHiddenSquaresBoard();
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
    }
}
