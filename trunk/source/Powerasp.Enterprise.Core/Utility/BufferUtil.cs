using System;
using System.IO;

namespace Powerasp.Enterprise.Core.Utility
{
    public class BufferUtil
    {
        public static byte[] Append(byte[] buf1, byte[] buf2)
        {
            MemoryStream inStream = new MemoryStream(buf1);
            WriteInStream(inStream, buf2);
            return inStream.ToArray();
        }

        public static bool Equals(byte[] buf1, byte[] buf2)
        {
            if (buf1 != buf2)
            {
                if ((buf1 == null) || (buf2 == null))
                {
                    return false;
                }
                if (buf1.Length != buf2.Length)
                {
                    return false;
                }
                for (int i = 0; i < buf1.Length; i++)
                {
                    if (buf1[i] != buf2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static byte[] GetBytes(byte[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if ((index < 0) || (index > buffer.Length))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((count < 0) || ((index + count) > buffer.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            MemoryStream inStream = new MemoryStream(buffer);
            return GetBytes(inStream, index, count);
        }

        public static byte[] GetBytes(Stream inStream, int index, int count)
        {
            byte[] buffer;
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if (!inStream.CanSeek)
            {
                throw new ArgumentException("inStream cann't seek.");
            }
            if ((index < 0) || (index > inStream.Length))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((count < 0) || ((index + count) > inStream.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            BinaryReader reader = null;
            try
            {
                inStream.Seek((long) index, SeekOrigin.Begin);
                buffer = new BinaryReader(inStream).ReadBytes(count);
            }
            finally
            {
                if (reader != null)
                {
                    reader = null;
                }
            }
            return buffer;
        }

        public static void WriteInStream(Stream inStream, byte[] buffer)
        {
            WriteInStream(inStream, buffer, 0, buffer.Length);
        }

        public static void WriteInStream(Stream inStream, byte[] buffer, int index, int count)
        {
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if ((index < 0) || (index > buffer.Length))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((count < 0) || ((index + count) > buffer.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            BinaryWriter writer = null;
            try
            {
                new BinaryWriter(inStream).Write(buffer, index, count);
            }
            finally
            {
                try
                {
                    writer.Flush();
                }
                catch
                {
                }
                writer = null;
            }
        }
    }
}