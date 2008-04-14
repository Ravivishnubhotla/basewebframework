using System;
using Powerasp.Enterprise.Core.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public abstract class KeyHashGenerator : KeyHashGeneratorBase
    {
        private IHashGenerator _crypto;
        private byte[] _key;

        protected KeyHashGenerator(IHashGenerator crypto)
        {
            if (crypto == null)
            {
                throw new ArgumentNullException("crypto");
            }
            this._key = null;
            this._crypto = crypto;
        }

        protected virtual void CheckForKey(byte[] key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
        }

        protected virtual void CheckForKeyLength(byte[] key)
        {
        }

        public override byte[] ComputeHash(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            byte[] key = this.Key;
            if (key == null)
            {
                throw new NullReferenceException("Key is null.");
            }
            byte[] array = new byte[0x40];
            byte[] buffer4 = new byte[0x40];
            if (key.Length > 0x40)
            {
                this._crypto.Initialize();
                key = this._crypto.ComputeHash(key);
            }
            Array.Clear(array, 0, array.Length);
            Array.Clear(buffer4, 0, buffer4.Length);
            Array.Copy(key, 0, array, 0, key.Length);
            Array.Copy(key, 0, buffer4, 0, key.Length);
            for (int i = 0; i < 0x40; i++)
            {
                byte[] buffer6;
                IntPtr ptr;
                (buffer6 = array)[(int) (ptr = (IntPtr) i)] = (byte) (buffer6[(int) ptr] ^ 0x36);
                (buffer6 = buffer4)[(int) (ptr = (IntPtr) i)] = (byte) (buffer6[(int) ptr] ^ 0x5c);
            }
            this._crypto.Initialize();
            this._crypto.Update(array);
            this._crypto.Update(buffer);
            this._crypto.Close();
            byte[] hash = this._crypto.Hash;
            this._crypto.Initialize();
            this._crypto.Update(buffer4);
            this._crypto.Update(hash);
            this._crypto.Close();
            return this._crypto.Hash;
        }

        public IHashGenerator Algorithm
        {
            get
            {
                return this._crypto;
            }
        }

        public override System.Text.Encoding Encoding
        {
            get
            {
                return this._crypto.Encoding;
            }
            set
            {
                this._crypto.Encoding = value;
            }
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
                this.CheckForKeyLength(value);
                this._key = value;
            }
        }
    }
}