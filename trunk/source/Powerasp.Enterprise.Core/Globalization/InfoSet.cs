using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Powerasp.Enterprise.Core.Caching;
using Powerasp.Enterprise.Core.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class InfoSet : IXmlSerializable, ISupportFileCached
    {
        private FileCache _fileCache;
        private IList _files = new ArrayList(CultureInfo.GetCultures(CultureTypes.AllCultures).Length);
        private IDictionary _objectDictionaries = new Hashtable();
        private IDictionary _stringDictionaries = new Hashtable();

        public InfoSet()
        {
            Hashtable.Synchronized((Hashtable) this._stringDictionaries);
            Hashtable.Synchronized((Hashtable) this._objectDictionaries);
            this._fileCache = FileCache.CreateInstance();
            this._fileCache.Add(this);
        }

        public void Clear()
        {
            foreach (IDictionary dictionary in this._stringDictionaries)
            {
                dictionary.Clear();
            }
            this._stringDictionaries.Clear();
        }

        public void FileReload(object state)
        {
            try
            {
                this.ReadXml(state.ToString());
            }
            catch
            {
            }
        }

        public ICollection GetCultureInfos()
        {
            return this._stringDictionaries.Keys;
        }

        protected virtual string GetDefault()
        {
            return string.Empty;
        }

        private IDictionary GetDictionary(CultureInfo cultureInfo, bool created, bool isItem)
        {
            IDictionary dictionary;
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            if (!isItem)
            {
                if (this._stringDictionaries.Contains(cultureInfo))
                {
                    return (this._stringDictionaries[cultureInfo] as IDictionary);
                }
                if (!created)
                {
                    return null;
                }
                dictionary = new Hashtable();
                Hashtable.Synchronized((Hashtable) dictionary);
                this._stringDictionaries.Add(cultureInfo, dictionary);
                return dictionary;
            }
            if (this._objectDictionaries.Contains(cultureInfo))
            {
                return (this._objectDictionaries[cultureInfo] as IDictionary);
            }
            if (!created)
            {
                return null;
            }
            dictionary = new Hashtable();
            Hashtable.Synchronized((Hashtable) dictionary);
            this._objectDictionaries.Add(cultureInfo, dictionary);
            return dictionary;
        }

        public IInfoItem GetItem(string key)
        {
            return this.GetItem(key, CultureInfo.CurrentCulture);
        }

        public IInfoItem GetItem(string key, CultureInfo cultureInfo)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            IDictionary dictionary = this.GetDictionary(cultureInfo, false, true);
            if (dictionary == null)
            {
                return null;
            }
            if (!((Hashtable) dictionary).Contains(key))
            {
                return null;
            }
            return (IInfoItem) dictionary[key];
        }

        public DictionaryEntry[] GetItems(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            int num = 0;
            IDictionary dictionary = this.GetDictionary(cultureInfo, false, true);
            if (dictionary == null)
            {
                return new DictionaryEntry[0];
            }
            DictionaryEntry[] entryArray = new DictionaryEntry[dictionary.Count];
            foreach (string str in dictionary.Keys)
            {
                entryArray[num++] = new DictionaryEntry(str, dictionary[str]);
            }
            return entryArray;
        }

        public XmlSchema GetSchema()
        {
            return InfoReader.Schema;
        }

        public string GetString(string key)
        {
            return this.GetString(key, CultureInfo.CurrentCulture);
        }

        public string GetString(string key, CultureInfo cultureInfo)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            IDictionary dictionary = this.GetDictionary(cultureInfo, false, false);
            if (dictionary == null)
            {
                return this.GetDefault();
            }
            if (!((Hashtable) dictionary).Contains(key))
            {
                return this.GetDefault();
            }
            return dictionary[key].ToString();
        }

        public DictionaryEntry[] GetStrings(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            int num = 0;
            IDictionary dictionary = this.GetDictionary(cultureInfo, false, false);
            if (dictionary == null)
            {
                return new DictionaryEntry[0];
            }
            DictionaryEntry[] entryArray = new DictionaryEntry[dictionary.Count];
            foreach (string str in dictionary.Keys)
            {
                entryArray[num++] = new DictionaryEntry(str, dictionary[str]);
            }
            return entryArray;
        }

        public string GetXml()
        {
            return this.GetXml(Encoding.UTF8);
        }

        public string GetXml(CultureInfo cultureInfo)
        {
            return this.GetXml(cultureInfo, Encoding.UTF8);
        }

        public string GetXml(Encoding encoding)
        {
            string str;
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            MemoryStream outStream = new MemoryStream();
            try
            {
                this.WriteXml(outStream);
                str = encoding.GetString(outStream.ToArray());
            }
            finally
            {
                if (outStream != null)
                {
                    try
                    {
                        outStream.Close();
                    }
                    catch
                    {
                    }
                    outStream = null;
                }
            }
            return str;
        }

        public string GetXml(CultureInfo cultureInfo, Encoding encoding)
        {
            string str;
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            MemoryStream outStream = new MemoryStream();
            try
            {
                this.WriteXml(outStream, cultureInfo);
                str = encoding.GetString(outStream.ToArray());
            }
            finally
            {
                if (outStream != null)
                {
                    try
                    {
                        outStream.Close();
                    }
                    catch
                    {
                    }
                    outStream = null;
                }
            }
            return str;
        }

        public void ReadXml(IInfoReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            while (reader.Read())
            {
                if (!reader.IsItem)
                {
                    this.SetString(reader.GetKey(), reader.GetObject().ToString(), reader.GetCultureInfo());
                }
                else
                {
                    this.SetItem(reader.GetKey(), (IInfoItem) reader.GetObject(), reader.GetCultureInfo());
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

        public void ReadXml(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(Powerasp.Enterprise.Core.SR.FileNotFound, fileName);
            }
            FileStream inStream = null;
            try
            {
                inStream = File.OpenRead(fileName);
                if (!this._files.Contains(fileName))
                {
                    this._files.Add(fileName);
                }
                this.ReadXml(inStream);
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

        public void ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            InfoReader reader2 = null;
            try
            {
                reader2 = new InfoReader(reader);
                this.ReadXml(reader2);
            }
            finally
            {
                if (reader2 != null)
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
            }
        }

        public void Remove(string key, CultureInfo cultureInfo)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            IDictionary dictionary = this.GetDictionary(cultureInfo, false, false);
            if (dictionary != null)
            {
                if (!((Hashtable) dictionary).ContainsKey(key))
                {
                    return;
                }
                dictionary.Remove(key);
                if (dictionary.Count == 0)
                {
                    this._stringDictionaries.Remove(cultureInfo);
                }
            }
            dictionary = this.GetDictionary(cultureInfo, false, true);
            if ((dictionary != null) && ((Hashtable) dictionary).ContainsKey(key))
            {
                dictionary.Remove(key);
                if (dictionary.Count == 0)
                {
                    this._stringDictionaries.Remove(cultureInfo);
                }
            }
        }

        public void SetItem(string key, IInfoItem item, CultureInfo cultureInfo)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            IDictionary dictionary = this.GetDictionary(cultureInfo, true, true);
            if (((Hashtable) dictionary).ContainsKey(key))
            {
                dictionary[key] = item;
            }
            else
            {
                dictionary.Add(key, item);
            }
        }

        public void SetString(string key, string value, CultureInfo cultureInfo)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            IDictionary dictionary = this.GetDictionary(cultureInfo, true, false);
            if (((Hashtable) dictionary).ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public void WriteXml(IInfoWriter writer)
        {
            foreach (CultureInfo info in this.GetCultureInfos())
            {
                this.WriteXml(writer, info);
            }
        }

        public void WriteXml(Stream outStream)
        {
            if ((outStream == null) || (outStream == Stream.Null))
            {
                throw new ArgumentNullException("outStream");
            }
            InfoWriter writer = null;
            try
            {
                writer = new InfoWriter(outStream, CultureInfo.CurrentCulture);
                this.WriteXml(writer);
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Close();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
            }
        }

        public void WriteXml(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            InfoWriter writer = null;
            try
            {
                writer = new InfoWriter(fileName, CultureInfo.CurrentCulture);
                this.WriteXml(writer);
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Close();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            InfoWriter writer2 = null;
            try
            {
                writer2 = new InfoWriter(writer, CultureInfo.CurrentCulture);
                this.WriteXml(writer2);
            }
            finally
            {
                if (writer2 != null)
                {
                    try
                    {
                        writer2.Close();
                    }
                    catch
                    {
                    }
                    writer2 = null;
                }
            }
        }

        public void WriteXml(IInfoWriter writer, CultureInfo cultureInfo)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            DictionaryEntry[] strings = this.GetStrings(cultureInfo);
            for (int i = 0; i < strings.Length; i++)
            {
                writer.Write(strings[i].Key.ToString(), strings[i].Value.ToString(), cultureInfo);
            }
            strings = this.GetItems(cultureInfo);
            for (int j = 0; j < strings.Length; j++)
            {
                writer.WriteItem(strings[j].Key.ToString(), (IInfoItem) strings[j].Value, cultureInfo);
            }
        }

        public void WriteXml(Stream outStream, CultureInfo cultureInfo)
        {
            if ((outStream == null) || (outStream == Stream.Null))
            {
                throw new ArgumentNullException("outStream");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            InfoWriter writer = null;
            try
            {
                writer = new InfoWriter(outStream, cultureInfo);
                this.WriteXml(writer, cultureInfo);
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Close();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
            }
        }

        public void WriteXml(string fileName, CultureInfo cultureInfo)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            InfoWriter writer = null;
            try
            {
                writer = new InfoWriter(fileName, cultureInfo);
                this.WriteXml(writer, cultureInfo);
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Close();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
            }
        }

        public void WriteXml(XmlWriter writer, CultureInfo cultureInfo)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (cultureInfo == null)
            {
                throw new ArgumentNullException("cultureInfo");
            }
            InfoWriter writer2 = null;
            try
            {
                writer2 = new InfoWriter(writer, cultureInfo);
                this.WriteXml(writer2, cultureInfo);
            }
            finally
            {
                if (writer2 != null)
                {
                    try
                    {
                        writer2.Close();
                    }
                    catch
                    {
                    }
                    writer2 = null;
                }
            }
        }

        public string[] Files
        {
            get
            {
                string[] strArray = new string[this._files.Count];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = this._files[i].ToString();
                }
                return strArray;
            }
        }
    }
}