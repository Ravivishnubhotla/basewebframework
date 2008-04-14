using System;
using System.Globalization;
using System.Text;
using Powerasp.Enterprise.Core.Text;

namespace Powerasp.Enterprise.Core.Text
{
    public class ESCEncode : EncodeBase
    {
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
            if (s.Trim() == string.Empty)
            {
                return s;
            }
            if (((s == null) || (s.Length <= 8)) || ((s.Length % 2) != 0))
            {
                throw new ArgumentException("s");
            }
            byte key = byte.Parse(s.Substring(s.Length - 4, 2), NumberStyles.HexNumber);
            s = s.Substring(2, s.Length - 6);
            byte[] bytes = new byte[s.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                byte b = byte.Parse(s.Substring(i * 2, 2), NumberStyles.HexNumber);
                bytes[i] = Decrypt(b, key);
            }
            return encoding.GetString(bytes);
        }

        private static byte Decrypt(byte b, byte key)
        {
            int num = key % 8;
            return (byte) ((b >> num) | (b << (8 - num)));
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
            if (s.Trim() == string.Empty)
            {
                return s;
            }
            byte[] bytes = encoding.GetBytes(s);
            byte key = GenerateKey(bytes[0]);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                byte num2 = Encrypt(bytes[i], key);
                builder.Append(Convert.ToByte(num2).ToString("x0").PadLeft(2, '0').ToUpper());
            }
            builder.Append(key.ToString("x0").PadLeft(2, '0').ToUpper());
            return (GenerateRandomize() + builder.ToString() + GenerateRandomize());
        }

        private static byte Encrypt(byte b, byte key)
        {
            int num = key % 8;
            return (byte) ((b << num) | (b >> (8 - num)));
        }

        private static byte GenerateKey(byte c)
        {
            if (c <= 0x7f)
            {
                if (c >= 0x41)
                {
                    c = (byte) (c - 0x40);
                    return c;
                }
                c = (byte) (c + 0x40);
            }
            return c;
        }

        private static string GenerateRandomize()
        {
            return new Random().Next(0, 0x7f).ToString("x0").PadLeft(2, '0').ToUpper();
        }
    }
}