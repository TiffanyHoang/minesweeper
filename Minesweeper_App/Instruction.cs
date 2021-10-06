using System;

namespace Minesweeper_App
{
    public static class Instruction
    {
        public static string MineDisplayValue = "*";
        public static string HiddenSquareDisplayValue = ".";
        public static string RequestSelectSquareToReveal = "Please enter a position you want to reveal (eg: 0,0 for the position at the first row and first column):";
        public static string RequestDifficultLevel = "Please enter the difficult level (from 2 to 10):";
        public static string CurrentBoard = "Here is current board:";
        public static string InvalidInputMessage = "Invalid input";
        public static string LoseMessage = "You've steped on a mine! Game is over!";
        public static string WinMessage = "Congrats! You've won the game!";
    }
}
