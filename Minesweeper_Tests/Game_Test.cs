using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class Game_Test
    {
        static int width = 2;
        static int height = 2;
        static Position leftTop = new Position(0, 0);
        static Position rightBottom = new Position(1, 1);
        static List<Position> minePositions = new List<Position>{
            leftTop,
            rightBottom
        };

        static Board board = new Board(width, height, minePositions);
        static TestIO io = new TestIO();
        Game game = new Game(board, io);

        [Fact]
        public void RunGame_DisplayHiddenSquaresBoard()
        {
            var selectedSquarePositionLeftTop = "0,0";
            io.SetToBeRead(selectedSquarePositionLeftTop);
            game.Run();
            var actual = io.HasText(
                            Instruction.HiddenSquareDisplayValue + Instruction.HiddenSquareDisplayValue + "\n" +
                            Instruction.HiddenSquareDisplayValue + Instruction.HiddenSquareDisplayValue + "\n");
            Assert.True(actual);
        }

        [Fact]
        public void RunGame_PlayerInputIsAMineSquarePosition_DisplayPlayerLoseMessage()
        {
            var selectedSquarePositionLeftTop = "0,0";
            io.SetToBeRead(selectedSquarePositionLeftTop);
            game.Run();
            var actual = io.HasText(Instruction.LoseMessage);

            Assert.True(actual);
        }

        [Fact]
        public void RunGame_PlayerInputIsAMineSquarePosition_DisplayEntireRevealedBoard()
        {
            var selectedSquarePositionLeftTop = "0,0";
            io.SetToBeRead(selectedSquarePositionLeftTop);
            game.Run();
            var actual = io.HasText(
                            Instruction.MineDisplayValue +"2" + "\n" +
                            "2" +Instruction.MineDisplayValue + "\n");
            Assert.True(actual);
        }
        
        [Fact]
        public void RunGame_PlayerInputsOnAllSafeSquares_DisplayPlayerWinMessage()
        {
            var selectedSquarePositionRightTop = "0,1";
            var selectedSquarePositionLeftBottom = "1,0";

            io.SetToBeRead(selectedSquarePositionRightTop);
            io.SetToBeRead(selectedSquarePositionLeftBottom);

            game.Run();
            var actual = io.HasText(Instruction.WinMessage);

            Assert.True(actual);
        }
        
        [Fact]
        public void RunGame_PlayerInputsOnAllSafeSquares_DisplayRevealedSquares()
        {
            var selectedSquarePositionRightTop = "0,1";
            var selectedSquarePositionLeftBottom = "1,0";

            io.SetToBeRead(selectedSquarePositionRightTop);
            io.SetToBeRead(selectedSquarePositionLeftBottom);

            game.Run();
            var actual = io.HasText(
                            Instruction.HiddenSquareDisplayValue +"2" + "\n" +
                            "2" +Instruction.HiddenSquareDisplayValue + "\n");
            Assert.True(actual);
        }

        [Fact]
        public void RunGame_PlayerInputInvalidPostion_DisplayInvalidInputMessage()
        {
            var invalidInput = "invalidInput";
            var validInput = "0,0";
            io.SetToBeRead(invalidInput);
            io.SetToBeRead(validInput);
            game.Run();
            var actual = io.HasText(Instruction.InvalidInputMessage);
            Assert.True(actual);
        }
    }
}
