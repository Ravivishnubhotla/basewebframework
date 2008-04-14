using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Powerasp.Enterprise.Core.Globalization;
using Powerasp.Enterprise.Core.Utility;
using Powerasp.Enterprise.Core.Xml;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class InfoReader : IInfoReader, IDisposable
    {
        private Info _current;
        private CultureInfo _globalCulture;
        private XmlReader _reader;
        private XmlValidatingReader _reader2;
        internal static readonly XmlSchema Schema;

        static InfoReader()
        {
            Stream inStream = null;
            try
            {
                string name = string.Format("{0}.Schemas.{1}", typeof(InfoReader).Namespace, "xsInfo.xsd");
                inStream = typeof(InfoReader).Assembly.GetManifestResourceStream(name);
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

        public InfoReader(Stream inStream)
        {
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            XmlReader reader = new XmlTextReader(inStream);
            if (reader.Read())
            {
                this.Initialize(reader);
            }
        }

        public InfoReader(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(Powerasp.Enterprise.Core.SR.FileNotFound, fileName);
            }
            XmlReader reader = new XmlTextReader(File.OpenRead(fileName));
            if (reader.Read())
            {
                this.Initialize(reader);
            }
        }

        public InfoReader(XmlReader reader)
        {
            this.Initialize(reader);
        }

        public void Close()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this._reader != null))
            {
                try
                {
                    this._reader.Close();
                }
                catch
                {
                }
                this._reader = null;
            }
        }

        public CultureInfo GetCultureInfo()
        {
            if (this._current == null)
            {
                throw new NullReferenceException(Powerasp.Enterprise.Core.SR.CurrentInfoNull);
            }
            return this._current.CultureInfo;
        }

        public string GetKey()
        {
            if (this._current == null)
            {
                throw new NullReferenceException(Powerasp.Enterprise.Core.SR.CurrentInfoNull);
            }
            return this._current.Key;
        }

        public object GetObject()
        {
            if (this._current == null)
            {
                throw new NullReferenceException(Powerasp.Enterprise.Core.SR.CurrentInfoNull);
            }
            return this._current.Value;
        }

        protected virtual void Initialize(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            this._reader = reader;
            if (this._reader is XmlValidatingReader)
            {
                this._reader2 = (XmlValidatingReader) this._reader;
            }
            else
            {
                this._reader2 = new XmlValidatingReader(this._reader);
                XmlSchemaUtil.AppendSchema(this._reader2, Schema);
            }
            if ((this._reader.NodeType != XmlNodeType.Element) || (this._reader.Name != "infoTable"))
            {
                while (this._reader2.Read())
                {
                    if ((this._reader2.NodeType == XmlNodeType.Element) && (this._reader2.Name == "infoTable"))
                    {
                        break;
                    }
                }
            }
            this._globalCulture = (this._reader.XmlLang == null) ? CultureInfo.CurrentCulture : new CultureInfo(this._reader.GetAttribute("lang"));
            this._current = null;
        }

        public bool Read()
        {
            while (this._reader2.Read())
            {
                if ((this._reader2.NodeType == XmlNodeType.Element) && (this._reader2.Name == "item"))
                {
                    string attribute = this._reader2.GetAttribute("key");
                    string assemblyName = this._reader2.GetAttribute("assembly");
                    string typeName = this._reader2.GetAttribute("type");
                    string name = this._reader2.GetAttribute("lang");
                    if (typeName == null)
                    {
                        string str2 = this._reader2.IsEmptyElement ? string.Empty : this._reader2.ReadString();
                        this._current = new Info(attribute, str2, (name == null) ? this._globalCulture : new CultureInfo(name), false);
                    }
                    else
                    {
                        object obj2 = ReflectionUtil.CreateInstance(assemblyName, typeName);
                        if (!(obj2 is IInfoItem))
                        {
                            throw new NotSupportedException("invaild item object");
                        }
                        ((IInfoItem) obj2).ReadXml(this._reader);
                        this._current = new Info(attribute, obj2, (name == null) ? this._globalCulture : new CultureInfo(name), true);
                    }
                    return true;
                }
            }
            return false;
        }

        public bool IsClosed
        {
            get
            {
                if (this._reader != null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsItem
        {
            get
            {
                if (this._current == null)
                {
                    throw new NullReferenceException(Powerasp.Enterprise.Core.SR.CurrentInfoNull);
                }
                return this._current.IsItem;
            }
        }

        private class Info
        {
            private System.Globalization.CultureInfo _cultureInfo;
            private bool _isItem;
            private string _key;
            private object _value;

            internal Info(string key, object value, System.Globalization.CultureInfo cultureInfo) : this(key, value, cultureInfo, false)
            {
            }

            internal Info(string key, object value, System.Globalization.CultureInfo cultureInfo, bool isItem)
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
                this._key = key;
                this._value = value;
                this._cultureInfo = cultureInfo;
                this._isItem = isItem;
            }

            internal System.Globalization.CultureInfo CultureInfo
            {
                get
                {
                    return this._cultureInfo;
                }
            }

            internal bool IsItem
            {
                get
                {
                    return this._isItem;
                }
            }

            internal string Key
            {
                get
                {
                    return this._key;
                }
            }

            internal object Value
            {
                get
                {
                    return this._value;
                }
            }
        }
    }
}