using System;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Powerasp.Enterprise.Core.Collections
{
    public class DataSetWrap : IObjectXmlSerializable, IXmlSerializable
    {
        private DataSet _dataSet;

        public Type GetObjectType()
        {
            return this._dataSet.GetType();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            this._dataSet.ReadXml(reader, XmlReadMode.IgnoreSchema);
        }

        public object UnWrap()
        {
            return this._dataSet;
        }

        public void Wrap(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (!(obj is DataSet))
            {
                throw new ArgumentException("obj not a dataset");
            }
            this._dataSet = obj as DataSet;
        }

        public void WriteXml(XmlWriter writer)
        {
            this._dataSet.WriteXml(writer, XmlWriteMode.IgnoreSchema);
        }
    }
}