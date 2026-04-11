using System;

namespace Game
{
    public struct SquadPos : IEquatable<SquadPos>
    {
        public int row;
        public int col;

        public SquadPos(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public bool Equals(SquadPos other)
        {
            return row == other.row && col == other.col;
        }

        public override bool Equals(object obj)
        {
            return obj is SquadPos other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(row, col);
        }
    }
}