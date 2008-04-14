using System;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Powerasp.Enterprise.Core.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class ListItem : IInfoItem, IXmlSerializable
    {
        private IList _array = new ArrayList();
        private const string ElementItem = "item";
        private const string ElementListItem = "listItem";
        internal const string Namespace = "urn:eastasp.framework.globalization.infoset.listitem";

        public void Add(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value)");
            }
            if (!this._array.Contains(value))
            {
                this._array.Add(value);
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "listItem"))
                {
                    return;
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "item"))
                {
                    this.Add(reader.IsEmptyElement ? string.Empty : reader.ReadString());
                }
            }
        }

        public void Remove(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value)");
            }
            if (!this._array.Contains(value))
            {
                this._array.Add(value);
            }
        }

        public string[] ToArray()
        {
            return (string[]) ((ArrayList) this._array).ToArray(typeof(string));
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            writer.WriteStartElement("listItem");
            writer.WriteAttributeString("xmlns", null, null, "urn:eastasp.framework.globalization.infoset.listitem");
            foreach (object obj2 in this._array)
            {
                writer.WriteElementString("item", obj2.ToString());
            }
            writer.WriteEndElement();
        }

        public int Count
        {
            get
            {
                return this._array.Count;
            }
        }

        public string this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this._array.Count))
                {
                    throw new ArgumentNullException("index");
                }
                return this._array[index].ToString();
            }
            set
            {
                if ((index < 0) || (index >= this._array.Count))
                {
                    throw new ArgumentNullException("index");
                }
                this._array[index] = value;
            }
        }
    }
}