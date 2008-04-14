using System;
using System.Text;

namespace Powerasp.Enterprise.Core.Text
{
    public class Base64 : EncodeBase
    {
        private static Base64 __default;

        public Base64()
        {
        }

        public Base64(Encoding encoding) : base(encoding)
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
            if (s.Trim() == string.Empty)
            {
                return s;
            }
            return encoding.GetString(Convert.FromBase64String(s));
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
            return Convert.ToBase64String(encoding.GetBytes(s));
        }

        public static Base64 Default
        {
            get
            {
                if (__default == null)
                {
                    __default = new Base64();
                }
                return __default;
            }
        }
    }
}