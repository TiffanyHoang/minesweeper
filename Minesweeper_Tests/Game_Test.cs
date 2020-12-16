using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class Game_Test
    {
        [Fact]
        public void RunGame_ReturnHiddenSquaresBoard()
        {
            var width = 3;
            var height = 3;
            var leftTop = new Position(0, 0);
            var middleTop = new Position(0, 1);
            var minePositions = new List<Position>{
                leftTop,
                middleTop
            };
            var board = new Board(width, height, minePositions);
            var io = new TestIO();
            var game = new Game(board, io);
            game.Run();
            var actual = io.GetText();
            var expected =  "...\n" +
                            "...\n" +
                            "...\n";
            Assert.Equal(expected, actual);
        }
    }
}
