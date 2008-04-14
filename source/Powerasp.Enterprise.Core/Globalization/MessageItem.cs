using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Powerasp.Enterprise.Core.Globalization;

namespace Powerasp.Enterprise.Core.Globalization
{
    public class MessageItem : IInfoItem, IXmlSerializable
    {
        private string _body;
        private string _title;
        internal const string ElementBody = "body";
        internal const string ElementMessageItem = "messageItem";
        internal const string ElementTitle = "title";
        internal const string Namespace = "urn:eastasp.framework.globalization.infoset.messageitem";

        public MessageItem() : this(string.Empty, string.Empty)
        {
        }

        public MessageItem(string title, string body)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }
            this._title = title;
            this._body = body;
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
                if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "messageItem"))
                {
                    return;
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "messageItem"))
                {
                    reader.Read();
                    this._title = reader.ReadElementString("title");
                    this._body = reader.ReadElementString("body");
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            writer.WriteStartElement("messageItem");
            writer.WriteAttributeString("xmlns", null, null, "urn:eastasp.framework.globalization.infoset.messageitem");
            writer.WriteElementString("title", this.Title);
            writer.WriteElementString("body", this.Body);
            writer.WriteEndElement();
        }

        public string Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
    }
}