using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.ExtendBaseType
{
    using System;
    using System.Collections;
    using System.Text;

    public class BitArray
    {
        private bool[] _array;
        private bool _symbol;
        public static readonly BitArray One = new BitArray(1);
        public static readonly BitArray Zero = new BitArray(0);

        public BitArray(bool[] array)
        {
            this._symbol = false;
            if ((array.Length % 8) != 0)
            {
                throw new ArgumentOutOfRangeException("array");
            }
            this._array = array;
        }

        public BitArray(byte[] b)
        {
            this._symbol = false;
            this._array = new bool[b.Length * 8];
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this._array[(i * 8) + j] = ((b[i] >> j) & 1) == 1;
                }
            }
        }

        public BitArray(byte b)
            : this(new byte[] { b })
        {
        }

        public BitArray(short v)
            : this(BitConverter.GetBytes(v))
        {
        }

        public BitArray(int i)
            : this(BitConverter.GetBytes(i))
        {
        }

        public BitArray(long l)
            : this(BitConverter.GetBytes(l))
        {
        }

        public BitArray(sbyte b)
            : this(new byte[] { Convert.ToByte(b) })
        {
        }

        public BitArray(ushort v)
            : this(BitConverter.GetBytes(v))
        {
        }

        public BitArray(uint i)
            : this(BitConverter.GetBytes(i))
        {
        }

        public BitArray(ulong l)
            : this(BitConverter.GetBytes(l))
        {
        }

        public override bool Equals(object obj)
        {
            return ((obj is BitArray) && ArrayUtil.Equals(this._array, ((BitArray)obj)._array));
        }

        public bool GetBit(int index)
        {
            if ((index < 0) || (index > (this._array.Length - 1)))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return this._array[index];
        }

        public override int GetHashCode()
        {
            return this._array.GetHashCode();
        }

        public static BitArray operator +(BitArray bits1, BitArray bits2)
        {
            bool[] flagArray2 = bits1._array;
            bool[] flagArray3 = bits2._array;
            bool[] array = new bool[(flagArray2.Length > flagArray3.Length) ? flagArray2.Length : flagArray3.Length];
            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= flagArray2.Length)
                {
                    if (flag)
                    {
                        if (flagArray3[i])
                        {
                            array[i] = false;
                            flag = true;
                        }
                        else
                        {
                            array[i] = true;
                            flag = false;
                        }
                    }
                    else
                    {
                        array[i] = flagArray3[i];
                    }
                }
                else if (i >= flagArray3.Length)
                {
                    if (flag)
                    {
                        if (flagArray2[i])
                        {
                            array[i] = false;
                            flag = true;
                        }
                        else
                        {
                            array[i] = true;
                            flag = false;
                        }
                    }
                    else
                    {
                        array[i] = flagArray2[i];
                    }
                }
                else
                {
                    array[i] = (flagArray2[i] == flagArray3[i]) ? flag : !flag;
                    flag = (flagArray2[i] == flagArray3[i]) ? flagArray2[i] : !array[i];
                }
            }
            return new BitArray(array);
        }

        public static BitArray operator &(BitArray bits1, BitArray bits2)
        {
            bool[] flagArray2 = bits1._array;
            bool[] flagArray3 = bits2._array;
            bool[] array = new bool[(flagArray2.Length > flagArray3.Length) ? flagArray2.Length : flagArray3.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= flagArray2.Length)
                {
                    array[i] = false;
                }
                else if (i >= flagArray3.Length)
                {
                    array[i] = false;
                }
                else
                {
                    array[i] = flagArray2[i] & flagArray3[i];
                }
            }
            return new BitArray(array);
        }

        public static BitArray operator |(BitArray bits1, BitArray bits2)
        {
            bool[] flagArray2 = bits1._array;
            bool[] flagArray3 = bits2._array;
            bool[] array = new bool[(flagArray2.Length > flagArray3.Length) ? flagArray2.Length : flagArray3.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= flagArray2.Length)
                {
                    array[i] = flagArray3[i];
                }
                else if (i >= flagArray3.Length)
                {
                    array[i] = flagArray2[i];
                }
                else
                {
                    array[i] = flagArray2[i] | flagArray3[i];
                }
            }
            return new BitArray(array);
        }

        public static BitArray operator ^(BitArray bits1, BitArray bits2)
        {
            bool[] flagArray2 = bits1._array;
            bool[] flagArray3 = bits2._array;
            bool[] array = new bool[(flagArray2.Length > flagArray3.Length) ? flagArray2.Length : flagArray3.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= flagArray2.Length)
                {
                    array[i] = flagArray3[i];
                }
                else if (i >= flagArray3.Length)
                {
                    array[i] = flagArray2[i];
                }
                else
                {
                    array[i] = flagArray2[i] ^ flagArray3[i];
                }
            }
            return new BitArray(array);
        }

        public static BitArray operator <<(BitArray bits, int pos)
        {
            bool[] destinationArray = new bool[bits._array.Length];
            int length = bits._array.Length - pos;
            Array.Copy(bits._array, pos, destinationArray, 0, length);
            return new BitArray(destinationArray);
        }

        public static BitArray operator *(BitArray bits1, BitArray bits2)
        {
            BitArray array = new BitArray(bits1._array);
            do
            {
                array = bits1 + bits1;
                bits2 -= One;
            }
            while (!bits2.Equals(Zero));
            return array;
        }

        public static BitArray operator >>(BitArray bits, int pos)
        {
            bool[] destinationArray = new bool[bits._array.Length];
            int length = bits._array.Length - pos;
            Array.Copy(bits._array, 0, destinationArray, pos, length);
            return new BitArray(destinationArray);
        }

        public static BitArray operator -(BitArray bits1, BitArray bits2)
        {
            ArrayList list;
            bool[] c = bits1._array;
            bool[] flagArray3 = bits2._array;
            bool[] array = new bool[(c.Length > flagArray3.Length) ? c.Length : flagArray3.Length];
            if (c.Length > flagArray3.Length)
            {
                list = new ArrayList(flagArray3);
                list.AddRange(new bool[array.Length - flagArray3.Length]);
                flagArray3 = (bool[])list.ToArray(typeof(bool));
            }
            else
            {
                list = new ArrayList(c);
                list.AddRange(new bool[array.Length - c.Length]);
                c = (bool[])list.ToArray(typeof(bool));
            }
            Stack stack = new Stack();
            for (int i = 0; i < array.Length; i++)
            {
                if (((i < (array.Length - 1)) || bits1._symbol) || bits2._symbol)
                {
                    if (stack.Count > 0)
                    {
                        if (c[i] == flagArray3[i])
                        {
                            array[i] = true;
                        }
                        else
                        {
                            array[i] = false;
                            if (c[i])
                            {
                                stack.Pop();
                            }
                            else
                            {
                                stack.Push(true);
                            }
                        }
                    }
                    else if (c[i] == flagArray3[i])
                    {
                        array[i] = false;
                    }
                    else
                    {
                        array[i] = false;
                        if (flagArray3[i])
                        {
                            stack.Push(true);
                        }
                    }
                }
                else if (stack.Count > 0)
                {
                    array[i] = true;
                }
                else
                {
                    array[i] = false;
                }
            }
            return new BitArray(array);
        }

        private static byte[] Reverse(byte[] b)
        {
            Array.Reverse(b, 0, b.Length);
            return b;
        }

        public void SetBit(int index, bool b)
        {
            if ((index < 0) || (index > (this._array.Length - 1)))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            this._array[index] = b;
        }

        public byte[] ToByteArray()
        {
            if ((this._array.Length % 8) != 0)
            {
                throw new InvalidCastException("error!");
            }
            byte[] buffer = new byte[this._array.Length / 8];
            for (int i = 0; i < buffer.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    byte[] buffer2;
                    IntPtr ptr;
                    (buffer2 = buffer)[(int)(ptr = (IntPtr)i)] = (byte)(buffer2[(int)ptr] + ((byte)(((this._array[(i * 8) + j] != null) ? 1 : 0) << j)));
                }
            }
            return buffer;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = this._array.Length - 1; i >= 0; i--)
            {
                builder.Append(this._array[i] ? "1" : "0");
            }
            return builder.ToString();
        }
    }
}
