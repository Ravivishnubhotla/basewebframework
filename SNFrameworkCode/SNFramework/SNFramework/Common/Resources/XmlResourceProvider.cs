using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web.Compilation;

namespace Legendigital.Framework.Common.Resources
{
    public class XmlResourceProvider : IResourceProvider
    {

        public XmlResourceManager ResourceManager { get; private set; }



        public XmlResourceProvider(string directory, string baseName)
        {

            this.ResourceManager = new XmlResourceManager(directory, baseName);

        }



        public object GetObject(string resourceKey, CultureInfo culture)
        {

            return this.ResourceManager.GetObject(resourceKey, culture);

        }



        public IResourceReader ResourceReader
        {

            get
            {

                return new XmlResourceReader(Path.Combine(this.ResourceManager.Directory, this.ResourceManager.BaseName + ".xml"));

            }

        }
    }
}
