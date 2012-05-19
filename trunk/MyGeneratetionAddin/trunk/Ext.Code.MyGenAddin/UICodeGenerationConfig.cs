using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public class UICodeGenerationConfig
    {
        private InputUIControl[] uIConfigs;
        [XmlArrayItem]
        public InputUIControl[] UIControlConfigs
        {
            get { return uIConfigs; }
            set { uIConfigs = value; }
        }

        public InputUIControl getInputUIControlByName(string name)
        {
            foreach (InputUIControl iuc in this.UIControlConfigs)
            {
                if (iuc.Name.Trim().ToUpper() == name.Trim().ToUpper())
                {
                    return iuc;
                }
            }
            return null;
        }
    }
}