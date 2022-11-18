using System;

namespace Pathfinder
{
    internal struct Vec2
    {
        public readonly int X, Y;

        public Vec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Length => Math.Sqrt(X * X + Y * Y);

        public bool Equals(Vec2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vec2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Vec2 lhs, Vec2 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vec2 lhs, Vec2 rhs)
        {
            return !(lhs == rhs);
        }

        public static Vec2 operator +(Vec2 lhs, Vec2 rhs)
        {
            return new Vec2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }
    }
}