using System;
using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Security.Cryptography;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public class RNDGenerator : IRNDGenerator
    {
        private RandomNumberGenerator _generator;
        private const int DefaultLength = 0x10;

        public RNDGenerator() : this(RandomNumberGenerator.Create())
        {
        }

        protected RNDGenerator(RandomNumberGenerator generator)
        {
            if (generator == null)
            {
                throw new ArgumentNullException("generator");
            }
            this._generator = generator;
        }

        public byte[] GetBytes()
        {
            return this.GetBytes(this.Length);
        }

        public virtual byte[] GetBytes(int length)
        {
            byte[] data = new byte[length];
            this._generator.GetBytes(data);
            return data;
        }

        public Guid GetGuid()
        {
            return new Guid(this.GetBytes(0x10));
        }

        public short GetInt16()
        {
            return BitConverter.ToInt16(this.GetBytes(4), 0);
        }

        public int GetInt32()
        {
            return BitConverter.ToInt32(this.GetBytes(4), 0);
        }

        public long GetInt64()
        {
            return BitConverter.ToInt64(this.GetBytes(8), 0);
        }

        public byte[] GetNonZeroBytes()
        {
            return this.GetNonZeroBytes(this.Length);
        }

        public virtual byte[] GetNonZeroBytes(int length)
        {
            byte[] data = new byte[length];
            this._generator.GetNonZeroBytes(data);
            return data;
        }

        public string GetNonZeroString()
        {
            return this.GetNonZeroString(this.Length);
        }

        public string GetNonZeroString(int length)
        {
            return StringUtil.BytesToHex(this.GetNonZeroBytes(length));
        }

        public string GetString()
        {
            return this.GetString(this.Length);
        }

        public string GetString(int length)
        {
            return StringUtil.BytesToHex(this.GetBytes(length));
        }

        protected virtual int Length
        {
            get
            {
                return 0x10;
            }
        }
    }
}