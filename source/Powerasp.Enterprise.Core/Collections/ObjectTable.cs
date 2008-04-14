using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Powerasp.Enterprise.Core;
using Powerasp.Enterprise.Core.Collections;
using Powerasp.Enterprise.Core.Utility;
using Powerasp.Enterprise.Core.Xml;

namespace Powerasp.Enterprise.Core.Collections
{
    public abstract class ObjectTable : MarshalByRefObject, ICollection, IEnumerable, IXmlSerializable
    {
        private System.Text.Encoding _encoding;
        protected bool preadonly;
        protected Hashtable ptable;
        private static readonly Exception ReadOnlyException = new NotSupportedException(SR.TableReadOnly);
        private static readonly XmlSchema Schema;

        static ObjectTable()
        {
            Stream inStream = null;
            try
            {
                string name = string.Format("{0}.Schemas.{1}", typeof(ObjectTable).Namespace, "xsStringTable.xsd");
                inStream = typeof(ObjectTable).Assembly.GetManifestResourceStream(name);
                Schema = XmlSchemaUtil.GetSchema(inStream);
            }
            finally
            {
                if (inStream != null)
                {
                    try
                    {
                        inStream.Close();
                    }
                    catch
                    {
                    }
                    inStream = null;
                }
            }
        }

        protected ObjectTable()
        {
            this.preadonly = false;
            this.ptable = new Hashtable();
            this._encoding = System.Text.Encoding.UTF8;
        }

        protected ObjectTable(ICollection collection) : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (object obj2 in collection)
            {
                if (obj2 is IDictionaryEnumerator)
                {
                    this.BaseAdd(((IDictionaryEnumerator) obj2).Key.ToString(), ((IDictionaryEnumerator) obj2).Value.ToString());
                    continue;
                }
                if (obj2 is DictionaryEntry)
                {
                    DictionaryEntry entry = (DictionaryEntry) obj2;
                    entry = (DictionaryEntry) obj2;
                    this.BaseAdd(entry.Key.ToString(), entry.Value.ToString());
                    continue;
                }
                this.BaseAdd(obj2.ToString(), obj2.ToString());
            }
        }

        protected ObjectTable(Stream inStream) : this(inStream, false)
        {
        }

        protected ObjectTable(string fileName) : this(File.OpenRead(fileName), false)
        {
        }

        protected ObjectTable(XmlReader reader) : this(reader, false)
        {
        }

        protected ObjectTable(Stream inStream, bool readOnly) : this(new XmlTextReader(inStream), readOnly)
        {
        }

        protected ObjectTable(string fileName, bool readOnly) : this(File.OpenRead(fileName), readOnly)
        {
        }

        protected ObjectTable(XmlReader reader, bool readOnly) : this()
        {
            this.ReadXml(reader);
            this.preadonly = readOnly;
        }

