using System.IO;
using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public abstract class HashGenerator : IHashGenerator
    {
        private HashAlgorithm _algorithm;
        private System.Text.Encoding _encoding;
        private CryptoStream _inStream;

        protected HashGenerator(HashAlgorithm algorithm)
        {
            this._algorithm = algorithm;
            this._encoding = System.Text.Encoding.Unicode;
        }

        public void Close()
        {
            this._inStream.Close();
        }

        public byte[] ComputeHash(Stream inStream)
        {
            return this._algorithm.ComputeHash(inStream);
        }

        public byte[] ComputeHash(byte[] buffer)
        {
            return this._algorithm.ComputeHash(buffer);
        }

        public byte[] ComputeHash(string data)
        {
            return this.ComputeHash(this.Encoding.GetBytes(data));
        }

        public byte[] ComputeHash(byte[] buffer, int offset, int count)
        {
            return this._algorithm.ComputeHash(buffer, offset, count);
        }

        public string GetHash(Stream inStream)
        {
            return StringUtil.BytesToHex(this.ComputeHash(inStream));
        }

        public string GetHash(byte[] buffer)
        {
            return StringUtil.BytesToHex(this.ComputeHash(buffer));
        }

        public string GetHash(string data)
        {
            return StringUtil.BytesToHex(this.ComputeHash(data));
        }

        public string GetHash(byte[] buffer, int offset, int count)
        {
            return StringUtil.BytesToHex(this.ComputeHash(buffer, offset, count));
        }

        public void Initialize()
        {
            this._algorithm.Initialize();
            this._inStream = new CryptoStream(Stream.Null, this._algorithm, CryptoStreamMode.Write);
        }

        public void Update(byte[] data)
        {
            this._inStream.Write(data, 0, data.Length);
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this._encoding;
            }
            set
            {
                this._encoding = value;
            }
        }

        public byte[] Hash
        {
            get
            {
                return this._algorithm.Hash;
            }
        }
    }
}