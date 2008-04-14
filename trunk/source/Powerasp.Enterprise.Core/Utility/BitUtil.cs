using System;
using System.Collections;
using System.IO;

namespace Powerasp.Enterprise.Core.Utility
{
    public class BitUtil
    {
        public const int X0 = 0;
        public const int X1 = 1;
        public const int X10 = 0x10;
        public const int X100 = 0x100;
        public const int X1000 = 0x1000;
        public const int X2 = 2;
        public const int X20 = 0x20;
        public const int X200 = 0x200;
        public const int X2000 = 0x2000;
        public const int X4 = 4;
        public const int X40 = 0x40;
        public const int X400 = 0x400;
        public const int X4000 = 0x4000;
        public const int X8 = 8;
        public const int X80 = 0x80;
        public const int X800 = 0x800;
        public const int X8000 = 0x8000;
        public static readonly ArrayList XList = new ArrayList(new int[] { 
                                                                             0, 1, 2, 4, 8, 0x10, 0x20, 0x40, 0x80, 0x100, 0x200, 0x400, 0x800, 0x1000, 0x2000, 0x4000, 
                                                                             0x8000
                                                                         });

        public static int AddValue(int x, int y)
        {
            if (ContainValue(x, y))
            {
                return x;
            }
            return (x + y);
        }

        public static int[] BytesToInt32Array(byte[] bytes)
        {
            return BytesToInt32Array(bytes, 0);
        }

        public static int[] BytesToInt32Array(byte[] bytes, int shift)
        {
            return BytesToInt32Array(bytes, shift, -1);
        }

        public static int[] BytesToInt32Array(byte[] bytes, int shift, int length)
        {
            int[] numArray;
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if ((shift < 0) || (shift >= bytes.Length))
            {
                throw new ArgumentOutOfRangeException("shift");
            }
            if (length == -1)
            {
                numArray = new int[(bytes.Length / 4) + (((bytes.Length % 4) == 0) ? 0 : 1)];
            }
            else
            {
                numArray = new int[length];
            }
            for (int i = 0; i < length; i++)
            {
                if ((((i + 1) * 4) + shift) >= bytes.Length)
                {
                    return numArray;
                }
                numArray[i] = BitConverter.ToInt32(bytes, (i * 4) + shift);
            }
            return numArray;
        }

        public static uint[] BytesToUInt32Array(byte[] bytes)
        {
            return BytesToUInt32Array(bytes, 0);
        }

        public static uint[] BytesToUInt32Array(byte[] bytes, int shift)
        {
            return BytesToUInt32Array(bytes, shift, -1);
        }

        public static uint[] BytesToUInt32Array(byte[] bytes, int shift, int length)
        {
            uint[] numArray;
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if ((shift < 0) || (shift >= bytes.Length))
            {
                throw new ArgumentOutOfRangeException("shift");
            }
            if (length == -1)
            {
                numArray = new uint[(bytes.Length / 4) + (((bytes.Length % 4) == 0) ? 0 : 1)];
            }
            else
            {
                numArray = new uint[length];
            }
            for (int i = 0; i < length; i++)
            {
                if ((((i + 1) * 4) + shift) >= bytes.Length)
                {
                    return numArray;
                }
                numArray[i] = BitConverter.ToUInt32(bytes, (i * 4) + shift);
            }
            return numArray;
        }

        public static bool ContainValue(int x, int y)
        {
            return ((y == 0) || ((x & y) != 0));
        }

        public static int RemoveValue(int x, int y)
        {
            if (!ContainValue(x, y))
            {
                return x;
            }
            return (x - y);
        }

        public static int Rotl(int x, int y)
        {
            y = y % 0x20;
            return ((x << y) | (x >> (0x20 - y)));
        }

        public static uint Rotl(uint x, int y)
        {
            y = y % 0x20;
            return ((x << y) | (x >> (0x20 - y)));
        }

        public static int RotlFixed(int x, int y)
        {
            if (y >= 0x20)
            {
                throw new ArgumentNullException("y");
            }
            return ((x << y) | (x >> (0x20 - y)));
        }

        public static uint RotlFixed(uint x, int y)
        {
            if (y >= 0x20)
            {
                throw new ArgumentNullException("y");
            }
            return ((x << y) | (x >> (0x20 - y)));
        }

        public static int Rotr(int x, int y)
        {
            y = y % 0x20;
            return ((x >> y) | (x << (0x20 - y)));
        }

        public static uint Rotr(uint x, int y)
        {
            y = y % 0x20;
            return ((x >> y) | (x << (0x20 - y)));
        }

        public static int RotrFixed(int x, int y)
        {
            if (y >= 0x20)
            {
                throw new ArgumentNullException("y");
            }
            return ((x >> y) | (x << (0x20 - y)));
        }

        public static uint RotrFixed(uint x, int y)
        {
            if (y >= 0x20)
            {
                throw new ArgumentNullException("y");
            }
            return ((x >> y) | (x << (0x20 - y)));
        }

        public static byte[] UInt32ArrayToBytes(int[] ary)
        {
            return UInt32ArrayToBytes(ary, 0);
        }

        public static byte[] UInt32ArrayToBytes(uint[] ary)
        {
            return UInt32ArrayToBytes(ary, 0);
        }

        public static byte[] UInt32ArrayToBytes(int[] ary, int shift)
        {
            if (ary == null)
            {
                throw new ArgumentNullException("ary");
            }
            if ((shift < 0) || (shift >= (ary.Length * 4)))
            {
                throw new ArgumentOutOfRangeException("shift");
            }
            MemoryStream input = new MemoryStream();
            for (int i = 0; i < ary.Length; i++)
            {
                input.Write(BitConverter.GetBytes(ary[i]), 0, 4);
            }
            input.Seek((shift == 0) ? ((long) 0) : ((long) (shift / 4)), SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(input);
            int count = (int) (input.Length - input.Position);
            return reader.ReadBytes(count);
        }

        public static byte[] UInt32ArrayToBytes(uint[] ary, int shift)
        {
            if (ary == null)
            {
                throw new ArgumentNullException("ary");
            }
            if ((shift < 0) || (shift >= (ary.Length * 4)))
            {
                throw new ArgumentOutOfRangeException("shift");
            }
            MemoryStream input = new MemoryStream();
            for (int i = 0; i < ary.Length; i++)
            {
                input.Write(BitConverter.GetBytes(ary[i]), 0, 4);
            }
            input.Seek((shift == 0) ? ((long) 0) : ((long) (shift / 4)), SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(input);
            int count = (int) (input.Length - input.Position);
            return reader.ReadBytes(count);
        }
    }
}