        protected void BaseAdd(object key, object obj)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (this.ContainsKey(key))
            {
                throw new ArgumentException("key is already in table.");
            }
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                this.ptable.Add(key, obj);
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        protected void BaseRemove(object key)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if (key == null)
            {
                throw new ArgumentException("key");
            }
            if (!this.ContainsKey(key))
            {
                throw new ArgumentException("the table cann't contain the key.");
            }
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                this.ptable.Remove(key);
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public void Clear()
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                this.ptable.Clear();
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public bool Contains(object obj)
        {
            bool flag = false;
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                flag = this.ptable.ContainsValue(obj);
            }
            finally
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
            return flag;
        }

        public bool ContainsKey(object key)
        {
            if (key == null)
            {
                throw new ArgumentException("key");
            }
            bool flag = false;
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                flag = this.ptable.ContainsKey(key);
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
            return flag;
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if ((index < 0) || (index >= this.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (array.Length < (this.Count - index))
            {
                throw new ArgumentOutOfRangeException("array is of insufficient size.");
            }
            for (int i = index; i < this.Count; i++)
            {
                array.SetValue(this.GetValue(this.GetKey(index)), i);
            }
        }

        public virtual IEnumerator GetEnumerator()
        {
            return new ObjectTableEnumerator(this);
        }

        protected string GetKey(int index)
        {
            if ((index < 0) || (index >= this.ptable.Count))
            {
                throw new IndexOutOfRangeException("index");
            }
            int num = -1;
            IDictionaryEnumerator enumerator = null;
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                enumerator = this.ptable.GetEnumerator();
                goto Label_006A;
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
            Label_0056:
            if (++num == index)
            {
                return enumerator.Key.ToString();
            }
            Label_006A:
            if (enumerator.MoveNext())
            {
                goto Label_0056;
            }
            return null;
        }

        protected virtual object GetObjectWarp(object obj)
        {
            if (obj is DateTime)
            {
                return new DateTimeWrap();
            }
            if (obj is DataSet)
            {
                return new DataSetWrap();
            }
            if (obj is IXmlSerializable)
            {
                return new XmlWrap();
            }
            return obj;
        }

        public virtual XmlSchema GetSchema()
        {
            return Schema;
        }

        protected virtual object GetValue(object key)
        {
            object obj2;
            if (key == null)
            {
                throw new ArgumentException("key");
            }
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                if (!this.ContainsKey(key.ToString()))
                {
                    throw new InvalidOperationException(string.Format("Table cann;t contain this key:{0}", key));
                }
                obj2 = this.ptable[key].ToString();
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
            return obj2;
        }

        public string GetXml()
        {
            return this.GetXml(this.Encoding);
        }

        public string GetXml(System.Text.Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            XmlTextWriter writer = null;
            MemoryStream w = new MemoryStream();
            try
            {
                writer = new XmlTextWriter(w, encoding);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                this.WriteXml(writer);
                writer.WriteEndDocument();
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Flush();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
                try
                {
                    w.Close();
                }
                catch
                {
                }
            }
            return encoding.GetString(w.ToArray());
        }

        protected int IndexOf(object key)
        {
            if (key == null)
            {
                throw new ArgumentException("key");
            }
            int num = -1;
            IDictionaryEnumerator enumerator = this.ptable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                num++;
                if (enumerator.Key == key)
                {
                    return num;
                }
            }
            return -1;
        }

        protected virtual bool ReadItem(XmlReader reader)
        {
            object obj3;
            object attribute = reader.GetAttribute("key");
            string typeName = reader.GetAttribute("type");
            string assemblyName = reader.GetAttribute("assembly");
            if (Convert.ToBoolean(reader.GetAttribute("iswraped")))
            {
                obj3 = ReflectionUtil.CreateInstance(assemblyName, typeName);
                object objectWarp = this.GetObjectWarp(obj3);
                if (!(objectWarp is IObjectXmlSerializable))
                {
                    throw new InvalidCastException("cann't found wraped object");
                }
                ((IObjectXmlSerializable) objectWarp).Wrap(obj3);
                ((IObjectXmlSerializable) objectWarp).ReadXml(reader);
                this.ptable[attribute] = ((IObjectXmlSerializable) objectWarp).UnWrap();
                if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "objectTable"))
                {
                    return false;
                }
                if (((reader.NodeType == XmlNodeType.Element) && (reader.Name == "item")) && !attribute.Equals(reader.GetAttribute("key")))
                {
                    return this.ReadItem(reader);
                }
                return true;
            }
            if (reader.IsEmptyElement)
            {
                this.ptable[attribute] = null;
            }
            else
            {
                if (typeName == null)
                {
                    obj3 = reader.IsEmptyElement ? string.Empty : reader.ReadString();
                }
                else
                {
                    obj3 = Convert.ChangeType(reader.IsEmptyElement ? string.Empty : reader.ReadString(), ReflectionUtil.GetType(assemblyName, typeName));
                }
                this.ptable[attribute] = obj3;
            }
            return true;
        }

        public virtual void ReadXml(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            MemoryStream input = null;
            XmlTextReader reader = null;
            try
            {
                input = new MemoryStream(this.Encoding.GetBytes(s));
                reader = new XmlTextReader(input);
                input.Seek(0L, SeekOrigin.Begin);
                this.ReadXml(reader);
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {
                    }
                    reader = null;
                }
                if (input != null)
                {
                    try
                    {
                        input.Flush();
                    }
                    catch
                    {
                    }
                    input = null;
                }
            }
        }

        public virtual void ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            XmlValidatingReader reader2 = null;
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                this.ptable.Clear();
                if (!(reader is XmlValidatingReader))
                {
                    reader2 = new XmlValidatingReader(reader);
                    XmlSchemaUtil.AppendSchema(reader2, this.GetSchema());
                }
                while (reader.Read())
                {
                    if (((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "objectTable")) || ((!(reader.Name == string.Empty) && (reader.NodeType == XmlNodeType.Element)) && ((reader.Name == "item") && !this.ReadItem(reader))))
                    {
                        return;
                    }
                }
            }
            finally
            {
                if (!(reader is XmlValidatingReader) && (reader2 != null))
                {
                    try
                    {
                        reader2.Close();
                    }
                    catch
                    {
                    }
                    reader2 = null;
                }
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if ((index < 0) || (index > this.ptable.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            this.BaseRemove(this.GetKey(index));
        }

        public void Save(string fileName)
        {
            this.Save(fileName, this.Encoding);
        }

        public void Save(string fileName, System.Text.Encoding encoding)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            FileStream w = null;
            XmlTextWriter writer = null;
            try
            {
                w = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                w.SetLength(0L);
                writer = new XmlTextWriter(w, encoding);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                this.WriteXml(writer);
                writer.WriteEndDocument();
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Flush();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
                if (w != null)
                {
                    try
                    {
                        w.Close();
                    }
                    catch
                    {
                    }
                    w = null;
                }
            }
        }

        protected virtual void SetValue(object key, object obj)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if (key == null)
            {
                throw new ArgumentException("key");
            }
            try
            {
                if (this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                if (this.ContainsKey(key.ToString()))
                {
                    this.ptable[key] = obj;
                }
                else
                {
                    this.ptable.Add(key, obj);
                }
            }
            finally
            {
                if (this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public static ObjectTable Synchronized(ObjectTable table)
        {
            Hashtable.Synchronized(table.ptable);
            return table;
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                writer.WriteStartElement("objectTable");
                writer.WriteAttributeString("xmlns", null, null, "urn:eastasp.framework.collections.objecttable");
                foreach (object obj4 in this.Keys)
                {
                    object obj2 = this.ptable[obj4];
                    if (obj2 == null)
                    {
                        writer.WriteStartElement("item");
                        writer.WriteAttributeString("key", obj4.ToString());
                        writer.WriteAttributeString("iswraped", "false");
                        writer.WriteEndElement();
                        continue;
                    }
                    object objectWarp = this.GetObjectWarp(obj2);
                    writer.WriteStartElement("item");
                    writer.WriteAttributeString("key", obj4.ToString());
                    if (objectWarp is IObjectXmlSerializable)
                    {
                        ((IObjectXmlSerializable) objectWarp).Wrap(obj2);
                        writer.WriteAttributeString("assembly", ((IObjectXmlSerializable) objectWarp).GetObjectType().Assembly.FullName);
                        writer.WriteAttributeString("type", ((IObjectXmlSerializable) objectWarp).GetObjectType().ToString());
                        writer.WriteAttributeString("iswraped", "true");
                        ((IObjectXmlSerializable) objectWarp).WriteXml(writer);
                    }
                    else
                    {
                        if (!(objectWarp is string))
                        {
                            writer.WriteAttributeString("assembly", obj2.GetType().Assembly.FullName);
                            writer.WriteAttributeString("type", obj2.GetType().ToString());
                        }
                        writer.WriteAttributeString("iswraped", "false");
                        writer.WriteString((objectWarp == null) ? string.Empty : objectWarp.ToString());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            finally
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.ptable.Count;
            }
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this._encoding;
            }
            set
            {
                this._encoding = value;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return this.ptable.IsFixedSize;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.preadonly;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.ptable.IsSynchronized;
            }
        }

        public ICollection Keys
        {
            get
            {
                return this.ptable.Keys;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this.ptable.SyncRoot;
            }
        }

        public ICollection Values
        {
            get
            {
                return this.ptable.Values;
            }
        }

        private class ObjectTableEnumerator : IDictionaryEnumerator, IEnumerator
        {
            private int _index;
            private ObjectTable _table;

            internal ObjectTableEnumerator(ObjectTable table)
            {
                this._table = table;
                this._index = -1;
            }

            public bool MoveNext()
            {
                if (++this._index >= this._table.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                this._index = -1;
            }

            public object Current
            {
                get
                {
                    return this._table.ptable[this._table.GetKey(this._index)];
                }
            }

            public DictionaryEntry Entry
            {
                get
                {
                    object key = this._table.GetKey(this._index);
                    return new DictionaryEntry(key, this._table.ptable[key]);
                }
            }

            public object Key
            {
                get
                {
                    return this.Entry.Key;
                }
            }

            public object Value
            {
                get
                {
                    return this.Entry.Value;
                }
            }
        }

        private class XmlDefine
        {
            internal const string AttributeAssembly = "assembly";
            internal const string AttributeIsWraped = "iswraped";
            internal const string AttributeKey = "key";
            internal const string AttributeType = "type";
            internal const string AttributeValue = "value";
            internal const string ElementItem = "item";
            internal const string ElementRoot = "objectTable";
            internal const string Namespace = "urn:eastasp.framework.collections.objecttable";
        }
    }
}