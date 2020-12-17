using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper_App
{
    public class GameSettings
    {
         public static int GetDifficultLevel(IIO io)
        {
            var input = "";
            while (true)
            {
                io.Write(Instruction.RequestDifficultLevel());
                input = io.Read();
                var isValidInput = InputValidator.ValidateDifficultLevel(input);
                if (isValidInput)
                {
                    break;
                }
                io.Write(Instruction.InvalidInputMessage());
            }
            return int.Parse(input);
        }
        public static List<Position> GetMinePositions(int difficultLevel)
        {
            var potentialMinePositions = GetPotentialMinePositions(difficultLevel);
            var shuffePotentialMinePositionsPositions = Shuffle(potentialMinePositions);
            return shuffePotentialMinePositionsPositions.Take(difficultLevel).ToList();
        }

        private static List<Position> GetPotentialMinePositions(int difficultLevel)
        {
            List<Position> potentialMinePosition = new List<Position>();
            for (int i = 0; i < difficultLevel; i++)
            {
                for (int j = 0; j < difficultLevel; j++)
                {
                    potentialMinePosition.Add(new Position(i,j));
                }
            }
            return potentialMinePosition;
        }

        private static List<Position> Shuffle(List<Position> positions)
        {
            Random shuffle = new Random();
            int numberOfPositions = positions.Count;
            while (numberOfPositions > 1)
            {
                numberOfPositions--;
                int index = shuffle.Next(numberOfPositions + 1);
                Position value = positions[index];
                positions[index] = positions[numberOfPositions];
                positions[numberOfPositions] = value;
            }
            return positions;
        }
    }
}
