using System.IO;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public interface IKeyHashGenerator
    {
        byte[] ComputeHash(Stream inStream);
        byte[] ComputeHash(string data);
        byte[] ComputeHash(byte[] buffer);
        byte[] ComputeHash(Stream inStream, byte[] key);
        byte[] ComputeHash(byte[] buffer, byte[] key);
        byte[] ComputeHash(string data, byte[] key);
        byte[] ComputeHash(byte[] buffer, int offset, int count);
        byte[] ComputeHash(byte[] buffer, int offset, int count, byte[] key);
        string GetHash(Stream inStream);
        string GetHash(string data);
        string GetHash(byte[] buffer);
        string GetHash(Stream inStream, byte[] key);
        string GetHash(string data, byte[] key);
        string GetHash(byte[] buffer, byte[] key);
        string GetHash(byte[] buffer, int offset, int count);
        string GetHash(byte[] buffer, int offset, int count, byte[] key);

        System.Text.Encoding Encoding { get; set; }

        byte[] Key { get; set; }
    }
}