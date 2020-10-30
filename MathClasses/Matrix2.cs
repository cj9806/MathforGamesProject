using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix2
    {
        public float m1, m2, m3, m4;
        public Matrix2()
        {
            m1 = 1; m2 = 0;
            m3 = 0; m4 = 1;
        }
        public Matrix2(float M1, float M2, float M3, float M4)
        {
            m1 = M1; m2 = M2; 
            m3 = M3; m4 = M4;
        }
        public readonly static Matrix2 identity = new Matrix2(1, 0, 0, 1);
        public static Matrix2 operator *(Matrix2 L, Matrix2 R)
        {
            return new Matrix2(
                L.m1 * R.m1 + L.m3 * R.m2, L.m2 * R.m1 + L.m4 * R.m2,
                L.m1 * R.m3 + L.m3 * R.m4, L.m2 * R.m3 + L.m4 * R.m2);
        }
        public static Vector2 operator *(Matrix2 L, Vector2 R)
        {
            return new Vector2(
                L.m1 * R.x + L.m2 * R.y,
                L.m3 * R.x + L.m4 * R.y);
        }
        Matrix2 GetTransposed()
        {
            return new Matrix2(
                m1, m3,
                m2, m4);
        }
        //transformations
        void Set(Matrix2 S)
        {
            this.m1 = S.m1;
            this.m2 = S.m2;
            this.m3 = S.m3;
            this.m4 = S.m4;
        }
        //set overload
        void Set(float f1, float f2, float f3, float f4)
        {
            this.m1 = f1;
            this.m2 = f2;
            this.m3 = f3;
            this.m4 = f4;
        }
        public void SetScaled(float x, float y)
        {
            m1 = x; m2 = 0;
            m3 = 0; m4 = y;
        }

        public void Scale(float x, float y)
        {
            Matrix2 m = new Matrix2();
            m.SetScaled(x, y);
            Set(this * m);
        }

        public void SetRotate(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians),
                (float)Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void Rotate(double rads)
        {
            Matrix2 m = new Matrix2();
            m.SetRotate(rads);
            Set(this * m);
        }
    }
}
