using System;
using System.Collections.Generic;
using System.Text;

namespace Powerasp.Enterprise.Core.Xml
{
    using System;
    using System.Text;
    using System.Xml;

    public class XmlUtil
    {
        private static readonly string DefaultBody = (DefaultDeclaration + "\n<{2}/>");
        private static readonly string DefaultDeclaration = "<?xml version=\"{0}\" encoding=\"{1}\" ?>";

        public static XmlAttribute AppendAttribute(XmlDocument doc, string name, string value)
        {
            return AppendAttribute(doc, doc.DocumentElement, name, value);
        }

        public static XmlAttribute AppendAttribute(XmlNode parent, string name, string value)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            return AppendAttribute(parent.OwnerDocument, parent, name, value);
        }

        public static XmlAttribute AppendAttribute(XmlDocument doc, XmlNode parent, string name, string value)
        {
            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }
            if ((name == null) || (name == string.Empty))
            {
                throw new ArgumentException("name");
            }
            if (value == null)
            {
                throw new ArgumentNullException("@value");
            }
            if (parent == null)
            {
                parent = doc.DocumentElement;
            }
            XmlAttribute node = doc.CreateNode(XmlNodeType.Attribute, name, string.Empty) as XmlAttribute;
            node.Value = value;
            return parent.Attributes.Append(node);
        }

        public static XmlNode AppendNode(XmlNode parent, string name)
        {
            return AppendNode(parent, name, string.Empty);
        }

        public static XmlNode AppendNode(XmlNode parent, string name, string value)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            return AppendNode(parent.OwnerDocument, parent, name, value);
        }

        private static XmlNode AppendNode(XmlDocument doc, XmlNode parent, string name, string value)
        {
            return AppendNode(doc, parent, name, value, string.Empty);
        }

        public static XmlNode AppendNode(XmlNode parent, string name, string value, string namespaceURI)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            return AppendNode(parent.OwnerDocument, parent, name, value, namespaceURI);
        }

        private static XmlNode AppendNode(XmlDocument doc, XmlNode parent, string name, string value, string namespaceURI)
        {
            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }
            if (parent == null)
            {
                parent = doc.DocumentElement;
            }
            else if (!parent.OwnerDocument.Equals(doc))
            {
                throw new ArgumentException("doc not parent node's owner document!");
            }
            if ((name == null) || (name == string.Empty))
            {
                throw new ArgumentException("name");
            }
            if (value == null)
            {
                throw new ArgumentNullException("@value");
            }
            XmlNode newChild = null;
            if (namespaceURI == string.Empty)
            {
                newChild = doc.CreateElement(name);
            }
            else
            {
                newChild = doc.CreateElement(name, namespaceURI);
            }
            newChild.InnerText = value;
            parent.AppendChild(newChild);
            return newChild;
        }

        public static XmlDocument CreateDocument(string root)
        {
            return CreateDocument(root, Encoding.Default);
        }

        public static XmlDocument CreateDocument(string root, Encoding encoding)
        {
            return CreateDocument(root, encoding, string.Empty);
        }

        public static XmlDocument CreateDocument(string root, Encoding encoding, string namespaceURI)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateXmlDeclaration("1.0", encoding.BodyName, null));
            if (namespaceURI == string.Empty)
            {
                document.AppendChild(document.CreateElement(root));
                return document;
            }
            document.AppendChild(document.CreateElement(root, namespaceURI));
            return document;
        }

        public static XmlAttribute GetAttribute(XmlNode parent, string name)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            if ((name == null) || (name == string.Empty))
            {
                throw new ArgumentException("name");
            }
            try
            {
                return parent.Attributes[name];
            }
            catch
            {
                return null;
            }
        }

        public static string GetAttributeText(XmlNode parent, string name)
        {
            XmlAttribute attribute = GetAttribute(parent, name);
            if (attribute != null)
            {
                return attribute.InnerText;
            }
            return string.Empty;
        }

        public static string GetAttributeValue(XmlNode parent, string name)
        {
            XmlAttribute attribute = GetAttribute(parent, name);
            if (attribute != null)
            {
                return attribute.Value;
            }
            return string.Empty;
        }

        public static string GetAttributeXml(XmlNode parent, string name)
        {
            XmlAttribute attribute = GetAttribute(parent, name);
            if (attribute != null)
            {
                return attribute.InnerXml;
            }
            return string.Empty;
        }

        public static XmlNode GetChildNode(XmlNode parent, string name)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            if ((name == null) || (name == string.Empty))
            {
                throw new ArgumentException("name");
            }
            return parent.SelectSingleNode(name);
        }

        public static string GetChildNodeText(XmlNode parent, string name)
        {
            XmlNode childNode = GetChildNode(parent, name);
            if (childNode != null)
            {
                return childNode.InnerText;
            }
            return string.Empty;
        }

        public static string GetChildNodeXml(XmlNode parent, string name)
        {
            XmlNode childNode = GetChildNode(parent, name);
            if (childNode != null)
            {
                return childNode.InnerXml;
            }
            return string.Empty;
        }

        public static string GetDeclaration()
        {
            return GetDeclaration(Encoding.Default);
        }

        public static string GetDeclaration(string encoding)
        {
            return GetDeclaration("1.0", encoding);
        }

        public static string GetDeclaration(Encoding encoding)
        {
            return GetDeclaration("1.0", encoding);
        }

        public static string GetDeclaration(string version, string encoding)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }
            return string.Format(DefaultDeclaration, version, encoding);
        }

        public static string GetDeclaration(string version, Encoding encoding)
        {
            return GetDeclaration(version, encoding.EncodingName.ToLower());
        }
    }
}
