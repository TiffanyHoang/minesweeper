using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class Board_Test
    {
        [Fact]
        public void GivenABoardSizeAndMinePositions_ReturnCorrectBoardGrid()
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
            var actual = board.Grid;
            var expected = new SquareType[,]{
                {SquareType.Mine, SquareType.Mine, SquareType.Safe},
                {SquareType.Safe,SquareType.Safe,SquareType.Safe },
                {SquareType.Safe,SquareType.Safe,SquareType.Safe }
            };
            
            Assert.Equal(expected, actual);

        }
    }
}
