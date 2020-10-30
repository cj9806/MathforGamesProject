using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {

        //general stuff
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }
        public Matrix3(float M1, float M2, float M3, float M4, float M5, float M6, float M7, float M8, float M9)
        {
            m1 = M1; m2 = M2; m3 = M3;
            m4 = M4; m5 = M5; m6 = M6;
            m7 = M7; m8 = M8; m9 = M9;
        }
        public readonly static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        public static Matrix3 operator *(Matrix3 L, Matrix3 R)
        {
            return new Matrix3(
                L.m1 * R.m1 + L.m4 * R.m2 + L.m7 * R.m3, L.m2 * R.m1 + L.m5 * R.m2 + L.m8 * R.m3, L.m3 * R.m1 + L.m6 * R.m2 + L.m9 * R.m3,
                L.m1 * R.m4 + L.m4 * R.m5 + L.m7 * R.m6, L.m2 * R.m4 + L.m5 * R.m5 + L.m8 * R.m6, L.m3 * R.m4 + L.m6 * R.m5 + L.m9 * R.m6,
                L.m1 * R.m7 + L.m4 * R.m8 + L.m7 * R.m9, L.m2 * R.m7 + L.m5 * R.m8 + L.m8 * R.m9, L.m3 * R.m7 + L.m6 * R.m8 + L.m9 * R.m9);
        }
        public static Vector3 operator *(Matrix3 L, Vector3 R)
        {
            return new Vector3((L.m1 * R.x) + (L.m4 * R.y) + (L.m7 * R.z),
                               (L.m2 * R.x) + (L.m5 * R.y) + (L.m8 * R.z),
                               (L.m3 * R.x) + (L.m6 * R.y) + (L.m9 * R.z));
        }
        Matrix3 GetTransposed()
        {
            return new Matrix3(
                m1, m4, m7,
                m2, m5, m8,
                m3, m6, m9);
        }
        //transformations
        void Set(Matrix3 S)
        {
            this.m1 = S.m1;
            this.m2 = S.m2;
            this.m3 = S.m3;
            this.m4 = S.m4;
            this.m5 = S.m5;
            this.m6 = S.m6;
            this.m7 = S.m7;
            this.m8 = S.m8;
            this.m9 = S.m9;
        }
        //set overload
        void Set(float f1, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9)
        {
            this.m1 = f1;
            this.m2 = f2;
            this.m3 = f3;
            this.m4 = f4;
            this.m5 = f5;
            this.m6 = f6;
            this.m7 = f7;
            this.m8 = f8;
            this.m9 = f9;
        }
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }

        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians),
                0, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void RotateX(double rads)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(rads);
            Set(this * m);
        }

        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians),
                0, 1, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians));
        }
        public void RotateY(double rads)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(rads);
            Set(this * m);
        }

        public void SetRotateZ(double radians)
        {
            Set(
                (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }
        public void RotateZ(double rads)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(rads);
            Set(this * m);
        }

        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            Set(z * y * x);
        }
    }
}
