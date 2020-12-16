using System;
using System.Collections.Generic;
namespace Minesweeper_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var minePositions = new List<Position>{
                new Position(0, 0),
                new Position(1, 1)
            };
            var board = new Board(2, 2, minePositions);
            var io = new IO();
            var game = new Game(board,io);
            game.Run();
        }
    }
}
