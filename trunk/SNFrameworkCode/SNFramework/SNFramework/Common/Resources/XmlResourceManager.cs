using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace Legendigital.Framework.Common.Resources
{
    public class XmlResourceManager : FileResourceManager
    {

        public XmlResourceManager(string directory, string baseName)

            : base(directory, baseName, ".xml")

        { }



        protected override ResourceSet InternalGetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
        {

            return new XmlResourceSet(this.GetResourceFileName(culture));

        }

    }
}
