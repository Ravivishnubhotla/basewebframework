using System;
using System.Text;

namespace Powerasp.Enterprise.Core.Text
{
    internal class GlobalEncodingSelection
    {
        private static Encoding _globalEncoding = Encoding.Default;

        public static Encoding Select
        {
            get
            {
                return _globalEncoding;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("null");
                }
                lock (typeof(GlobalEncodingSelection))
                {
                    _globalEncoding = value;
                }
            }
        }
    }
}