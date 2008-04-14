using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Powerasp.Enterprise.Core.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class InfoWriter : IInfoWriter, IDisposable
    {
        private CultureInfo _globalCulture;
        private XmlWriter _writer;
        private static readonly System.Version Version = new System.Version(1, 0, 0, 0);

        public InfoWriter(Stream outStream) : this(outStream, CultureInfo.CurrentCulture)
        {
        }

        public InfoWriter(string fileName) : this(fileName, CultureInfo.CurrentCulture)
        {
        }

        public InfoWriter(XmlWriter writer) : this(writer, CultureInfo.CurrentCulture)
        {
        }

        public InfoWriter(Stream outStream, CultureInfo globalCulture) : this(new XmlTextWriter(outStream, Encoding.UTF8), globalCulture)
        {
        }

        public InfoWriter(string fileName, CultureInfo globalCulture) : this(new XmlTextWriter(fileName, Encoding.UTF8), globalCulture)
        {
        }

        public InfoWriter(XmlWriter writer, CultureInfo globalCulture)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (globalCulture == null)
            {
                throw new ArgumentNullException("globalCulture");
            }
            this._writer = writer;
            this._globalCulture = globalCulture;
            if (this._writer is XmlTextWriter)
            {
                ((XmlTextWriter) this._writer).Formatting = Formatting.Indented;
            }
            this._writer.WriteStartDocument();
            this._writer.WriteStartElement("infoTable");
            writer.WriteAttributeString("xmlns", null, null, "urn:eastasp.framework.globalization.infoset");
            this._writer.WriteAttributeString("lang", this._globalCulture.Name);
            this._writer.WriteAttributeString("version", Version.ToString());
        }

        public void Close()
        {
            if (this._writer != null)
            {
                this._writer.WriteEndElement();
                this._writer.WriteEndDocument();
                this.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this._writer != null))
            {
                try
                {
                    this._writer.Flush();
                    this._writer.Close();
                }
                catch
                {
                }
                this._writer = null;
            }
        }

        public void Write(string key, string value)
        {
            this.Write(key, value, this._globalCulture);
        }

        public void Write(string key, string value, CultureInfo cultureInfo)
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
            this._writer.WriteStartElement("item");
            this._writer.WriteAttributeString("key", key);
            if (cultureInfo != this._globalCulture)
            {
                this._writer.WriteAttributeString("lang", cultureInfo.Name);
            }
            this._writer.WriteString(value);
            this._writer.WriteEndElement();
        }

        public void WriteItem(string key, IInfoItem item)
        {
            this.WriteItem(key, item, this._globalCulture);
        }

        public void WriteItem(string key, IInfoItem item, CultureInfo cultureInfo)
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
            this._writer.WriteStartElement("item");
            this._writer.WriteAttributeString("key", key);
            this._writer.WriteAttributeString("assembly", item.GetType().Assembly.FullName);
            this._writer.WriteAttributeString("type", item.GetType().FullName);
            if (cultureInfo != this._globalCulture)
            {
                this._writer.WriteAttributeString("lang", cultureInfo.Name);
            }
            item.WriteXml(this._writer);
            this._writer.WriteEndElement();
        }

        public bool IsClosed
        {
            get
            {
                if (this._writer != null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}