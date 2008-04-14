using System;
using System.Text;
using Powerasp.Enterprise.Core.Text;

namespace Powerasp.Enterprise.Core.Text
{
    public class UTF8 : EncodeBase
    {
        private static UTF8 __default;

        public UTF8()
        {
        }

        public UTF8(Encoding encoding) : base(encoding)
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
            return Encoding.UTF8.GetString(encoding.GetBytes(s));
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
            return encoding.GetString(Encoding.UTF8.GetBytes(s));
        }

        public static UTF8 Default
        {
            get
            {
                if (__default == null)
                {
                    __default = new UTF8();
                }
                return __default;
            }
        }
    }
}