/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Math
{
    public struct Vector2
    {
        public static Vector2 zero = new Vector2(0f, 0f);
        public static Vector2 One = new Vector2(1f, 1f);
        public static Vector2 Up = new Vector2(0f, 1f);
        public static Vector2 Down = new Vector2(0f, -1f);
        public static Vector2 Left = new Vector2(-1f, 0f);
        public static Vector2 Right = new Vector2(1f, 0f);

        public float x { get; set; }
        public float y { get; set; }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Vector2 other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (obj.GetType() != typeof(Vector2))
                return false;
            return Equals((Vector2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return x.GetHashCode() + 13 * y.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"(x: {x}; y: {y})";
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !a.Equals(b);
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }
    }
}
