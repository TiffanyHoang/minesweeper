using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class _Test
    {
        [Fact]
        public void GivenValidDifficultLevelInString_ReturnDifficultLevelInNumber()
        {            
            var input = "2";
            var io = new TestIO();
            io.SetToBeRead(input);
            var actual = GameSettings.GetDifficultLevel(io);
            var expected = 2;
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GivenInvalidDifficultLevelInString_ReturnInvalidInputMessage()
        {            
            var invalidInput = "1";
            var validInput = "2";
            var io = new TestIO();
            io.SetToBeRead(invalidInput);
            io.SetToBeRead(validInput);
            
            GameSettings.GetDifficultLevel(io);
            var actual = io.HasText(Instruction.InvalidInputMessage());

            Assert.True(actual);
        }

        [Fact]
        public void GivenDifficultLevel_ReturnNumberOfMinePositions()
        {
            var difficultLevel = 2;
            var actual = GameSettings.GetMinePositions(difficultLevel).Count;
            var expected = 2;
            
            Assert.Equal(expected, actual);
        }   

    }
}
