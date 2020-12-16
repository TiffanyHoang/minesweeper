using System;

namespace Minesweeper_App
{
    public class Instruction
    {
        public static string MineDisplayValue = "💣";
        public static string HiddenSquareDisplayValue = ".";

        public static string RequestSelectSquareToReveal()
        {
            return "Please enter a square position you want to reveal (eg: 0,0 for the square at the first row and first column):";
        }
        public static string LoseMessage()
        {
            return "You step on mine! Lose!";
        }
        public static string WinMessage()
        {
            return "Win";
        }
    }
}
