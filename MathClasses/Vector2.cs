using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector2
    {
        public float x, y;

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        //math operands
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x * rhs.x, lhs.y * rhs.y);
        }
        public static Vector2 operator /(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x / rhs.x, lhs.y / rhs.y);
        }
        //vecter * / float
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }
        // take it back now yall
        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y);
        }
        public float Distance(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
        }
        public Vector2 GetNormalized()
        {
            return this / Magnitude();
        }
        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }        
        float AngleBetween(Vector2 other)
        {
            Vector2 a = GetNormalized();
            Vector2 b = other.GetNormalized();

            float d = a.x * b.x + a.y * b.y;

            return (float)Math.Acos(d);
        }
    }
}
