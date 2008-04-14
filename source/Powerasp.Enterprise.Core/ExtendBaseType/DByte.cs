using System.Runtime.InteropServices;

namespace Powerasp.Enterprise.Core.ExtendBaseType
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DByte
    {
        private byte _high;
        private byte _low;
        public DByte(byte high, byte low)
        {
            this._low = low;
            this._high = high;
        }

        public byte High
        {
            get
            {
                return this._high;
            }
        }
        public byte Low
        {
            get
            {
                return this._low;
            }
        }
    }
}