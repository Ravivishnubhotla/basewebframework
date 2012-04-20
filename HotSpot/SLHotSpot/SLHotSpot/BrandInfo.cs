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
    public class BrandInfo
    {
        public string Name { get; set; }
        public Color FillColor { get; set; }
        public Color FontColor { get; set; }
        public Color BorderColor { get; set; }
        public Color FillOverColor { get; set; }

        private static List<BrandInfo> brandInfos;

        static BrandInfo()
        {
            brandInfos = new List<BrandInfo>();

            brandInfos.Add(new BrandInfo() { Name = "Lenovo", FillColor = ColorFromString.ToColor("#F28E30"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "HP", FillColor = ColorFromString.ToColor("#0092D6"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "Dell", FillColor = ColorFromString.ToColor("#B7295B"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "Acer", FillColor = ColorFromString.ToColor("#87B81C"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "ThinkPad", FillColor = ColorFromString.ToColor("#1C2626"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "TOSHIBA", FillColor = ColorFromString.ToColor("#ED1C24"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "SUMSANG", FillColor = ColorFromString.ToColor("#002060"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "SONY", FillColor = ColorFromString.ToColor("#800080"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "Apple", FillColor = ColorFromString.ToColor("#C0C0C0"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "SUMSANG", FillColor = ColorFromString.ToColor("#002060"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "ASUS", FillColor = ColorFromString.ToColor("#006666"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });
            brandInfos.Add(new BrandInfo() { Name = "Getway", FillColor = ColorFromString.ToColor("#6F6041"), BorderColor = Colors.Black, FontColor = Colors.White, FillOverColor = Colors.Orange });

        }


        public static List<BrandInfo> BrandInfos
        {
            get { return brandInfos; }
        }

        public static BrandInfo GetBrandInfo(string name)
        {
            foreach (BrandInfo brandInfo in BrandInfos)
            {
                if (brandInfo.Name == name)
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
