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
    public class ShopBrandInfo
    {
        public string SeatNo { get; set; }
        public string BrandName { get; set; }
    }



    public class ShopInfo : HotSpotService.RosShopInfo
    {
        //public string ShopNO { get; set; }

        //public string Brand { get; set; }

        //public string BrandsName { get; set; }
 
        //public string PlaceLevel { get; set; }

        //public string ShopName { get; set; }
 
        //public int CompleteNumber { get; set; }

        //public string UserArea { get; set; }

        //public string BrandArea { get; set; }

 



        public string ShowText
        {
            get { return SeatNO + "\r\n" + this.ShopBrandInfo + "\r\n" + this.PlaceLevel.ToUpper(); }
        }

        public string ShowTooltip
        {
            get {
                return "店铺名称：" + ShopName + "\r\n" +
                         "经销商名称：" + ShopName + "\r\n" +
                         "经营品牌：" + BrandsName + "\r\n" +
                         "面积：" + UserArea + "\r\n" +
                         "位置：" + PlaceLevel ;
            }
        }
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
            return BrandInfo.GetBrandInfo(this.ShopBrandInfo);
        }

        protected static List<ShopInfo> allShopInfos = new List<ShopInfo>();

        static ShopInfo()
        {
            for (int i = 0; i < MainPage.shopMallFloorData.ShopInfos.Count; i++)
            {
                SLHotSpot.HotSpotService.RosShopInfo shopInfo = MainPage.shopMallFloorData.ShopInfos[i];
                allShopInfos.Add(new ShopInfo()
                                     {
                                         ShopBrandInfo = shopInfo.ShopBrandInfo,
                                         SeatNO = shopInfo.SeatNO, 
                                         ShopName = shopInfo.ShopName,
                                         BrandArea = shopInfo.BrandArea,
                                         UserArea = shopInfo.UserArea,
                                         BrandsName = shopInfo.BrandsName,
                                         PlaceLevel = shopInfo.PlaceLevel,
                                         CompleteNumber = shopInfo.CompleteNumber
                                     });
            }



 
        }

        public static List<ShopInfo> AllShopInfo
        {
            get
            {
                return allShopInfos;
            }
        }

        public static ShopInfo GetBySeatNo(string dataId)
        {
            foreach (ShopInfo shopInfo in allShopInfos)
            {
                if (shopInfo.SeatNO == dataId)
                    return shopInfo;
            }
            return null;
        }

        public string GetNewText(string brand)
        {
            return SeatNO + "\r\n" + brand + "\r\n" + this.PlaceLevel.ToUpper(); 
        }
    }
}
