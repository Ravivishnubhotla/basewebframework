﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
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

            brandInfos.Add(new BrandData() { Name = "Lenovo", FillColor = "#F28E30", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "HP", FillColor = "#0092D6", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "Dell", FillColor = "#B7295B", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "Acer", FillColor = "#87B81C", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "ThinkPad", FillColor = "#1C2626", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "TOSHIBA", FillColor = "#ED1C24", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "Samsung", FillColor = "#002060", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "SONY", FillColor = "#800080", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "Apple", FillColor = "#C0C0C0", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "ASUS", FillColor = "#006666", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "Getway", FillColor = "#6F6041", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "Others", FillColor = "#00FF00", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "品类店", FillColor = "#FFFF00", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            brandInfos.Add(new BrandData() { Name = "其他店", FillColor = "#FF00FF", BorderColor = "#000000", FontColor = "#8BFCFB", FillOverColor = "#FFA500" });
            
            return brandInfos;


        }


    }

    public class RosShopInfo : IComparable  
    {
        public RosShopInfo()
        {
        }


        public RosShopInfo(DataRow dr, string shopType)
        {
            this.SeatNO = dr["SeatNo"].ToString();
            this.ShopName = dr["ResellerName"].ToString();
            this.UserArea = dr["UseArea"].ToString();
            this.BrandArea = dr["BrandArea"].ToString();
            this.PlaceLevel = dr["PlaceLev"].ToString();

            DataTable dt = dr.Table;

            DataRow[] drs = dt.Select(string.Format(" SeatNo = '{0}' ", this.SeatNO));

 
            string shopNo = "";

            string brandName = "";

            foreach (DataRow sdr in drs)
            {
                brandName +=  sdr["Brand"].ToString() + ",";
                if(string.IsNullOrEmpty(shopNo) && sdr["ShopNo"] != System.DBNull.Value)
                {
                    shopNo = sdr["ShopNo"].ToString();
                }
            }

            this.ShopNo = shopNo;
 
            switch (shopType)
            {
                case "品类":
                    this.ShopBrandInfo = "品类店";
                    this.BrandsName = brandName;
                    break;
                case "品牌":
                    this.ShopBrandInfo = dr["Brand"].ToString();
                    this.BrandsName = dr["Brand"].ToString();
                    break;
                case "其他":
                    this.ShopBrandInfo = "其他店";
                    this.BrandsName = brandName;
                    break;
            }
 
            this.CompleteNumber = 0;
        }

        public string SeatNO { get; set; }

        public string ShopNo { get; set; }
        
        public string ShopBrandInfo { get; set; }

        public string PlaceLevel { get; set; }

        public string ShopName { get; set; }

        public int CompleteNumber { get; set; }

        public string UserArea { get; set; }

        public string BrandArea { get; set; }

        public string BrandsName { get; set; }
        
        public ROSHotSpot HotSpotInfo { get; set; }

        public int CompareTo(object obj)
        {
            RosShopInfo shopInfo = (RosShopInfo)obj;
            return String.Compare(this.SeatNO, shopInfo.SeatNO);
        }
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

    public class BrandCompetitionScore
    {
        public string BrandName { get; set; }
        public double CompetitionScore { get; set; }
    }

    public class BrandCompetitionScoreResult
    {
        public string BrandName { get; set; }
        public double OldCompetitionScore { get; set; }
        public double NewCompetitionScore { get; set; }
    }

    public class ShopBrandInfo
    {
        public string SeatNo { get; set; }
        public string BrandName { get; set; }
    }
}