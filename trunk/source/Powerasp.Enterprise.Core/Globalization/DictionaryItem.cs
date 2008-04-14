using System;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class DictionaryItem : StringDictionary, IInfoItem, IXmlSerializable
    {
        private IList _indexer = new ArrayList(0x10);
        private const string AttributeKey = "key";
        private const string ElementDictionaryItem = "dictionaryItem";
        private const string ElementItem = "item";
        internal const string Namespace = "urn:eastasp.framework.globalization.infoset.dictionaryitem";

        public override void Add(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!this._indexer.Contains(key))
            {
                this._indexer.Add(key);
            }
            base.Add(key, value);
        }

        public string[] GetAllKeys()
        {
            string[] strArray = new string[this._indexer.Count];
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = (string) this._indexer[i];
            }
            return strArray;
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
                if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "dictionaryItem"))
                {
                    return;
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "item"))
                {
                    this.Add(reader.GetAttribute("key"), reader.IsEmptyElement ? string.Empty : reader.ReadString());
                }
            }
        }

        public override void Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (this._indexer.Contains(key))
            {
                this._indexer.Remove(key);
            }
            base.Remove(key);
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            writer.WriteStartElement("dictionaryItem");
            writer.WriteAttributeString("xmlns", null, null, "urn:eastasp.framework.globalization.infoset.dictionaryitem");
            foreach (string str in this.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("key", str);
                writer.WriteString((this[str] == null) ? string.Empty : this[str]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}