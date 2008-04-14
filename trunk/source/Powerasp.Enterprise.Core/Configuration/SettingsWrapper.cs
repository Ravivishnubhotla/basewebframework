using System;
using System.Xml;
using Powerasp.Enterprise.Core.Configuration;

namespace Powerasp.Enterprise.Core.Configuration
{
    public abstract class SettingsWrapper
    {
        private string _section;
        private ISettings _wrapper;

        protected SettingsWrapper(string section, ISettings settings)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this._section = section;
            this._wrapper = settings;
        }

        public bool ContainsKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            return this._wrapper.ContainsKey(this.Section, key);
        }

        public bool GetBoolean(string key)
        {
            return this.GetBoolean(key, false);
        }

        public bool GetBoolean(string key, bool @default)
        {
            return this._wrapper.GetBoolean(this.Section, key, @default);
        }

        public byte GetByte(string key)
        {
            return this.GetByte(key, 0);
        }

        public byte GetByte(string key, byte @default)
        {
            return this._wrapper.GetByte(this.Section, key, @default);
        }

        public byte[] GetBytes(string key)
        {
            return this.GetBytes(key, new byte[0]);
        }

        public byte[] GetBytes(string key, byte[] @default)
        {
            return this._wrapper.GetBytes(this.Section, key, @default);
        }

        public object GetConfig(string key)
        {
            return this._wrapper.GetConfig(this.Section, key);
        }

        public DateTime GetDateTime(string key)
        {
            return this.GetDateTime(key, DateTime.MinValue);
        }

        public DateTime GetDateTime(string key, DateTime @default)
        {
            return this._wrapper.GetDateTime(this.Section, key, @default);
        }

        public decimal GetDecimal(string key)
        {
            return this.GetDecimal(key, -79228162514264337593543950335M);
        }

        public decimal GetDecimal(string key, decimal @default)
        {
            return this._wrapper.GetDecimal(this.Section, key, @default);
        }

        public double GetDouble(string key)
        {
            return this.GetDouble(key, double.MinValue);
        }

        public double GetDouble(string key, double @default)
        {
            return this._wrapper.GetDouble(this.Section, key, @default);
        }

        public float GetFloat(string key)
        {
            return this.GetFloat(key, float.MinValue);
        }

        public float GetFloat(string key, float @default)
        {
            return this._wrapper.GetFloat(this.Section, key, @default);
        }

        public Guid GetGuid(string key)
        {
            return this.GetGuid(key, Guid.Empty);
        }

        public Guid GetGuid(string key, Guid @default)
        {
            return this._wrapper.GetGuid(this.Section, key, @default);
        }

        public short GetInt16(string key)
        {
            return this.GetInt16(key, -32768);
        }

        public short GetInt16(string key, short @default)
        {
            return this._wrapper.GetInt16(this.Section, key, @default);
        }

        public int GetInt32(string key)
        {
            return this.GetInt32(key, -2147483648);
        }

        public int GetInt32(string key, int @default)
        {
            return this._wrapper.GetInt32(this.Section, key, @default);
        }

        public long GetInt64(string key)
        {
            return this.GetInt64(key, -9223372036854775808L);
        }

        public long GetInt64(string key, long @default)
        {
            return this._wrapper.GetInt64(this.Section, key, @default);
        }

        public sbyte GetSByte(string key)
        {
            return this.GetSByte(key, -128);
        }

        public sbyte GetSByte(string key, sbyte @default)
        {
            return this._wrapper.GetSByte(this.Section, key, @default);
        }

        public string GetString(string key)
        {
            return this.GetString(key, string.Empty);
        }

        public string GetString(string key, string @default)
        {
            return this._wrapper.GetString(this.Section, key, @default);
        }

        public ushort GetUInt16(string key)
        {
            return this.GetUInt16(key, 0);
        }

        public ushort GetUInt16(string key, ushort @default)
        {
            return this._wrapper.GetUInt16(this.Section, key, @default);
        }

        public uint GetUInt32(string key)
        {
            return this.GetUInt32(key, 0);
        }

        public uint GetUInt32(string key, uint @default)
        {
            return this._wrapper.GetUInt32(this.Section, key, @default);
        }

        public ulong GetUInt64(string key)
        {
            return this.GetUInt64(key, 0L);
        }

        public ulong GetUInt64(string key, ulong @default)
        {
            return this._wrapper.GetUInt64(this.Section, key, @default);
        }

        public object GetValue(string key)
        {
            return this._wrapper.GetValue(this.Section, key);
        }

        public XmlElement GetXmlElement(string key)
        {
            return this._wrapper.GetXmlElement(this.Section, key);
        }

        public void SetValue(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            this._wrapper.SetValue(this.Section, key, value);
        }

        public string this[string key]
        {
            get
            {
                return this.GetString(key);
            }
            set
            {
                this.SetValue(key, value);
            }
        }

        public string Section
        {
            get
            {
                return this._section;
            }
        }
    }
}