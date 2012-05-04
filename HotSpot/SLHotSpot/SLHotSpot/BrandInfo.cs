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
using SLHotSpot.HotSpotService;

namespace SLHotSpot
{
    public class BrandInfo
    {
        public string Name { get; set; }
        public Color FillColor { get; set; }
        public Color FontColor { get; set; }
        public Color BorderColor { get; set; }
        public Color FillOverColor { get; set; }

        private static List<BrandInfo> brandInfos;

 
        public static List<BrandInfo> BrandInfos
        {
            get { return brandInfos; }
        }

        public static void SetBrandData(ShopMallFloorHotspotData shopMallFloorHotspotData)
        {
            brandInfos = new List<BrandInfo>();

            foreach (BrandData brandData in shopMallFloorHotspotData.Brands)
            {
                brandInfos.Add(new BrandInfo() { Name = brandData.Name, 
                    FillColor = ColorFromString.ToColor(brandData.FillColor), 
                    BorderColor =ColorFromString.ToColor(brandData.BorderColor),
                    FontColor = ColorFromString.ToColor(brandData.FontColor),
                    FillOverColor = ColorFromString.ToColor(brandData.FillOverColor)
                });
            }

        }

        public static BrandInfo GetBrandInfo(string name)
        {
            if (brandInfos == null)
            {
                SetBrandData(MainPage.shopMallFloorData);
            }
            foreach (BrandInfo brandInfo in BrandInfos)
            {
                if (brandInfo.Name.ToLower() == name.ToLower())
                {
                    return brandInfo;
                }
            }
            return null;
        }

        public SolidColorBrush BrandColor
        {
            get
            {
                SolidColorBrush solidColor = new SolidColorBrush(this.FillColor);
                return solidColor;
            }
            set
            {

            }
        }

    }
}
