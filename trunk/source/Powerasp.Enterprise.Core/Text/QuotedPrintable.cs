using System;
using System.Globalization;
using System.IO;
using System.Text;
using Powerasp.Enterprise.Core.Text;

namespace Powerasp.Enterprise.Core.Text
{
    public class QuotedPrintable : EncodeBase
    {
        private static QuotedPrintable __default;

        public QuotedPrintable()
        {
        }

        public QuotedPrintable(Encoding encoding) : base(encoding)
        {
        }

        public override string Decode(string s, Encoding encoding)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            if (s == string.Empty)
            {
                return s;
            }
            BinaryWriter writer = null;
            MemoryStream output = new MemoryStream();
            try
            {
                writer = new BinaryWriter(output, base.Encoding);
                for (int i = 0; i < s.Length; i++)
                {
                    char ch = s[i];
                    if (ch == '=')
                    {
                        if (s.Length > (i + 2))
                        {
                            if (IsXDigit(s[i + 1]) && IsXDigit(s[i + 2]))
                            {
                                byte[] buffer2 = new byte[2];
                                char ch2 = s[i + 1];
                                buffer2[0] = byte.Parse(ch2.ToString(), NumberStyles.HexNumber);
                                buffer2[1] = byte.Parse(s[i + 2].ToString(), NumberStyles.HexNumber);
                                byte[] buffer = buffer2;
                                byte num = (byte) ((buffer[0] << 4) | buffer[1]);
                                writer.Write(num);
                                i += 2;
                            }
                            else if (s[i + 1] == '\r')
                            {
                                i += 2;
                            }
                            else
                            {
                                writer.Write((byte) 0x3d);
                            }
                        }
                        else if (s.Length > (i + 1))
                        {
                            if (s[i + 1] == '\r')
                            {
                                i += 2;
                            }
                        }
                        else
                        {
                            writer.Write((byte) 0x3d);
                        }
                    }
                    else
                    {
                        writer.Write(Convert.ToByte(ch));
                    }
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }
            return encoding.GetString(output.ToArray()).Replace("=\r\n", "").Replace("09\r\n", "\t\r\n").Replace("20\r\n", "\r\n");
        }

        public override string Encode(string s, Encoding encoding)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            if (s == string.Empty)
            {
                return s;
            }
            StringBuilder builder = new StringBuilder();
            s = s.Replace("\n", "\r\n");
            s = s.Replace("\r\r", "\r");
            foreach (byte num in encoding.GetBytes(s))
            {
                if (!IsAsc(num))
                {
                    builder.Append(string.Format("={0:x}", (num & 240) >> 4).ToUpper());
                    builder.Append(string.Format("{0:x}", num & 15).ToUpper());
                }
                else
                {
                    builder.Append(Convert.ToChar(num));
                }
            }
            builder.Replace("\r\n", "20\r\n");
            builder.Replace("\t\r\n", "09\r\n");
            return builder.ToString();
        }

        private static bool IsAsc(byte code)
        {
            if ((code <= 0x20) || (code >= 0x3d))
            {
                if ((code > 0x3d) && (code < 0x7f))
                {
                    return true;
                }
                if (((code != 9) && (code != 0x20)) && ((code != 10) && (code != 13)))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsXDigit(char c)
        {
            return (char.IsDigit(c) || (((c >= 'A') && (c <= 'F')) || ((c >= 'a') && (c <= 'f'))));
        }

        public static QuotedPrintable Default
        {
            get
            {
                if (__default == null)
                {
                    __default = new QuotedPrintable();
                }
                return __default;
            }
        }
    }
}