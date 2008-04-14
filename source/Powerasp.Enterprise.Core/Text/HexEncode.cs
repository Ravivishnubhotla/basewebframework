using System;
using System.Text;
using Powerasp.Enterprise.Core.Text;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Text
{
    public class HexEncode : EncodeBase
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
            return encoding.GetString(StringUtil.HexToBytes(s));
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
            return StringUtil.BytesToHex(encoding.GetBytes(s));
        }
    }
}