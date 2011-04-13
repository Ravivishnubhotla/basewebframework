using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml;

namespace Legendigital.Framework.Common.Resources
{
    public class XmlResourceReader : IResourceReader
    {

        public XmlDocument Document { get; private set; }

        public XmlResourceReader(string fileName)
        {

            this.Document = new XmlDocument();

            this.Document.Load(fileName);

        }

        public XmlResourceReader(Stream stream)
        {

            this.Document = new XmlDocument();

            this.Document.Load(stream);

        }
        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

        public IDictionaryEnumerator GetEnumerator()
        {

            Dictionary<string, string> set = new Dictionary<string, string>();

            foreach (XmlNode item in this.Document.GetElementsByTagName("add"))
            {

                set.Add(item.Attributes["name"].Value, item.Attributes["value"].Value);

            }

            return set.GetEnumerator();

        }



        public void Dispose() { }

        public void Close() { }
    }
}
