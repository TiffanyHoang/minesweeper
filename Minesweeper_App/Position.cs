using System;

namespace Minesweeper_App
{
    public class Position : IEquatable<Position>
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position other)
        {
            if (other is null)
                return false;

            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj) => Equals(obj as Position);
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
