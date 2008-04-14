using System;
using System.Security.Cryptography;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public abstract class KeyHashAlgorithmGenerator : KeyHashGeneratorBase
    {
        private KeyedHashAlgorithm _algorithm;

        protected KeyHashAlgorithmGenerator(KeyedHashAlgorithm algorithm)
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }
            this._algorithm = algorithm;
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
            return this._algorithm.ComputeHash(buffer);
        }

        public KeyedHashAlgorithm Algorithm
        {
            get
            {
                return this._algorithm;
            }
        }

        public override byte[] Key
        {
            get
            {
                return this._algorithm.Key;
            }
            set
            {
                this.CheckForKey(value);
                this.CheckForKeyLength(value);
                this._algorithm.Key = value;
            }
        }
    }
}