using System;
using System.IO;
using Powerasp.Enterprise.Core.Attribute;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    [Unique("{BD4FA7A7-1B54-4956-90C2-F54B71FCA74D}")]
    public class ENCCrypto : SymmetricCryptoBase
    {
        private byte[] _key;

        private void CheckForKey(byte[] key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
        }

        private void CheckForKeyLength(byte[] key)
        {
            if (key.Length < 8)
            {
                throw new WeakKeyException("key length is short.");
            }
        }

        public override void Decrypt(Stream inStream, Stream outStream, byte[] key)
        {
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if ((outStream == null) || (outStream == Stream.Null))
            {
                throw new ArgumentNullException("outStream");
            }
            this.CheckForKey(key);
            this.CheckForKeyLength(key);
            byte num = 0;
            int num2 = 0;
            int position = 0;
            int reversePos = 0;
            int index = 0;
            BinaryReader reader = null;
            position = (int) outStream.Position;
            reversePos = this.GetReversePos((int) inStream.Length, key);
            int num1 = (reversePos - 2) % key.Length;
            try
            {
                reader = new BinaryReader(inStream, base.Encoding);
                outStream.SetLength(position + inStream.Length);
                outStream.Seek((long) position, SeekOrigin.Begin);
                while (outStream.Position != outStream.Length)
                {
                    if (outStream.Position < (reversePos - 1))
                    {
                        num2 = (reversePos - ((int) outStream.Position)) - 2;
                    }
                    else
                    {
                        num2 = (int) outStream.Position;
                    }
                    inStream.Seek((long) num2, SeekOrigin.Begin);
                    num = (byte) (reader.ReadByte() ^ key[index]);
                    if (++index >= key.Length)
                    {
                        index = 0;
                    }
                    outStream.WriteByte(num);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }
        }

        public override void Encrypt(Stream inStream, Stream outStream, byte[] key)
        {
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if ((outStream == null) || (outStream == Stream.Null))
            {
                throw new ArgumentNullException("outStream");
            }
            this.CheckForKey(key);
            this.CheckForKeyLength(key);
            byte num = 0;
            int num2 = 0;
            int position = 0;
            int reversePos = 0;
            int index = 0;
            BinaryReader reader = null;
            position = (int) outStream.Position;
            reversePos = this.GetReversePos((int) inStream.Length, key);
            try
            {
                reader = new BinaryReader(inStream, base.Encoding);
                outStream.SetLength(position + inStream.Length);
                while (inStream.Position != inStream.Length)
                {
                    num = (byte) (reader.ReadByte() ^ key[index]);
                    if (++index >= key.Length)
                    {
                        index = 0;
                    }
                    num2 = (position + ((inStream.Position < reversePos) ? (reversePos - ((int) inStream.Position)) : ((int) inStream.Position))) - 1;
                    outStream.Seek((long) num2, SeekOrigin.Begin);
                    outStream.WriteByte(num);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }
        }

        private int GetReversePos(int length, byte[] key)
        {
            MD5Generator generator = new MD5Generator();
            int num2 = BitConverter.ToInt32(generator.ComputeHash(key), 0);
            if (length < 2)
            {
                return 0;
            }
            int num = ((length % 2) == 0) ? (length / 2) : ((length + 1) / 2);
            while (num <= num2)
            {
                num2 /= num;
            }
            return num2;
        }

        public override byte[] Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this.CheckForKey(value);
                this._key = value;
            }
        }
    }
}