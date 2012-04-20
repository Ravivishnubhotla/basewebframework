using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLHotSpot
{
    public class SLHotSpotSetting
    {
        private   string hotSpotBgImage = string.Empty;
        private string dataID = string.Empty;
        private Mode controlMode = Mode.View;
        private string webServiceUrl = string.Empty;
        private string rootUrl = string.Empty;

        public string HotSpotBgImage
        {
            get { return hotSpotBgImage; }
            set { hotSpotBgImage = value; }
        }

        public string DataID
        {
            get { return dataID; }
            set { dataID = value; }
        }

        public Mode ControlMode
        {
            get { return controlMode; }
            set { controlMode = value; }
        }

        public string WebServiceUrl
        {
            get { return webServiceUrl; }
            set { webServiceUrl = value; }
        }

        public string RootUrl
        {
            get { return rootUrl; }
            set { rootUrl = value; }
        }
    }
}
