using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace Powerasp.Enterprise.Core.Collections
{
    public class ValueTable : ObjectTable, IDictionary, ICollection, IEnumerable
    {
        public ValueTable()
        {
        }

        public ValueTable(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (object obj2 in collection)
            {
                if (obj2 is IDictionaryEnumerator)
                {
                    base.BaseAdd(((IDictionaryEnumerator) obj2).Key, ((IDictionaryEnumerator) obj2).Value);
                    continue;
                }
                if (obj2 is DictionaryEntry)
                {
                    DictionaryEntry entry = (DictionaryEntry) obj2;
                    entry = (DictionaryEntry) obj2;
                    base.BaseAdd(entry.Key, entry.Value);
                    continue;
                }
                base.BaseAdd(obj2, obj2);
            }
        }

        public ValueTable(Stream inStream) : base(inStream, false)
        {
        }

        public ValueTable(string fileName) : base(File.OpenRead(fileName), false)
        {
        }

        public ValueTable(XmlReader reader) : base(reader, false)
        {
        }

        public ValueTable(Stream inStream, bool readOnly) : base(new XmlTextReader(inStream), readOnly)
        {
        }

        public ValueTable(string fileName, bool readOnly) : base(File.OpenRead(fileName), readOnly)
        {
        }

        public ValueTable(XmlReader reader, bool isReadonly) : base(reader, isReadonly)
        {
        }

        public void Add(object key, object obj)
        {
            base.BaseAdd(key, obj);
        }

        public bool GetBoolean(string key)
        {
            return this.GetBoolean(key, false);
        }

        public bool GetBoolean(string key, bool defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return Convert.ToBoolean(base.GetValue(key));
        }

        public byte GetByte(string key)
        {
            return this.GetByte(key, 0);
        }

        public byte GetByte(string key, byte defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (byte) base.GetValue(key);
        }

        public DateTime GetDateTime(string key)
        {
            return this.GetDateTime(key, DateTime.MinValue);
        }

        public DateTime GetDateTime(string key, DateTime defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (DateTime) base.GetValue(key);
        }

        public decimal GetDecimal(string key)
        {
            return this.GetDecimal(key, 0M);
        }

        public decimal GetDecimal(string key, decimal defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (decimal) base.GetValue(key);
        }

        public double GetDouble(string key)
        {
            return this.GetDouble(key, 0.0);
        }

        public double GetDouble(string key, double defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (double) base.GetValue(key);
        }

        public new IDictionaryEnumerator GetEnumerator()
        {
            return (IDictionaryEnumerator) base.GetEnumerator();
        }

        public float GetFloat(string key)
        {
            return this.GetFloat(key, 0f);
        }

        public float GetFloat(string key, float defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (float) base.GetValue(key);
        }

        public Guid GetGuid(string key)
        {
            return this.GetGuid(key, Guid.Empty);
        }

        public Guid GetGuid(string key, Guid defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (Guid) base.GetValue(key);
        }

        public short GetInt16(string key)
        {
            return this.GetInt16(key, 0);
        }

        public short GetInt16(string key, short defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (short) base.GetValue(key);
        }

        public int GetInt32(string key)
        {
            return this.GetInt32(key, 0);
        }

        public int GetInt32(string key, int defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (int) base.GetValue(key);
        }

        public long GetInt64(string key)
        {
            return this.GetInt64(key, 0L);
        }

        public long GetInt64(string key, long defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return (long) base.GetValue(key);
        }

        public object GetObject(object key)
        {
            return base.GetValue(key);
        }

        public string GetString(string key)
        {
            return base.GetValue(key).ToString();
        }

        public string GetString(string key, string defaultValue)
        {
            if (!base.ContainsKey(key))
            {
                return defaultValue;
            }
            return base.GetValue(key).ToString();
        }

        public void Remove(object key)
        {
            base.BaseRemove(key);
        }

        public void SetBoolean(string key, bool obj)
        {
            base.SetValue(key, obj);
        }

        public void SetByte(string key, byte obj)
        {
            base.SetValue(key, obj);
        }

        public void SetDateTime(string key, DateTime obj)
        {
            base.SetValue(key, obj);
        }

        public void SetDecimal(string key, decimal obj)
        {
            base.SetValue(key, obj);
        }

        public void SetDouble(string key, double obj)
        {
            base.SetValue(key, obj);
        }

        public void SetFloat(string key, float obj)
        {
            base.SetValue(key, obj);
        }

        public void SetGuid(string key, Guid obj)
        {
            base.SetValue(key, obj);
        }

        public void SetInt16(string key, short obj)
        {
            base.SetValue(key, obj);
        }

        public void SetInt32(string key, int obj)
        {
            base.SetValue(key, obj);
        }

        public void SetInt64(string key, long obj)
        {
            base.SetValue(key, obj);
        }

        public void SetObject(string key, object obj)
        {
            this.SetValue(key, obj);
        }

        public void SetString(string key, string obj)
        {
            base.SetValue(key, obj);
        }

        public static ValueTable Synchronized(ValueTable table)
        {
            Hashtable.Synchronized(table.ptable);
            return table;
        }

        public object this[object key]
        {
            get
            {
                return this.GetValue(key);
            }
            set
            {
                this.SetValue(key, value);
            }
        }

        public object this[int index]
        {
            get
            {
                if ((index < 0) || (index >= base.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                object key = base.GetKey(index);
                return this[key];
            }
            set
            {
                if ((index < 0) || (index >= base.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                object key = base.GetKey(index);
                this[key] = value;
            }
        }
    }
}