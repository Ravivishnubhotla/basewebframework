using System;

namespace Powerasp.Enterprise.Core.Security.Cryptography
{
    public interface IRNDGenerator
    {
        byte[] GetBytes();
        byte[] GetBytes(int length);
        Guid GetGuid();
        short GetInt16();
        int GetInt32();
        long GetInt64();
        byte[] GetNonZeroBytes();
        byte[] GetNonZeroBytes(int length);
        string GetNonZeroString();
        string GetNonZeroString(int length);
        string GetString();
        string GetString(int length);
    }
}