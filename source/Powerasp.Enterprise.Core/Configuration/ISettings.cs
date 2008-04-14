using System;
using System.Xml;
using System.Xml.Serialization;
using Powerasp.Enterprise.Core.Caching;

namespace Powerasp.Enterprise.Core.Configuration
{
    public interface ISettings : IXmlSerializable, ISupportFileCached
    {
        bool ContainsKey(string section, string key);
        bool GetBoolean(string section, string key);
        bool GetBoolean(string section, string key, bool @default);
        byte GetByte(string section, string key);
        byte GetByte(string section, string key, byte @default);
        byte[] GetBytes(string section, string key);
        byte[] GetBytes(string section, string key, byte[] @default);
        object GetConfig(string section, string key);
        DateTime GetDateTime(string section, string key);
        DateTime GetDateTime(string section, string key, DateTime @default);
        decimal GetDecimal(string section, string key);
        decimal GetDecimal(string section, string key, decimal @default);
        double GetDouble(string section, string key);
        double GetDouble(string section, string key, double @default);
        float GetFloat(string section, string key);
        float GetFloat(string section, string key, float @default);
        Guid GetGuid(string section, string key);
        Guid GetGuid(string section, string key, Guid @default);
        short GetInt16(string section, string key);
        short GetInt16(string section, string key, short @default);
        int GetInt32(string section, string key);
        int GetInt32(string section, string key, int @default);
        long GetInt64(string section, string key);
        long GetInt64(string section, string key, long @default);
        sbyte GetSByte(string section, string key);
        sbyte GetSByte(string section, string key, sbyte @default);
        string GetString(string section, string key);
        string GetString(string section, string key, string @default);
        Type GetType(string section, string key);
        ushort GetUInt16(string section, string key);
        ushort GetUInt16(string section, string key, ushort @default);
        uint GetUInt32(string section, string key);
        uint GetUInt32(string section, string key, uint @default);
        ulong GetUInt64(string section, string key);
        ulong GetUInt64(string section, string key, ulong @default);
        object GetValue(string section, string key);
        XmlElement GetXmlElement(string section, string key);
        void SetConfig(string section, string key, object obj);
        void SetValue(string section, string key, object value);

        string this[string section, string key] { get; set; }
    }
}