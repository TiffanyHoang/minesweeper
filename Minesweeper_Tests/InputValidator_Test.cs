using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class InputValidator_Test
    {
        [Theory]
        [InlineData("1", false)]
        [InlineData("11", false)]
        [InlineData("2", true)]
        public void GivenDifficultLevelInString_ReturnCorrectResult(string input, bool expected)
        {
            var actual = InputValidator.ValidateDifficultLevel(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("a", false)]
        [InlineData("1", false)]
        [InlineData("-1", false)]
        [InlineData("1,-1", false)]
        [InlineData("3,3", false)]
        [InlineData("0,2", true)]
        public void GivenASquarePositionInput_ReturnCorrectResult(string input, bool expected)
        {
            var boardWidth = 3;
            var boardHeight = 3;
            var actual = InputValidator.ValidatePositionInput(input, boardWidth, boardHeight);
            Assert.Equal(expected, actual);
        }
    }
}
