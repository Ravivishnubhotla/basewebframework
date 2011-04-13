using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;

namespace Legendigital.Framework.Common.Resources
{
    public class XmlResourceSet : ResourceSet
    {
        public XmlResourceSet(Stream stream)
        {

            this.Reader = new XmlResourceReader(stream);

            this.Table = new Hashtable();

            this.ReadResources();

        }

        public XmlResourceSet(string fileName)
        {

            base.Reader = new XmlResourceReader(fileName);

            base.Table = new Hashtable();

            this.ReadResources();

        }

        public override Type GetDefaultReader()
        {

            return typeof(XmlResourceReader);

        }

        public override Type GetDefaultWriter()
        {

            return typeof(XmlResourceWriter);

        }
    }
}
