using System;
using System.Xml.Serialization;

namespace Powerasp.Enterprise.Core.Collections
{
    public interface IObjectXmlSerializable : IXmlSerializable
    {
        Type GetObjectType();
        object UnWrap();
        void Wrap(object obj);
    }
}