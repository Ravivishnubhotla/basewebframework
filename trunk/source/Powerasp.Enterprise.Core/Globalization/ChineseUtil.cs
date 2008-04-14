using System;
using System.Text;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class ChineseUtil
    {
        private const string Completed = "整";
        private const string CurrencyName = "元";
        private const string DigitallyFraction = "角分";
        private const string DigitallyInteger = "拾佰仟万拾佰仟亿拾佰仟万";
        private const string Dot = "点";
        private static readonly int[] GBKSpellCodes = new int[] { 
                                                                    0xb0a1, 0xb0c5, 0xb2c1, 0xb4ee, 0xb6ea, 0xb7a2, 0xb8c1, 0xb9fe, 0xbbf7, 0xbbf7, 0xbfa6, 0xc0ac, 0xc2e8, 0xc4c3, 0xc5b6, 0xc5be, 
                                                                    0xc6da, 0xc8bb, 0xc8f6, 0xcbfa, 0xcdda, 0xcdda, 0xcdda, 0xcef4, 0xd1b9, 0xd4d1
                                                                };
        private const int GBKSpellMaxCode = 0xd7fa;
        private const string NumberArray = "零壹贰叁肆伍陆柒捌玖";

        public static char GetGBKSpell(char c)
        {
            int unicodeCode = GetUnicodeCode(c);
            for (int i = 0; i < GBKSpellCodes.Length; i++)
            {
                int num2 = GBKSpellCodes[i];
                int num3 = (i < (GBKSpellCodes.Length - 1)) ? GBKSpellCodes[i + 1] : 0xd7fa;
                if ((unicodeCode >= num2) && (unicodeCode < num3))
                {
                    return (char) (0x41 + i);
                }
            }
            return c;
        }

        public static string GetGBKSpell(string s)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                builder.Append(GetGBKSpell(s[i]));
            }
            return builder.ToString();
        }

        public static int GetUnicodeCode(char c)
        {
            byte[] bytes = Encoding.Default.GetBytes(c.ToString());
            if (bytes.Length == 1)
            {
                return c;
            }
            return ((bytes[0] << 8) + bytes[1]);
        }

        public static string ToChineseCurrency(decimal d)
        {
            string str2;
            string str3;
            string str = string.Format("{0:f2}", d);
            int index = str.IndexOf(".");
            if (index >= 0)
            {
                str2 = str.Substring(0, index);
                str3 = str.Substring(index + 1, (str.Length - index) - 1);
            }
            else
            {
                str2 = str;
                str3 = string.Empty;
            }
            if (!(str3 == string.Empty) && !(str3 == "00"))
            {
                return string.Format("{0}{1}{2}", ToChineseInteger((long) int.Parse(str2)), "元", ToChineseCurrencyFraction((long) int.Parse(str3)));
            }
            return string.Format("{0}{1}{2}", ToChineseInteger((long) int.Parse(str2)), "元", "整");
        }

        private static string ToChineseCurrencyFraction(long l)
        {
            string str = l.ToString();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (i >= 2)
                {
                    break;
                }
                char ch = str[i];
                builder.Append("零壹贰叁肆伍陆柒捌玖"[int.Parse(ch.ToString())]);
                builder.Append("角分"[i]);
            }
            return builder.ToString();
        }

        public static string ToChineseDecimal(decimal d)
        {
            string str2;
            string str3;
            string str = d.ToString();
            int index = str.IndexOf(".");
            if (index >= 0)
            {
                str2 = str.Substring(0, index);
                str3 = str.Substring(index + 1, (str.Length - index) - 1);
            }
            else
            {
                str2 = str;
                str3 = string.Empty;
            }
            if (str3 == string.Empty)
            {
                return ToChineseInteger((long) int.Parse(str2));
            }
            return string.Format("{0}{2}{1}", ToChineseInteger((long) int.Parse(str2)), ToChineseFraction((long) int.Parse(str3)), "点");
        }

        private static string ToChineseFraction(long l)
        {
            string str = l.ToString();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                builder.Append("零壹贰叁肆伍陆柒捌玖"[int.Parse(ch.ToString())]);
            }
            return builder.ToString();
        }

        public static string ToChineseInteger(long l)
        {
            string s = l.ToString();
            if (s.Length > 12)
            {
                throw new ArgumentOutOfRangeException("Invaild interger");
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s, i))
                {
                    string str2 = s[i].ToString();
                    builder.Append("零壹贰叁肆伍陆柒捌玖"[int.Parse(str2)]);
                    if (i < (s.Length - 1))
                    {
                        builder.Append("拾佰仟万拾佰仟亿拾佰仟万"[(s.Length - i) - 2]);
                    }
                }
            }
            return builder.ToString();
        }
    }
}