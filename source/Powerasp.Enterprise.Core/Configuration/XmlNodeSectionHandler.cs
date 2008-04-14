using System;
using System.Configuration;
using System.Xml;

namespace Powerasp.Enterprise.Core.Configuration
{
    public class XmlNodeSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
            return section;
        }
    }
}