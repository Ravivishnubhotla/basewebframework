using System.IO;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public interface IHashGenerator
    {
        void Close();
        byte[] ComputeHash(Stream inStream);
        byte[] ComputeHash(byte[] buffer);
        byte[] ComputeHash(string data);
        byte[] ComputeHash(byte[] buffer, int offset, int count);
        string GetHash(Stream inStream);
        string GetHash(byte[] buffer);
        string GetHash(string data);
        string GetHash(byte[] buffer, int offset, int count);
        void Initialize();
        void Update(byte[] data);

        System.Text.Encoding Encoding { get; set; }

        byte[] Hash { get; }
    }
}