using System;
using System.IO;
using Powerasp.Enterprise.Core.Attribute;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public abstract class SymmetricCryptoBase : ISymmetricCrypto
    {
        private System.Text.Encoding _encoding = System.Text.Encoding.Unicode;

        protected SymmetricCryptoBase()
        {
        }

        public byte[] Decrypt(byte[] data)
        {
            return this.Decrypt(data, this.Key);
        }

        public void Decrypt(Stream inStream, Stream outStream)
        {
            this.Decrypt(inStream, outStream, this.Key);
        }

        public void Decrypt(string fileSrc, string fileDst)
        {
            this.Decrypt(fileSrc, fileDst, this.Key);
        }

        public byte[] Decrypt(byte[] data, string key)
        {
            return this.Decrypt(data, this.Encoding.GetBytes(key));
        }

        public byte[] Decrypt(byte[] data, byte[] key)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            MemoryStream inStream = new MemoryStream(data);
            MemoryStream outStream = new MemoryStream();
            inStream.Seek(0L, SeekOrigin.Begin);
            this.Decrypt(inStream, outStream, key);
            return outStream.ToArray();
        }

        public abstract void Decrypt(Stream inStream, Stream outStream, byte[] key);
        public void Decrypt(Stream inStream, Stream outStream, string key)
        {
            this.Decrypt(inStream, outStream, this.Encoding.GetBytes(key));
        }

        public void Decrypt(string fileSrc, string fileDst, string key)
        {
            this.Decrypt(fileSrc, fileDst, this.Encoding.GetBytes(key));
        }

        public void Decrypt(string fileSrc, string fileDst, byte[] key)
        {
            if (fileSrc == null)
            {
                throw new ArgumentNullException("fileSrc");
            }
            if (fileDst == null)
            {
                throw new ArgumentNullException("fileDst");
            }
            if (!File.Exists(fileSrc))
            {
                throw new FileNotFoundException("File not found.", fileSrc);
            }
            FileStream inStream = null;
            FileStream outStream = null;
            try
            {
                inStream = File.OpenRead(fileSrc);
                outStream = File.Open(fileDst, FileMode.OpenOrCreate, FileAccess.Write);
                this.Decrypt(inStream, outStream, key);
            }
            finally
            {
                if (inStream != null)
                {
                    try
                    {
                        inStream.Close();
                    }
                    catch
                    {
                    }
                    inStream = null;
                }
                if (outStream != null)
                {
                    try
                    {
                        outStream.Close();
                    }
                    catch
                    {
                    }
                    outStream = null;
                }
            }
        }

        public byte[] DecryptString(string data)
        {
            return this.Decrypt(this.Encoding.GetBytes(data), this.Key);
        }

        public byte[] DecryptString(string data, byte[] key)
        {
            return this.Decrypt(this.Encoding.GetBytes(data), key);
        }

        public byte[] DecryptString(string data, string key)
        {
            return this.Decrypt(this.Encoding.GetBytes(data), key);
        }

        public byte[] Encrypt(byte[] data)
        {
            return this.Encrypt(data, this.Key);
        }

        public void Encrypt(Stream inStream, Stream outStream)
        {
            this.Encrypt(inStream, outStream, this.Key);
        }

        public byte[] Encrypt(byte[] data, byte[] key)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            MemoryStream inStream = new MemoryStream(data);
            MemoryStream outStream = new MemoryStream();
            inStream.Seek(0L, SeekOrigin.Begin);
            this.Encrypt(inStream, outStream, key);
            return outStream.ToArray();
        }

        public byte[] Encrypt(byte[] data, string key)
        {
            return this.Encrypt(data, this.Encoding.GetBytes(key));
        }

        public void Encrypt(string fileSrc, string fileDst)
        {
            this.Encrypt(fileSrc, fileDst, this.Key);
        }

        public void Encrypt(Stream inStream, Stream outStream, string key)
        {
            this.Encrypt(inStream, outStream, this.Encoding.GetBytes(key));
        }

        public abstract void Encrypt(Stream inStream, Stream outStream, byte[] key);
        public void Encrypt(string fileSrc, string fileDst, byte[] key)
        {
            if (fileSrc == null)
            {
                throw new ArgumentNullException("fileSrc");
            }
            if (fileDst == null)
            {
                throw new ArgumentNullException("fileDst");
            }
            if (!File.Exists(fileSrc))
            {
                throw new FileNotFoundException("File not found.", fileSrc);
            }
            FileStream inStream = null;
            FileStream outStream = null;
            try
            {
                inStream = File.OpenRead(fileSrc);
                outStream = File.Open(fileDst, FileMode.OpenOrCreate, FileAccess.Write);
                this.Encrypt(inStream, outStream, key);
            }
            finally
            {
                if (inStream != null)
                {
                    inStream.Close();
                    inStream = null;
                }
                if (outStream != null)
                {
                    outStream.Close();
                    outStream = null;
                }
            }
        }

        public void Encrypt(string fileSrc, string fileDst, string key)
        {
            this.Encrypt(fileSrc, fileDst, this.Encoding.GetBytes(key));
        }

        public byte[] EncryptString(string data)
        {
            return this.Encrypt(this.Encoding.GetBytes(data), this.Key);
        }

        public byte[] EncryptString(string data, byte[] key)
        {
            return this.Encrypt(this.Encoding.GetBytes(data), key);
        }

        public byte[] EncryptString(string data, string key)
        {
            return this.Encrypt(this.Encoding.GetBytes(data), key);
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

        public abstract byte[] Key { get; set; }

        public string Token
        {
            get
            {
                object[] customAttributes = base.GetType().GetCustomAttributes(typeof(UniqueAttribute), true);
                if (customAttributes.Length > 0)
                {
                    return ((UniqueAttribute) customAttributes[0]).Token;
                }
                return string.Empty;
            }
        }
    }
}