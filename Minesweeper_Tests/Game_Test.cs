using System;
using Xunit;
using Minesweeper_App;
using System.Collections.Generic;

namespace Minesweeper_Tests
{
    public class Game_Test
    {
        static int width = 3;
        static int height = 3;
        static Position leftTop = new Position(0, 0);
        static Position middleTop = new Position(0, 1);
        List<Position> minePositions = new List<Position>{
            leftTop,
            middleTop
        };
        
        [Fact]
        public void RunGame_ReturnHiddenSquaresBoard()
        {
            var board = new Board(width, height, minePositions);
            var io = new TestIO();
            var game = new Game(board, io);
            io.SetToBeRead("0,0");

            game.Run();            
            var actual = io.GetText();
            var expected =  "...\n" +
                            "...\n" +
                            "...\n";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerInputsASquarePositionToReveal_ReturnARevealedSquareOnHiddenSquaresBoard()
        {
            var board = new Board(width, height, minePositions);
            var io = new TestIO();
            var game = new Game(board, io);

            var selectedSquarePositionInput = "0,2";
            io.SetToBeRead(selectedSquarePositionInput);
            game.Run();
            var actual = io.HasText(
                            "..1\n" +
                            "...\n" +
                            "...\n");

            Assert.True(actual);
        }

        [Fact]
        public void PlayerInputIsAMineSquarePosition_ReturnPlayerLose()
        {
            var board = new Board(width, height, minePositions);
            var io = new TestIO();
            var game = new Game(board, io);

            var selectedSquarePositionInput = "0,0";
            io.SetToBeRead(selectedSquarePositionInput);
            game.Run();
            var actual = io.HasText(Instruction.LoseMessage());

            Assert.True(actual);
        }

        [Fact]
        public void PlayerInputIsALastSafeSquarePosition_ReturnPlayerWin()
        {
            var board = new Board(width, height, minePositions);
            var io = new TestIO();
            var game = new Game(board, io);

            var selectedSquarePositionInput = "0,2";
            io.SetToBeRead(selectedSquarePositionInput);
            game.Run();
            var actual = io.HasText(Instruction.WinMessage());

            Assert.True(actual);
        }
        

    }
}
