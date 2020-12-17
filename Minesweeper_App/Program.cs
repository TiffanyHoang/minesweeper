using System;
using System.Collections.Generic;
namespace Minesweeper_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var io = new IO();
            var difficultLevel = GameSettings.GetDifficultLevel(io);
            var minePositions = GameSettings.GetMinePositions(difficultLevel);
            var boardWidth = difficultLevel;
            var boardHeight = difficultLevel; 

            var board = new Board(boardWidth, boardHeight, minePositions);
            
            var game = new Game(board,io);
            game.Run();
        }
    }
}
