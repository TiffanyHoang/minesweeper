using System;
using System.Collections.Generic;
namespace Minesweeper_App
{
    public static class InputValidator
    {
        public static bool ValidateDifficultLevel(string input)
        {
            int.TryParse(input, out int difficultLevel);
            var isDifficultLevelInRange = difficultLevel >= 2 && difficultLevel <= 10;
            return isDifficultLevelInRange;
        }

        public static bool ValidatePositionInput(string input, int boardWidth, int boardHeight)
        {
            var stringInputArray = input.Split(',');
            List<int> numberArray = GetNumberArray(stringInputArray);
            var isTwoNumbersSeparatedByComma = numberArray.Count == 2;
            return  isTwoNumbersSeparatedByComma && IsPositionInRange(numberArray, boardWidth, boardHeight);
        }
        private static List<int> GetNumberArray(string[] stringInputArray)
        {
            var numberArray = new List<int>();
            foreach (string stringInput in stringInputArray)
            {
                var isNumber = int.TryParse(stringInput, out int number);

                numberArray.Add(number);
            }
            return numberArray;
        }
        private static bool IsPositionInRange(List<int> numberArray, int boardWidth, int boardHeight)
        {
            var x = numberArray[0];
            var y = numberArray[1];
            var isPositionPositiveNumber = x >= 0 && y >= 0;
            var isInsideTheBoard = x <= boardWidth - 1 && y <= boardHeight - 1;

            return (isPositionPositiveNumber && isInsideTheBoard);
        }
    }
}
