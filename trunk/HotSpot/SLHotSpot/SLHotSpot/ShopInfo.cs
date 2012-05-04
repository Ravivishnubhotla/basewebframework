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
    public class ShopInfo
    {
        public string ShopNO { get; set; }
        public string Brand { get; set; }
        public string ShowText
        {
            get { return ShopNO + "\t" + Brand; }
        }
        public string ShowTooltip { get; set; }


        public SolidColorBrush BrandColor
        {
            get
            {
                SolidColorBrush solidColor = new SolidColorBrush(GetBrandInfo().FillColor);
                return solidColor;
            }
            set
            {

            }
        }

        public BrandInfo GetBrandInfo()
        {
            return BrandInfo.GetBrandInfo(Brand);
        }

        protected static List<ShopInfo> allShopInfos = new List<ShopInfo>();

        static ShopInfo()
        {
            for (int i = 0; i < MainPage.shopMallFloorData.ShopInfos.Count; i++)
            {
                SLHotSpot.HotSpotService.RosShopInfo shopInfo = MainPage.shopMallFloorData.ShopInfos[i];
                allShopInfos.Add(new ShopInfo() { Brand = shopInfo.ShopBrandInfo, ShopNO = shopInfo.SeatNO, ShowTooltip = shopInfo.ShopName });
            }
        }

        public static List<ShopInfo> AllShopInfo
        {
            get
            {
                return allShopInfos;
            }
        }

        public static ShopInfo GetByShopNo(string dataId)
        {
            foreach (ShopInfo shopInfo in allShopInfos)
            {
                if (shopInfo.ShopNO == dataId)
                    return shopInfo;
            }
            return null;
        }
    }
}
