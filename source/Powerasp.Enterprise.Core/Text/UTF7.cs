using System;
using System.Text;
using Powerasp.Enterprise.Core.Text;

namespace Powerasp.Enterprise.Core.Text
{
    public class UTF7 : EncodeBase
    {
        private static UTF7 __default;

        public UTF7()
        {
        }

        public UTF7(Encoding encoding) : base(encoding)
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
            return Encoding.UTF7.GetString(encoding.GetBytes(s));
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
            return encoding.GetString(Encoding.UTF7.GetBytes(s));
        }

        public static UTF7 Default
        {
            get
            {
                if (__default == null)
                {
                    __default = new UTF7();
                }
                return __default;
            }
        }
    }
}