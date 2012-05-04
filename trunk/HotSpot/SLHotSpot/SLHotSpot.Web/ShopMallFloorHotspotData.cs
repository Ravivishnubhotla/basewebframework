using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace SLHotSpot.Web
{
    public class Point
    {
        public Point()
        {
        }
        public double X { get; set; }
        public double Y { get; set; }
    }


    public class HotSpotText
    {

        public HotSpotText()
        {
        }

        public HotSpotText(JObject obj)
        {
            JToken jtoken = obj.First;

            while (jtoken != null)//loop through columns
            {
                JProperty property = (JProperty)jtoken;

                switch (property.Name)
                {
                    case "Text":
                        this.Text = property.Value.ToObject<string>();
                        break;
                    case "TextLeft":
                        this.TextLeft = property.Value.ToObject<double>();
                        break;
                    case "TextTop":
                        this.TextTop = property.Value.ToObject<double>();
                        break;
                    case "TextIsVertical":
                        this.TextIsVertical = property.Value.ToObject<bool>();
                        break;
                    case "TextVerticalCenterX":
                        this.TextVerticalCenterX = property.Value.ToObject<double>();
                        break;
                    case "TextVerticalCenterY":
                        this.TextVerticalCenterY = property.Value.ToObject<double>();
                        break;
                    case "TextVerticalAngle":
                        this.TextVerticalAngle = property.Value.ToObject<double>();
                        break;
                    case "FontColor":
                        this.FontColor = property.Value.ToObject<string>();
                        break;
                    case "FontFamily":
                        this.FontFamily = property.Value.ToObject<string>();
                        break;
                    case "TextScaleCenterX":
                        this.TextScaleCenterX = property.Value.ToObject<double>();
                        break;
                    case "TextScaleCenterY":
                        this.TextScaleCenterY = property.Value.ToObject<double>();
                        break;
                    case "TextScaleX":
                        this.TextScaleX = property.Value.ToObject<double>();
                        break;
                    case "TextScaleY":
                        this.TextScaleY = property.Value.ToObject<double>();
                        break;
                }

                jtoken = jtoken.Next;
            }
        }


        public string Text { get; set; }

        public double TextLeft { get; set; }

        public double TextTop { get; set; }

        public bool TextIsVertical { get; set; }
        public double TextVerticalCenterX { get; set; }
        public double TextVerticalCenterY { get; set; }
        public double TextVerticalAngle { get; set; }

        public string FontColor { get; set; }
        public string FontFamily { get; set; }



        public double TextScaleCenterX { get; set; }
        public double TextScaleCenterY { get; set; }
        public double TextScaleX { get; set; }
        public double TextScaleY { get; set; }



    }


    public class ROSHotSpot
    {

        public ROSHotSpot()
        {
        }


        //public ROSHotSpot(JObject item)
        //    {
        //        JToken jtoken = item.First;

        //        while (jtoken != null)//loop through columns
        //        {
        //            JProperty property = (JProperty)jtoken;

        //            switch (property.Name)
        //            {
        //                case "SeatNO":
        //                    this.SeatNO = property.Value.ToObject<string>();
        //                    break;
        //                case "ImageWidth":
        //                    this.ImageWidth = property.Value.ToObject<double>();
        //                    break;
        //                case "ImageHeight":
        //                    this.ImageHeight = property.Value.ToObject<double>();
        //                    break;
        //                case "HotSpotPoints":
        //                    JArray items = (JArray)item["HotSpotPoints"];
        //                    this.HotSpotPoints = fromJArray(items);
        //                    break;
        //                case "TextInfo":
        //                    JObject jObject = property.Value.ToObject<JObject>();
        //                    this.TextInfo = new HotSpotText(jObject);
        //                    break;
        //                case "ToolTip":
        //                    this.ToolTip = property.Value.ToObject<string>();
        //                    break;
        //            }

        //            jtoken = jtoken.Next;
        //        }
        //    }

        //private List<Point> fromJArray(JArray items)
        //{
        //    List<Point> points = new List<Point>();
        //    for (int i = 0; i < items.Count; i++) //loop through rows
        //    {
        //        JObject item = (JObject)items[i];
        //        JToken jtoken = item.First;

        //        Point point = new Point();

        //        while (jtoken != null)//loop through columns
        //        {
        //            JProperty property = (JProperty)jtoken;
        //            switch (property.Name)
        //            {
        //                case "X":
        //                    point.X = property.Value.ToObject<double>();
        //                    break;
        //                case "Y":
        //                    point.Y = property.Value.ToObject<double>();
        //                    break;
        //            }

        //            jtoken = jtoken.Next;
        //        }

        //        points.Add(point);
        //    }
        //    return points;
        //}


        public string SeatNO { get; set; }

        public List<Point> HotSpotPoints { get; set; }

        public double ImageWidth { get; set; }

        public double ImageHeight { get; set; }

        public HotSpotText TextInfo { get; set; }

        public string ToolTip { get; set; }

    }



    public class BrandData
    {
        public BrandData()
        {
        }
        public string Name { get; set; }
        public string FillColor { get; set; }
        public string FontColor { get; set; }
        public string BorderColor { get; set; }
        public string FillOverColor { get; set; }




        public static List<BrandData> GetAllBrandInfos()
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
            brandInfos.Add(new BrandData() { Name = "Samsung", FillColor = "#002060", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
            brandInfos.Add(new BrandData() { Name = "ASUS", FillColor = "#006666", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
            brandInfos.Add(new BrandData() { Name = "Getway", FillColor = "#6F6041", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
            brandInfos.Add(new BrandData() { Name = "Brands", FillColor = "#626041", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
            brandInfos.Add(new BrandData() { Name = "Others", FillColor = "#686041", BorderColor = Color.Black.ToString(), FontColor = Color.White.ToString(), FillOverColor = Color.Orange.ToString() });
            return brandInfos;


        }


    }


    public class RosShopInfo
    {
        public RosShopInfo()
        {
        }
        public string SeatNO { get; set; }

        public string ShopName { get; set; }

        public string ShopBrandInfo { get; set; }

        public int CompleteNumber { get; set; }

        public ROSHotSpot HotSpotInfo { get; set; }
    }



 
    public class ShopMallFloorHotspotData
    {
        public ShopMallFloorHotspotData()
        {
        }
        public string ShopMallNo { get; set; }
        public string ShopMallFloorNo { get; set; }
        public List<RosShopInfo> ShopInfos { get; set; }
        public string ImageUrl { get; set; }
        public List<BrandData> Brands { get; set; }
        //public string ImageWith { get; set; }
        //public string ImageHeight { get; set; }
    }
}