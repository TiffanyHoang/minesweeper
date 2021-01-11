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
            var shuffedPotentialMinePositions = Shuffle(potentialMinePositions);
            var minePositions = shuffedPotentialMinePositions.Take(difficultLevel).ToList();
            return minePositions;
        }

        private static List<Position> GetPotentialMinePositions(int difficultLevel)
        {
            List<Position> potentialMinePositions = new List<Position>();
            for (int i = 0; i < difficultLevel; i++)
            {
                for (int j = 0; j < difficultLevel; j++)
                {
                    potentialMinePositions.Add(new Position(i,j));
                }
            }
            return potentialMinePositions;
        }

        private static List<Position> Shuffle(List<Position> positions)
        {
            var shuffledPositions = positions.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledPositions;
        }
    }
}
