using System;

namespace Minesweeper_App
{
    public static class Instruction
    {
        public static string MineDisplayValue = "*";
        public static string HiddenSquareDisplayValue = ".";
        public static string RequestSelectSquareToReveal = "\nPlease enter a position you want to reveal (eg: 0,0 for the position at the first row and first column):";
        public static string WelcomeMessage = "\nWelcome to Minesweeper.\nThe goal of the game is to uncover all the squares on a board that do not contain mines without being \"blown up\" by revealing a square with a mine underneath.\nTo help the player, the game shows a number in a square (hint) which tells the player how many mines there are adjacent to that square.\nSymbol explanation:\n. : hidden square\n* : mine\n";
        public static string RequestDifficultLevel = "\nPlease enter the difficult level (from 2 to 10):";
        public static string CurrentBoard = "\nCurrent board:";
        public static string InvalidInputMessage = "\nInvalid input\n";
        public static string LoseMessage = "\nYou've steped on a mine! Game is over!";
        public static string WinMessage = "\nCongrats! You've won the game!";
    }
}
