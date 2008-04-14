using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Powerasp.Enterprise.Core.Collections
{
    public class XmlWrap : IObjectXmlSerializable, IXmlSerializable
    {
        private IXmlSerializable _content;

        public Type GetObjectType()
        {
            return this._content.GetType();
        }

        public XmlSchema GetSchema()
        {
            return this._content.GetSchema();
        }

        public void ReadXml(XmlReader reader)
        {
            this._content.ReadXml(reader);
        }

        public object UnWrap()
        {
            return this._content;
        }

        public void Wrap(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (!(obj is IXmlSerializable))
            {
                throw new ArgumentException("obj not an IXmlSerializable interface");
            }
            this._content = obj as IXmlSerializable;
        }

        public void WriteXml(XmlWriter writer)
        {
            this._content.WriteXml(writer);
        }
    }
}