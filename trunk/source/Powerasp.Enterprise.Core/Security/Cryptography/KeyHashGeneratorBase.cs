using System;
using System.IO;
using Powerasp.Enterprise.Core.Security.Cryptography;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public abstract class KeyHashGeneratorBase : IKeyHashGenerator
    {
        private System.Text.Encoding _encoding = System.Text.Encoding.Unicode;

        protected KeyHashGeneratorBase()
        {
        }

        public byte[] ComputeHash(Stream inStream)
        {
            byte[] buffer2;
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if (!inStream.CanWrite)
            {
                throw new ArgumentException("Cann't write");
            }
            BinaryReader reader = null;
            try
            {
                int count = (int) (inStream.Length - inStream.Position);
                byte[] buffer = new BinaryReader(inStream, this.Encoding).ReadBytes(count);
                buffer2 = this.ComputeHash(buffer);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }
            return buffer2;
        }

        public byte[] ComputeHash(string data)
        {
            return this.ComputeHash(this.Encoding.GetBytes(data));
        }

        public abstract byte[] ComputeHash(byte[] buffer);
        public byte[] ComputeHash(Stream inStream, byte[] key)
        {
            this.Key = key;
            return this.ComputeHash(inStream);
        }

        public byte[] ComputeHash(byte[] buffer, byte[] key)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            this.Key = key;
            return this.ComputeHash(buffer);
        }

        public byte[] ComputeHash(string data, byte[] key)
        {
            this.Key = key;
            return this.ComputeHash(data);
        }

        public byte[] ComputeHash(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if ((offset < 0) || (offset > (buffer.Length - 1)))
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if ((count < 0) || (count > (buffer.Length - 1)))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if ((count - offset) < 0)
            {
                throw new ArgumentException("count must greater than offset!");
            }
            byte[] destinationArray = new byte[count - offset];
            if ((count - offset) < 0x40)
            {
                for (int i = 0; i < count; i++)
                {
                    destinationArray[i] = buffer[offset + i];
                }
            }
            else
            {
                Array.Copy(buffer, offset, destinationArray, 0, count);
            }
            return this.ComputeHash(destinationArray);
        }

        public byte[] ComputeHash(byte[] buffer, int offset, int count, byte[] key)
        {
            this.Key = key;
            return this.ComputeHash(buffer, offset, count);
        }

        public string GetHash(Stream inStream)
        {
            return StringUtil.BytesToHex(this.ComputeHash(inStream));
        }

        public string GetHash(string data)
        {
            return StringUtil.BytesToHex(this.ComputeHash(data));
        }

        public string GetHash(byte[] buffer)
        {
            return StringUtil.BytesToHex(this.ComputeHash(buffer));
        }

        public string GetHash(Stream inStream, byte[] key)
        {
            return StringUtil.BytesToHex(this.ComputeHash(inStream, key));
        }

        public string GetHash(string data, byte[] key)
        {
            return StringUtil.BytesToHex(this.ComputeHash(data, key));
        }

        public string GetHash(byte[] buffer, byte[] key)
        {
            return StringUtil.BytesToHex(this.ComputeHash(buffer, key));
        }

        public string GetHash(byte[] buffer, int offset, int count)
        {
            return StringUtil.BytesToHex(this.ComputeHash(buffer, offset, count));
        }

        public string GetHash(byte[] buffer, int offset, int count, byte[] key)
        {
            return StringUtil.BytesToHex(this.ComputeHash(buffer, offset, count, key));
        }

        public virtual System.Text.Encoding Encoding
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
    }
}