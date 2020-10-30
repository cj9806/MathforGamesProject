using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public Colour()
        {

        }
        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            colour |= (UInt32)red << 24;
            colour |= (UInt32)green << 16;
            colour |= (UInt32)blue << 8;
            colour |= (UInt32)alpha;
        }
        public UInt32 colour;
        public void SetRed(byte red)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }
        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }
        public void SetGreen(byte green)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)green << 16;
        }
        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);
        }
        public void SetBlue(byte blue)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)blue << 8;
        }
        public byte GetBlue()
        {
            return (byte)((colour & 0x0000ff00) >> 8);
        }
        public void SetAlpha(byte alpha)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)alpha;
        }
        public byte GetAlpha()
        {
            return (byte)(colour & 0x0000ff
                );
        }
    }
}
