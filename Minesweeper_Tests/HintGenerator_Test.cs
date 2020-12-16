using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class HintGenerator_Test
    {
        static Position leftTop = new Position(0, 0);
        static Position middleTop = new Position(0, 1);
        static Position rightTop = new Position(0, 2);
        static Position leftCentre = new Position(1, 0);
        static Position middleCentre = new Position(1, 1);
        static Position rightCentre = new Position(1, 2);
        static Position leftBottom = new Position(2, 0);
        static Position middleBottom = new Position(2, 1);
        static Position rightBottom = new Position(2, 2);
        public static IEnumerable<object[]> Data =>

        new List<object[]>
        {
            new object[] {
                leftTop,
                1
            },
            new object[] {
                middleTop,
                1
            },
            new object[] {
                rightTop,
                1
            },
            new object[] {
                leftCentre,
                2
            },
            new object[] {
                middleCentre,
                2
            },
            new object[] {
                rightCentre,
                1
            },
            new object[] {
                leftBottom,
                0
            },
            new object[] {
                middleBottom,
                0
            },
            new object[] {
                rightBottom,
                0
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GivenASquarePositionInABoard_ReturnNumberOfMinesFromNeighbourSquares(Position squarePosition, int expected)
        {
            var width = 3;
            var height = 3;
            var leftTop = new Position(0, 0);
            var middleTop = new Position(0, 1);
            var minePositions = new List<Position>{
                leftTop,
                middleTop
            }; 
            var board = new Board(width, height,minePositions);

            var actual = HintGenerator.GetNumberOfMinesFromNeighbourSquares(board, squarePosition);
            Assert.Equal(expected, actual);
        }
    }
}
