using System;
using System.Collections;
using System.IO;
using System.Xml;
using Powerasp.Enterprise.Core.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public class StringTable : ObjectTable
    {
        public StringTable()
        {
        }

        public StringTable(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (object obj2 in collection)
            {
                if (obj2 is IDictionaryEnumerator)
                {
                    base.BaseAdd(((IDictionaryEnumerator) obj2).Key, ((IDictionaryEnumerator) obj2).Value.ToString());
                    continue;
                }
                if (obj2 is DictionaryEntry)
                {
                    DictionaryEntry entry = (DictionaryEntry) obj2;
                    entry = (DictionaryEntry) obj2;
                    base.BaseAdd(entry.Key, entry.Value.ToString());
                    continue;
                }
                base.BaseAdd(obj2, obj2.ToString());
            }
        }

        public StringTable(Stream inStream) : base(inStream, false)
        {
        }

        public StringTable(string fileName) : base(File.OpenRead(fileName), false)
        {
        }

        public StringTable(XmlReader reader) : base(reader, false)
        {
        }

        public StringTable(Stream inStream, bool readOnly) : base(new XmlTextReader(inStream), readOnly)
        {
        }

        public StringTable(string fileName, bool readOnly) : base(File.OpenRead(fileName), readOnly)
        {
        }

        public StringTable(XmlReader reader, bool isReadonly) : base(reader, isReadonly)
        {
        }

        public void Add(string key, string s)
        {
            base.BaseAdd(key, s);
        }

        public string GetValue(string key)
        {
            return this.GetValue(key, string.Empty);
        }

        public string GetValue(string key, string defaultValue)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (key == string.Empty)
            {
                throw new ArgumentException("key");
            }
            if (base.ContainsKey(key))
            {
                return base.GetValue(key).ToString();
            }
            return defaultValue;
        }

        public void Remove(string key)
        {
            base.BaseRemove(key);
        }

        public void SetValue(string key, string s)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (key == string.Empty)
            {
                throw new ArgumentException("key");
            }
            base.SetValue(key, s);
        }

        public string this[string key]
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

        public string this[int index]
        {
            get
            {
                if ((index < 0) || (index >= base.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                object key = base.GetKey(index);
                return this[key.ToString()];
            }
            set
            {
                if ((index < 0) || (index >= base.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                object key = base.GetKey(index);
                this[key.ToString()] = value;
            }
        }
    }
}