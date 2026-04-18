using System;

namespace Game
{
    public readonly struct GridPoint: IEquatable<GridPoint>
    {
        public int X { get; }

        public int Y { get; }

        public GridPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X}, {Y})";
        public override bool Equals(object obj) => obj is GridPoint other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        
        public static GridPoint operator+(GridPoint a, GridPoint b) => new GridPoint(a.X + b.X, a.Y + b.Y);
        public static GridPoint operator-(GridPoint a, GridPoint b) => new GridPoint(a.X - b.X, a.Y - b.Y);
        public static GridPoint operator*(GridPoint a, int value) => new GridPoint(a.X * value, a.Y * value);

        public bool Equals(GridPoint other) => X == other.X && Y == other.Y;
        public static bool operator ==(GridPoint a, GridPoint b) => a.Equals(b);
        public static bool operator !=(GridPoint a, GridPoint b) => !(a == b);
    }
}