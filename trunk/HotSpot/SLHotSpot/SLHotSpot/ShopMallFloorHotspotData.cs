using System;
using System.Collections.Generic;
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
    public class ShopMallFloorHotspotData
    {
        public string ShopMallNo { get; set; }
        public string ShopMallFloorNo { get; set; }
        public List<RosShopInfo> ShopInfos { get; set; }
        public string ImageUrl { get; set; }
        public List<BrandData> Brands { get; set; }
    }

    public class BrandData
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string FontColor { get; set; }
        public string BorderColor { get; set; }
        public string FillOverColor { get; set; }
    }

    public class RosShopInfo
    {
        public string ShopNO { get; set; }

        public string ShopName { get; set; }

        public string ShopBrandInfo { get; set; }

        public int CompleteNumber { get; set; }

        public string HotSpotInfo { get; set; }
    }
}
