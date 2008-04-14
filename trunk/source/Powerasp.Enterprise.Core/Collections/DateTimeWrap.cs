using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Powerasp.Enterprise.Core.Collections
{
    public class DateTimeWrap : IObjectXmlSerializable, IXmlSerializable
    {
        private DateTime _dateTime;
        public static readonly DateTime Empty = new DateTime(1, 1, 1, 0, 0, 0, 0);

        public Type GetObjectType()
        {
            return base.GetType();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (!reader.IsEmptyElement)
            {
                this._dateTime = DateTime.Parse(reader.ReadElementString());
            }
            else
            {
                this._dateTime = Empty;
            }
        }

        public object UnWrap()
        {
            if (this._dateTime == Empty)
            {
                return null;
            }
            return this._dateTime;
        }

        public void Wrap(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (obj is DateTime)
            {
                this._dateTime = (DateTime) obj;
            }
            else if (!(obj is DateTimeWrap))
            {
                throw new ArgumentException("Invaild obj type");
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(this._dateTime.ToString("MM/dd/yyyy HH:mm:ss"));
        }
    }
}