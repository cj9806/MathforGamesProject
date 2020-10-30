using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        public Matrix4(float M1, float M2, float M3, float M4, float M5, float M6, float M7, float M8, float M9, float M10, float M11, float M12, float M13, float M14, float M15, float M16)
        {
            m1 = M1; m2 = M2; m3 = M3; m4 = M4;
            m5 = M5; m6 = M6; m7 = M7; m8 = M8;
            m9 = M9; m10 = M10; m11 = M11; m12 = M12;
            m13 = M13; m14 = M14; m15 = M15; m16 = M16;
        }
        public static Matrix4 CreateIdentity()
        {
            return new Matrix4(1.0f, 0.0f, 0.0f, 0.0f,
                               0.0f, 1.0f, 0.0f, 0.0f,
                               0.0f, 0.0f, 1.0f, 0.0f,
                               0.0f, 0.0f, 0.0f, 1.0f);
        }
        public static Matrix4 operator *(Matrix4 L, Matrix4 R)
        {
            return new Matrix4(
                L.m1 * R.m1 + L.m5 * R.m2 + L.m9 * R.m3 + L.m13 * R.m4,
                L.m2 * R.m1 + L.m6 * R.m2 + L.m10 * R.m3 + L.m14 * R.m4,
                L.m3 * R.m1 + L.m7 * R.m2 + L.m11 * R.m3 + L.m15 * R.m4,
                L.m4 * R.m1 + L.m8 * R.m2 + L.m12 * R.m3 + L.m16 * R.m4,

                L.m1 * R.m5 + L.m5 * R.m6 + L.m9 * R.m7 + L.m13 * R.m8,
                L.m2 * R.m5 + L.m6 * R.m6 + L.m10 * R.m7 + L.m14 * R.m8,
                L.m3 * R.m5 + L.m7 * R.m6 + L.m11 * R.m7 + L.m15 * R.m8,
                L.m4 * R.m5 + L.m8 * R.m6 + L.m12 * R.m7 + L.m16 * R.m8,

                L.m1 * R.m9 + L.m5 * R.m10 + L.m9 * R.m11 + L.m13 * R.m12,
                L.m2 * R.m9 + L.m6 * R.m10 + L.m10 * R.m11 + L.m14 * R.m12,
                L.m3 * R.m9 + L.m7 * R.m10 + L.m11 * R.m11 + L.m15 * R.m12,
                L.m4 * R.m9 + L.m8 * R.m10 + L.m12 * R.m11 + L.m16 * R.m12,

                L.m1 * R.m13 + L.m5 * R.m14 + L.m9 * R.m15 + L.m13 * R.m16,
                L.m2 * R.m13 + L.m6 * R.m14 + L.m10 * R.m15 + L.m14 * R.m16,
                L.m3 * R.m13 + L.m7 * R.m14 + L.m11 * R.m15 + L.m15 * R.m16,
                L.m4 * R.m13 + L.m8 * R.m14 + L.m12 * R.m15 + L.m16 * R.m16
                );


        }
        public static Vector4 operator *(Matrix4 L, Vector4 R)
        {
            return new Vector4((L.m1 * R.x) + (L.m5 * R.y) + (L.m9 * R.z) + (L.m13 * R.w),
                               (L.m2 * R.x) + (L.m6 * R.y) + (L.m10 * R.z) + (L.m14 * R.w),
                               (L.m3 * R.x) + (L.m7 * R.y) + (L.m11 * R.z) + (L.m15 * R.w),
                               (L.m4 * R.x) + (L.m8 * R.x) + (L.m12 * R.x) + (L.m16 * R.w));
        }

        void Set(Matrix4 S)
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
            this.m10 = S.m10;
            this.m11 = S.m11;
            this.m12 = S.m12;
            this.m13 = S.m13;
            this.m14 = S.m14;
            this.m15 = S.m15;
            this.m16 = S.m16;
        }
        //set overload
        void Set(float f1, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9, float f10, float f11, float f12, float f13, float f14, float f15, float f16)
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
            this.m10 = f10;
            this.m11 = f11;
            this.m12 = f12;
            this.m13 = f13;
            this.m14 = f14;
            this.m15 = f15;
            this.m16 = f16;
        }
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        public void SetRotateX(double radians)
        {
            Set(
            1, 0, 0, 0,
            0, (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
            0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
            0, 0, 0, 1);
        }
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)-Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }
        public void RotateY(double rads)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(rads);
            Set(this * m);
        }

        public void SetRotateZ(double radians)
        {
            Set(
                (float)Math.Cos(radians), (float)-Math.Sin(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        public void RotateZ(double rads)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(rads);
            Set(this * m);
        }
        public void SetTranslation(float x, float y, float z)
        {
            m13 = z; m14 = y; m15 = z; m16 = 1;
        }
        void Translate(float x, float y, float z)
        {
            m13 += z; m14 += y; m15 += z;
        }
    }
}
