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
    public class ShopMallLayoutData
    {
        public string ShopMallNo { get; set; }
        public string ShopMallFloorNo { get; set; }
        public List<RosShopInfo> ShopInfos { get; set; }
        public string ImageUrl { get; set; }
        public string ImageWith { get; set; }
        public string ImageHeight { get; set; }
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
