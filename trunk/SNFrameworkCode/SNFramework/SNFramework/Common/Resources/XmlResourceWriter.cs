using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Xml;

namespace Legendigital.Framework.Common.Resources
{
    public class XmlResourceWriter : IResourceWriter
    {
        public XmlDocument Document { get; private set; }

        private string fileName;

        private XmlElement root;



        public XmlResourceWriter(string fileName)
        {

            this.fileName = fileName;

            this.Document = new XmlDocument();

            this.Document.AppendChild(this.Document.CreateXmlDeclaration("1.0", "utf-8", null));

            this.root = this.Document.CreateElement("resources");

            this.Document.AppendChild(this.root);

        }



        public void AddResource(string name, byte[] value)
        {

            throw new NotImplementedException();

        }



        public void AddResource(string name, object value)
        {

            throw new NotImplementedException();

        }



        public void AddResource(string name, string value)
        {

            var node = this.Document.CreateElement("add");

            node.SetAttribute("name", name);

            node.SetAttribute("value", value);

            this.root.AppendChild(node);

        }



        public void Generate()
        {

            using (XmlWriter writer = new XmlTextWriter(this.fileName, Encoding.UTF8))
            {
                this.Document.WriteTo(writer);

            }
        }
        public void Dispose() { }

        public void Close() { }
    }
}
