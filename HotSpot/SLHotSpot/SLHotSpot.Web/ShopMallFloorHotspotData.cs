using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLHotSpot.Web
{
    [Serializable]
    public class ShopMallFloorHotspotData
    {
        public string ShopMallNo { get; set; }
        public string ShopMallFloorNo { get; set; }
        public List<RosShopInfo> ShopInfos { get; set; }
        public string ImageUrl { get; set; }
        public List<BrandData> Brands { get; set; }
        //public string ImageWith { get; set; }
        //public string ImageHeight { get; set; }
    }
}