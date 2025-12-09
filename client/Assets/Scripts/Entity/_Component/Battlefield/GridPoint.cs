using System;

namespace Game
{
    public struct GridPoint: IEquatable<GridPoint>
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public GridPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}, {Y})";
        public bool Equals(GridPoint other) => X == other.X && Y == other.Y;
        public override bool Equals(object obj) => obj is GridPoint other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public static GridPoint operator+(GridPoint a, GridPoint b) => new GridPoint(a.X + b.X, a.Y + b.Y);
        public static GridPoint operator-(GridPoint a, GridPoint b) => new GridPoint(a.X - b.X, a.Y - b.Y);
        public static GridPoint operator*(GridPoint a, int value) => new GridPoint(a.X * value, a.Y * value);
    }
}