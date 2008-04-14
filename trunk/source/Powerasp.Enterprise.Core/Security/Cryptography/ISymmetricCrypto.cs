using System.IO;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public interface ISymmetricCrypto
    {
        byte[] Decrypt(byte[] data);
        byte[] Decrypt(byte[] data, byte[] key);
        void Decrypt(Stream inStream, Stream outStream);
        byte[] Decrypt(byte[] data, string key);
        void Decrypt(string fileSrc, string fileDst);
        void Decrypt(Stream inStream, Stream outStream, string key);
        void Decrypt(Stream inStream, Stream outStream, byte[] key);
        void Decrypt(string fileSrc, string fileDst, byte[] key);
        void Decrypt(string fileSrc, string fileDst, string key);
        byte[] DecryptString(string data);
        byte[] DecryptString(string data, string key);
        byte[] DecryptString(string data, byte[] key);
        byte[] Encrypt(byte[] data);
        void Encrypt(string fileSrc, string fileDst);
        byte[] Encrypt(byte[] data, byte[] key);
        byte[] Encrypt(byte[] data, string key);
        void Encrypt(Stream inStream, Stream outStream);
        void Encrypt(Stream inStream, Stream outStream, string key);
        void Encrypt(Stream inStream, Stream outStream, byte[] key);
        void Encrypt(string fileSrc, string fileDst, byte[] key);
        void Encrypt(string fileSrc, string fileDst, string key);
        byte[] EncryptString(string data);
        byte[] EncryptString(string data, string key);
        byte[] EncryptString(string data, byte[] key);

        System.Text.Encoding Encoding { get; set; }

        byte[] Key { get; set; }

        string Token { get; }
    }
}