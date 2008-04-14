using System;
using System.IO;
using System.Text;
using Powerasp.Enterprise.Core.ExtendBaseType;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class ChineseConvert
    {
        private static readonly Encoding __big5Encoding = Encoding.GetEncoding("big5");
        private static readonly DByte[,] __big5Lib;
        private static readonly Encoding __gb2312Encoding = Encoding.GetEncoding("gb2312");
        private static readonly DByte[,] __gb2312Lib;

        static ChineseConvert()
        {
            Type type = typeof(ChineseConvert);
            for (int i = 0; i < 2; i++)
            {
                string name = string.Format("{0}.Data.{1}.dat", type.Namespace, (i == 0) ? "gb2312" : "big5");
                Stream manifestResourceStream = type.Assembly.GetManifestResourceStream(name);
                byte[] buffer = new byte[manifestResourceStream.Length];
                manifestResourceStream.Read(buffer, 0, buffer.Length);
                int index = 0;
                if (i == 0)
                {
                    __gb2312Lib = new DByte[0xff, 0xff];
                    for (int j = 0xa7; j < 0xff; j++)
                    {
                        for (int k = 0xa1; k < 0xff; k++)
                        {
                            __gb2312Lib[j, k] = new DByte(buffer[index + 1], buffer[index]);
                            index += 2;
                        }
                    }
                }
                else
                {
                    __big5Lib = new DByte[0xff, 0xff];
                    for (int m = 0xa1; m < 0xff; m++)
                    {
                        for (int n = 0x40; n < 0xff; n++)
                        {
                            __big5Lib[m, n] = new DByte(buffer[index + 1], buffer[index]);
                            index += 2;
                        }
                    }
                }
            }
        }

        public static char ToBig5(char c)
        {
            int num = c;
            if (num < 0xff)
            {
                return c;
            }
            if (num >= 0xffff)
            {
                throw new NotSupportedException(Powerasp.Enterprise.Core.SR.NotSupported);
            }
            byte[] bytes = __gb2312Encoding.GetBytes(c.ToString());
            byte[] buffer2 = new byte[bytes.Length];
            if ((bytes[0] < 0xa1) || (bytes[1] < 0xa1))
            {
                buffer2 = (byte[]) bytes.Clone();
            }
            else if ((bytes[0] < 0xb0) && (bytes[1] >= 0xa1))
            {
                buffer2[0] = __gb2312Lib[bytes[0] + 6, bytes[1]].Low;
                buffer2[1] = __gb2312Lib[bytes[0] + 6, bytes[1]].High;
            }
            else
            {
                buffer2[0] = __gb2312Lib[bytes[0], bytes[1]].Low;
                buffer2[1] = __gb2312Lib[bytes[0], bytes[1]].High;
            }
            return __big5Encoding.GetString(buffer2, 0, buffer2.Length)[0];
        }

        public static string ToBig5(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                builder.Append(ToBig5(s[i]));
            }
            return builder.ToString();
        }

        public static char ToGb2312(char c)
        {
            int num = c;
            if (num < 0xff)
            {
                return c;
            }
            if (num >= 0xffff)
            {
                throw new NotSupportedException(Powerasp.Enterprise.Core.SR.NotSupported);
            }
            byte[] bytes = __big5Encoding.GetBytes(c.ToString());
            byte[] buffer2 = new byte[bytes.Length];
            if ((bytes[0] < 0xa1) || (bytes[1] < 0x40))
            {
                buffer2 = (byte[]) bytes.Clone();
            }
            else
            {
                buffer2[0] = __big5Lib[bytes[0], bytes[1]].Low;
                buffer2[1] = __big5Lib[bytes[0], bytes[1]].High;
            }
            return __gb2312Encoding.GetString(buffer2, 0, buffer2.Length)[0];
        }

        public static string ToGb2312(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                builder.Append(ToGb2312(s[i]));
            }
            return builder.ToString();
        }
    }
}