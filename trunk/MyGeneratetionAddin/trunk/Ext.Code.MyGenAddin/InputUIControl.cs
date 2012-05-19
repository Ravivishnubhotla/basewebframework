using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Xml.Serialization;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public class InputUIControl
    {
        private string name;
        private bool canSet;
        private bool canRead;
        private string dataType;
        private bool hasItems;
        private string controlIDFormat;
        private string controlGetValue;

        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [XmlAttribute]
        public bool CanSet
        {
            get { return canSet; }
            set { canSet = value; }
        }
        [XmlAttribute]
        public bool CanRead
        {
            get { return canRead; }
            set { canRead = value; }
        }
        [XmlAttribute]
        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        [XmlAttribute]
        public bool HasItems
        {
            get { return hasItems; }
            set { hasItems = value; }
        }
        [XmlAttribute]
        public string ControlIDFormat
        {
            get { return controlIDFormat; }
            set { controlIDFormat = value; }
        }
        [XmlAttribute]
        public string ControlGetSetValuePrppertyName
        {
            get { return controlGetValue; }
            set { controlGetValue = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}