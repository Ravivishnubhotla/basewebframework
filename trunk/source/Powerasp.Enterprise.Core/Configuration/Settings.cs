using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Powerasp.Enterprise.Core.Caching;
using Powerasp.Enterprise.Core.Configuration;
using Powerasp.Enterprise.Core.Utility;
using Powerasp.Enterprise.Core.Xml;

namespace Powerasp.Enterprise.Core.Configuration
{
    public class Settings : ISettings, IXmlSerializable, ISupportFileCached
    {
        private string _fileName;
        private bool _reading;
        private bool _readOnly;
        private IDictionary _sections = new Hashtable();
        private IDictionary _settings = new Hashtable();
        private bool _writing;
        private static readonly Exception ReadOnlyException = new NotSupportedException(Powerasp.Enterprise.Core.SR.SettingsReadOnly);
        private static readonly XmlSchema Schema;

        static Settings()
        {
            Stream inStream = null;
            try
            {
                string name = string.Format("{0}.Schemas.{1}", typeof(Settings).Namespace, "xsSettings.xsd");
                inStream = typeof(Settings).Assembly.GetManifestResourceStream(name);
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

        internal Settings(string fileName)
        {
            this._fileName = fileName;
            this._readOnly = false;
            this._reading = false;
            this._writing = false;
        }

        public void Clear()
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.TryEnter(this._sections.SyncRoot);
                    Monitor.TryEnter(this._settings.SyncRoot);
                }
                this._sections.Clear();
                this._settings.Clear();
            }
            finally
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this._sections.SyncRoot);
                    Monitor.Exit(this._settings.SyncRoot);
                }
            }
        }

        public bool Contains(string section, string key)
        {
            return this.Contains(section, key);
        }

        public bool ContainsKey(string section, string key)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!this._sections.Contains(section))
            {
                return false;
            }
            string fullName = this.GetFullName(section, key);
            return this._settings.Contains(fullName);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Clear();
            }
        }

        public void FileReload(object state)
        {
            if (state != null)
            {
                if (this._fileName == null)
                {
                    throw new NullReferenceException(Powerasp.Enterprise.Core.SR.LoadFileNotFound);
                }
                this.Clear();
                if (File.Exists(this._fileName) && (this._fileName == state.ToString()))
                {
                    this.Load();
                }
            }
        }

        public bool GetBoolean(string section, string key)
        {
            return this.GetBoolean(section, key, false);
        }

        public bool GetBoolean(string section, string key, bool @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return Convert.ToBoolean(obj2);
            }
            catch
            {
                return @default;
            }
        }

        public byte GetByte(string section, string key)
        {
            return this.GetByte(section, key, 0);
        }

        public byte GetByte(string section, string key, byte @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return byte.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public byte[] GetBytes(string section, string key)
        {
            return this.GetBytes(section, key, new byte[0]);
        }

        public byte[] GetBytes(string section, string key, byte[] @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return StringUtil.HexToBytes(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public object GetConfig(string section, string key)
        {
            string str2;
            string str3;
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            ReflectionUtil.ParseTypeName(this.GetString(section, key), out str3, out str2);
            return ReflectionUtil.CreateInstance(str3, str2);
        }

        public DateTime GetDateTime(string section, string key)
        {
            return this.GetDateTime(section, key, DateTime.MinValue);
        }

        public DateTime GetDateTime(string section, string key, DateTime @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return DateTime.Parse(obj2.ToString()).ToLocalTime();
            }
            catch
            {
                return @default;
            }
        }

        public decimal GetDecimal(string section, string key)
        {
            return this.GetDecimal(section, key);
        }

        public decimal GetDecimal(string section, string key, decimal @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return decimal.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public double GetDouble(string section, string key)
        {
            return this.GetDouble(section, key, double.MinValue);
        }

        public double GetDouble(string section, string key, double @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return double.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public float GetFloat(string section, string key)
        {
            return this.GetFloat(section, key, float.MinValue);
        }

        public float GetFloat(string section, string key, float @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return float.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        protected virtual string GetFullName(string section, string key)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            return string.Format("{0}.{1}", section, key);
        }

        public Guid GetGuid(string section, string key)
        {
            return this.GetGuid(section, key, Guid.Empty);
        }

        public Guid GetGuid(string section, string key, Guid @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            return new Guid(obj2.ToString());
        }

        public short GetInt16(string section, string key)
        {
            return this.GetInt16(section, key, -32768);
        }

        public short GetInt16(string section, string key, short @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return short.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public int GetInt32(string section, string key)
        {
            return this.GetInt32(section, key, -2147483648);
        }

        public int GetInt32(string section, string key, int @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return int.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public long GetInt64(string section, string key)
        {
            return this.GetInt64(section, key, -9223372036854775808L);
        }

        public long GetInt64(string section, string key, long @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return long.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public string[] GetKeys(string section)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            IList list = null;
            if (this._sections.Contains(section))
            {
                lock (this._sections.SyncRoot)
                {
                    if (this._sections.Contains(section))
                    {
                        list = (IList) this._sections[section];
                    }
                }
            }
            if (list == null)
            {
                return new string[0];
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        protected virtual string GetSaveValue(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value is DateTime)
            {
                DateTime time = (DateTime) value;
                return time.ToUniversalTime().ToLongTimeString();
            }
            if (value is byte[])
            {
                return StringUtil.BytesToHex((byte[]) value);
            }
            return value.ToString();
        }

        public sbyte GetSByte(string section, string key)
        {
            return this.GetSByte(section, key, -128);
        }

        public sbyte GetSByte(string section, string key, sbyte @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return sbyte.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public XmlSchema GetSchema()
        {
            return Schema;
        }

        public string[] GetSections()
        {
            if (this._sections.Count > 0)
            {
                lock (this._sections.SyncRoot)
                {
                    if (this._sections.Count > 0)
                    {
                        int num = 0;
                        string[] strArray = new string[this._sections.Count];
                        foreach (object obj2 in this._sections.Keys)
                        {
                            strArray[num++] = obj2.ToString();
                        }
                        return strArray;
                    }
                }
            }
            return new string[0];
        }

        public string GetString(string section, string key)
        {
            return this.GetString(section, key, string.Empty);
        }

        public string GetString(string section, string key, string @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            return obj2.ToString();
        }

        public Type GetType(string section, string key)
        {
            string str2;
            string str3;
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            ReflectionUtil.ParseTypeName(this.GetString(section, key), out str3, out str2);
            return ReflectionUtil.GetType(str3, str2);
        }

        public ushort GetUInt16(string section, string key)
        {
            return this.GetUInt16(section, key, 0);
        }

        public ushort GetUInt16(string section, string key, ushort @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return ushort.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public uint GetUInt32(string section, string key)
        {
            return this.GetUInt32(section, key, 0);
        }

        public uint GetUInt32(string section, string key, uint @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return uint.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public ulong GetUInt64(string section, string key)
        {
            return this.GetUInt64(section, key, 0L);
        }

        public ulong GetUInt64(string section, string key, ulong @default)
        {
            object obj2 = this.GetValue(section, key);
            if (obj2 == null)
            {
                return @default;
            }
            try
            {
                return ulong.Parse(obj2.ToString());
            }
            catch
            {
                return @default;
            }
        }

        public object GetValue(string section, string key)
        {
            object obj2;
            if ((section == null) || (section == string.Empty))
            {
                throw new ArgumentException("section");
            }
            if ((key == null) || (key == string.Empty))
            {
                throw new ArgumentException("key");
            }
            string fullName = this.GetFullName(section, key);
            if (!this._settings.Contains(fullName))
            {
                return null;
            }
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                if (!this._settings.Contains(fullName))
                {
                    return null;
                }
                obj2 = this._settings[fullName];
            }
            finally
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
            return obj2;
        }

        public XmlElement GetXmlElement(string section, string key)
        {
            string str = this.GetString(section, key);
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateXmlDeclaration("1.0", Encoding.UTF8.BodyName, null));
            document.LoadXml(string.Format("<{0}>{1}</{0}>", "item", str));
            return document.DocumentElement;
        }

        public void Load()
        {
            if ((this._fileName == null) || (this._fileName == string.Empty))
            {
                throw new NullReferenceException(Powerasp.Enterprise.Core.SR.LoadFileNotFound);
            }
            if (!File.Exists(this._fileName))
            {
                throw new FileNotFoundException(Powerasp.Enterprise.Core.SR.LoadFileNotFound, this._fileName);
            }
            this.LoadFrom(this._fileName);
        }

        public void LoadFrom(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (fileName == string.Empty)
            {
                throw new ArgumentException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(Powerasp.Enterprise.Core.SR.LoadFileNotFound, fileName);
            }
            FileStream inStream = null;
            try
            {
                inStream = File.OpenRead(fileName);
                this.ReadXml(inStream);
            }
            finally
            {
                if (inStream == null)
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

        public void Merge(Settings settings)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if (settings == null)
            {
                throw new ArgumentNullException("setting");
            }
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(settings.SyncRoot);
                }
                ArrayList list = new ArrayList();
                string[] sections = settings.GetSections();
                for (int i = 0; i < sections.Length; i++)
                {
                    string[] keys = settings.GetKeys(sections[i]);
                    for (int k = 0; k < keys.Length; k++)
                    {
                        list.Add(new SettingItem(sections[i], keys[k], this.GetValue(sections[i], keys[k])));
                    }
                }
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] is SettingItem)
                    {
                        SettingItem item = (SettingItem) list[j];
                        this.SetValue(item.Section, item.Key, item.Value);
                    }
                }
            }
            finally
            {
                if (!settings.IsSynchronized)
                {
                    Monitor.Exit(settings.SyncRoot);
                }
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
            }
        }

        public void ReadXml(Stream inStream)
        {
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(inStream);
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
            }
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            ArrayList list = null;
            XmlValidatingReader reader2 = null;
            try
            {
                if (!this.IsSynchronized)
                {
                    if (this._reading)
                    {
                        return;
                    }
                    Monitor.TryEnter(this.SyncRoot);
                }
                if (this._reading)
                {
                    return;
                }
                this._reading = true;
                if (!(reader is XmlValidatingReader))
                {
                    reader2 = new XmlValidatingReader(reader);
                    XmlSchemaUtil.AppendSchema(reader2, this.GetSchema());
                }
                string section = string.Empty;
                string key = string.Empty;
                list = new ArrayList();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "section":
                                section = reader.GetAttribute("name");
                                break;

                            case "key":
                                key = reader.GetAttribute("name");
                                if ((section != string.Empty) && (key != string.Empty))
                                {
                                    if (reader.IsEmptyElement)
                                    {
                                        list.Add(new SettingItem(section, key, string.Empty));
                                    }
                                    else
                                    {
                                        list.Add(new SettingItem(section, key, reader.ReadElementString()));
                                    }
                                }
                                break;
                        }
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
                this._reading = false;
            }
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        SettingItem item = (SettingItem) list[i];
                        this.SetValue(item.Section, item.Key, item.Value);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void Remove(string section)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if ((section == null) || (section == string.Empty))
            {
                throw new ArgumentException("section");
            }
            string[] keys = this.GetKeys(section);
            for (int i = 0; i < keys.Length; i++)
            {
                this.Remove(section, keys[i]);
            }
        }

        public void Remove(string section, string key)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            ArrayList list = null;
            string fullName = this.GetFullName(section, key);
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                if (this._settings.Contains(fullName))
                {
                    this._settings.Remove(fullName);
                }
                try
                {
                    if (!this.IsSynchronized)
                    {
                        Monitor.Enter(this._sections.SyncRoot);
                    }
                    if (!this._sections.Contains(key))
                    {
                        return;
                    }
                    list = this._settings[section] as ArrayList;
                    if (list == null)
                    {
                        return;
                    }
                    if (!this.IsSynchronized)
                    {
                        lock (list.SyncRoot)
                        {
                            if (list.Contains(key))
                            {
                                list.Remove(key);
                            }
                            goto Label_00E0;
                        }
                    }
                    if (list.Contains(key))
                    {
                        list.Remove(key);
                    }
                    Label_00E0:
                    if ((list.Count == 0) && this._sections.Contains(section))
                    {
                        this._sections.Remove(section);
                    }
                }
                finally
                {
                    if (!this.IsSynchronized)
                    {
                        Monitor.Exit(this._sections.SyncRoot);
                    }
                }
            }
            finally
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public void Save()
        {
            if (this._fileName == null)
            {
                throw new NullReferenceException(Powerasp.Enterprise.Core.SR.SaveFileNotFound);
            }
            this.SaveAs(this._fileName);
        }

        public void SaveAs(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (fileName == string.Empty)
            {
                throw new ArgumentException("fileName");
            }
            FileStream w = null;
            XmlTextWriter writer = null;
            try
            {
                w = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                w.SetLength(0L);
                writer = new XmlTextWriter(w, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteWhitespace("\r\n");
                this.WriteXml(writer);
                writer.WriteEndDocument();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
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

        public void SetConfig(string section, string key, object obj)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            string str = string.Format("{0}, {1}", obj.GetType().FullName, obj.GetType().Assembly.FullName);
            this.SetValue(section, key, str);
        }

        public void SetValue(string section, string key, bool value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, byte value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, DateTime value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, decimal value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, byte[] value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, double value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, Guid value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, short value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, int value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, long value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, object value)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if ((section == null) || (section == string.Empty))
            {
                throw new ArgumentException("section");
            }
            if ((key == null) || (key == string.Empty))
            {
                throw new ArgumentException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("@value");
            }
            ArrayList list = null;
            string fullName = this.GetFullName(section, key);
            try
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Enter(this.SyncRoot);
                }
                this._settings[fullName] = this.GetSaveValue(value);
                try
                {
                    if (!this.IsSynchronized)
                    {
                        Monitor.Enter(this._sections.SyncRoot);
                    }
                    if (this._sections.Contains(section))
                    {
                        list = this._sections[section] as ArrayList;
                    }
                    if (list == null)
                    {
                        list = new ArrayList();
                        if (this.IsSynchronized)
                        {
                            list = ArrayList.Synchronized(list);
                        }
                    }
                    try
                    {
                        if (!this.IsSynchronized)
                        {
                            Monitor.Enter(list.SyncRoot);
                        }
                        if (!list.Contains(key))
                        {
                            list.Add(key);
                        }
                        this._sections[section] = list;
                    }
                    finally
                    {
                        if (!this.IsSynchronized)
                        {
                            Monitor.Exit(list.SyncRoot);
                        }
                    }
                }
                finally
                {
                    if (!this.IsSynchronized)
                    {
                        Monitor.Exit(this._sections.SyncRoot);
                    }
                }
            }
            finally
            {
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
            }
        }

        public void SetValue(string section, string key, sbyte value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, float value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, string value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, ushort value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, uint value)
        {
            this.SetValue(section, key, value);
        }

        public void SetValue(string section, string key, ulong value)
        {
            this.SetValue(section, key, value);
        }

        public static void Synchronized(Settings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            if (!settings.IsSynchronized)
            {
                lock (settings)
                {
                    if (!settings.IsSynchronized)
                    {
                        if (settings._sections is Hashtable)
                        {
                            Hashtable.Synchronized((Hashtable) settings._sections);
                        }
                        if (settings._settings is Hashtable)
                        {
                            Hashtable.Synchronized((Hashtable) settings._settings);
                        }
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (this.IsReadOnly)
            {
                throw ReadOnlyException;
            }
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            try
            {
                if (!this.IsSynchronized)
                {
                    if (this._writing)
                    {
                        return;
                    }
                    Monitor.Enter(this.SyncRoot);
                }
                if (!this._writing)
                {
                    this._writing = false;
                    writer.WriteStartElement("configuration");
                    writer.WriteAttributeString("xmlns", null, null, "urn:eastasp.framework.configuration");
                    writer.WriteString("\r\n");
                    try
                    {
                        if (!this.IsSynchronized)
                        {
                            Monitor.Enter(this._sections.SyncRoot);
                        }
                        foreach (object obj2 in this._sections.Keys)
                        {
                            ArrayList list = this._sections[obj2] as ArrayList;
                            if (list != null)
                            {
                                writer.WriteWhitespace("\t");
                                writer.WriteStartElement("section");
                                writer.WriteAttributeString("name", obj2.ToString());
                                writer.WriteWhitespace("\r\n");
                                lock (list.SyncRoot)
                                {
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        string fullName = this.GetFullName(obj2.ToString(), list[i].ToString());
                                        if (this._settings.Contains(fullName))
                                        {
                                            writer.WriteWhitespace("\t\t");
                                            writer.WriteStartElement("key");
                                            writer.WriteAttributeString("name", list[i].ToString());
                                            try
                                            {
                                                writer.WriteString(this._settings[fullName].ToString());
                                            }
                                            catch
                                            {
                                            }
                                            writer.WriteEndElement();
                                            writer.WriteWhitespace("\r\n");
                                        }
                                    }
                                }
                                writer.WriteWhitespace("\t");
                                writer.WriteEndElement();
                                writer.WriteWhitespace("\r\n");
                            }
                        }
                        writer.WriteEndElement();
                    }
                    finally
                    {
                        if (!this.IsSynchronized)
                        {
                            Monitor.Exit(this._sections.SyncRoot);
                        }
                    }
                }
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
                }
                if (!this.IsSynchronized)
                {
                    Monitor.Exit(this.SyncRoot);
                }
                this._writing = true;
            }
        }

        public string[] Files
        {
            get
            {
                if ((this._fileName == null) || (this._fileName == string.Empty))
                {
                    return new string[0];
                }
                return new string[] { this._fileName };
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this._readOnly;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this._settings.IsSynchronized;
            }
        }

        public string this[string section, string key]
        {
            get
            {
                return this.GetString(section, key);
            }
            set
            {
                this.SetValue(section, key, value);
            }
        }

        public object SyncRoot
        {
            get
            {
                return this._settings.SyncRoot;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SettingItem
        {
            public string Section;
            public string Key;
            public object Value;
            public SettingItem(string section, string key, object value)
            {
                if (section == null)
                {
                    throw new ArgumentNullException("section");
                }
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
                this.Section = section;
                this.Key = key;
                this.Value = value;
            }
        }

        private class XmlDefine
        {
            internal const string AttributeName = "name";
            internal const string AttributeVersion = "version";
            internal const string ElementItem = "item";
            internal const string ElementKey = "key";
            internal const string ElementRoot = "configuration";
            internal const string ElementSection = "section";
            internal const string Namespace = "urn:eastasp.framework.configuration";
            internal const string Prefix = "setting";
        }
    }
}