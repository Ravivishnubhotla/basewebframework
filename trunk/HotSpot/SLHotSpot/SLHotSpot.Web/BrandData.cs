using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SLHotSpot.Web
{
    [Serializable]
    public class BrandData
    {
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string FontColor { get; set; }
        public string BorderColor { get; set; }
        public string FillOverColor { get; set; }

 


        public static List<BrandData>  GetAllBrandInfos() 
        {
   
                List<BrandData> brandInfos = new List<BrandData>();

                brandInfos.Add(new BrandData() { Name = "Lenovo", FillColor = "#F28E30", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "HP", FillColor = "#0092D6", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "Dell", FillColor = "#B7295B", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "Acer", FillColor = "#87B81C", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "ThinkPad", FillColor = "#1C2626", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "TOSHIBA", FillColor = "#ED1C24", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "SUMSANG", FillColor = "#002060", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "SONY", FillColor = "#800080", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "Apple", FillColor = "#C0C0C0", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "SUMSANG", FillColor = "#002060", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "ASUS", FillColor = "#006666", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                brandInfos.Add(new BrandData() { Name = "Getway", FillColor = "#6F6041", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
                return brandInfos;
 
             
        }


    }
}