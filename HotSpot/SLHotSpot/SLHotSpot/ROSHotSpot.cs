using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLHotSpot.HotSpotService;
using Point = System.Windows.Point;

namespace SLHotSpot
{
    public class ROSHotSpot
    {
        public ROSHotSpot()
        {
        }


        public ROSHotSpot(HotSpotService.ROSHotSpot item)
        {
            //JToken jtoken = item.First;

            //this.ShopNO = item["ShopNO"].ToObject<string>();

            //while (jtoken != null)//loop through columns
            //{
            //    JProperty property = (JProperty)jtoken;

            //    switch (property.Name)
            //    {
                    //case "ShopNO":
                    this.ShopNO = item.SeatNO;
                    //    break;
                    //case "ImageWidth":
                    //this.ImageWidth = item.ImageWidth;
                    //    break;
                    //case "ImageHeight":
                    //this.ImageHeight = item.ImageHeight;
                    //    break;
                    //case "HotSpotPoints":
                    //    JArray items = (JArray)item["HotSpotPoints"];
                    this.HotSpotPoints = fromArray(item.HotSpotPoints);
                    //    break;
                    //case "TextInfo":
                        //JObject jObject = property.Value.ToObject<JObject>();
                    this.TextInfo = new HotSpotText(item.TextInfo);
                    //    break;
                    //case "ToolTip":
                    this.ToolTip = item.ToolTip;
            //            break;
            //    }

            //    jtoken = jtoken.Next;
            //}
        }

        public static List<ROSHotSpot> ReadfromString(string dataString)
        {
            JArray array = JArray.Parse(dataString);

            List<ROSHotSpot> rosHotSpots = new List<ROSHotSpot>();

            for (int i = 0; i < array.Count; i++) //loop through rows
            {
                rosHotSpots.Add(new ROSHotSpot(JObject.Parse(array[i].ToString())));

            }
            return rosHotSpots;
        }


        public ROSHotSpot(JObject item)
        {
            JToken jtoken = item.First;

            this.ShopNO = item["SeatNO"].ToObject<string>();

            while (jtoken != null)//loop through columns
            {
                JProperty property = (JProperty)jtoken;

                switch (property.Name)
                {
                    case "SeatNO":
                        this.ShopNO = item["SeatNO"].ToObject<string>();
                        break;
                    //case "ImageWidth":
                    //    this.ImageWidth = item.ImageWidth;
                    //    break;
                    //case "ImageHeight":
                    //    this.ImageHeight = item.ImageHeight;
                        break;
                    case "HotSpotPoints":
                        JArray items = (JArray)item["HotSpotPoints"];
                        this.HotSpotPoints = fromJArray(items);
                        break;
                    case "TextInfo":
                        JObject jObject = property.Value.ToObject<JObject>();
                        this.TextInfo = new HotSpotText(JObject.Parse(item["TextInfo"].ToString()));
                        break;
                    case "ToolTip":
                        this.ToolTip = item["ToolTip"].ToObject<string>();
                        break;
                }

                jtoken = jtoken.Next;
            }
        }

        private List<Point> fromJArray(JArray items)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                JObject item = (JObject)items[i];
                JToken jtoken = item.First;

                Point point = new Point();

                //point.X = items[i].X;

                //point.Y = items[i].Y;

                while (jtoken != null)//loop through columns
                {
                    JProperty property = (JProperty)jtoken;
                    switch (property.Name)
                    {
                        case "X":
                            point.X = property.Value.ToObject<double>();
                            break;
                        case "Y":
                            point.Y = property.Value.ToObject<double>();
                            break;
                    }

                    jtoken = jtoken.Next;
                }

                points.Add(point);
            }
            return points;
        }

        private List<Point> fromArray(ObservableCollection<HotSpotService.Point> items)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                //JObject item = (JObject)items[i];
                //JToken jtoken = item.First;

                Point point = new Point();

                point.X = items[i].X;

                point.Y = items[i].Y;

                //while (jtoken != null)//loop through columns
                //{
                //    JProperty property = (JProperty)jtoken;
                //    switch (property.Name)
                //    {
                //        case "X":
                //            point.X = property.Value.ToObject<double>();
                //            break;
                //        case "Y":
                //            point.Y = property.Value.ToObject<double>();
                //            break;
                //    }

                //    jtoken = jtoken.Next;
                //}

                points.Add(point);
            }
            return points;
        }

        public string ShopNO { get; set; }

        public List<Point> HotSpotPoints { get; set; }

        public double ImageWidth { get; set; }

        public double ImageHeight { get; set; }

        public HotSpotText TextInfo { get; set; }

        public string ToolTip { get; set; }

        public static string HotSpotsToJson(ObservableCollection<ShopHotSpot> hotSpots, double imageWidth, double imageHeight)
        {
            List<ROSHotSpot> rosHotSpots = new List<ROSHotSpot>();

            foreach (ShopHotSpot shopHot in hotSpots)
            {
                //shopHot.UpdateInfo();

                ROSHotSpot rosHot = new ROSHotSpot();

                rosHot.ShopNO = shopHot.DataID.ToString();
                rosHot.HotSpotPoints = new List<Point>(shopHot.ShowPolygon.Points);
                rosHot.ImageWidth = imageWidth;
                rosHot.ImageHeight = imageHeight;
                rosHot.TextInfo = new HotSpotText(shopHot.ShowTextBlock);
                rosHot.ToolTip = shopHot.Comment;

                rosHotSpots.Add(rosHot);
            }

            return "{\"total\":" + rosHotSpots.Count.ToString() + ",\"rows\":" + JsonConvert.SerializeObject(rosHotSpots) + "}";
 
        }


        public static ObservableCollection<HotSpotService.ROSHotSpot> HotSpotsToList(ObservableCollection<ShopHotSpot> hotSpots, double imageWidth, double imageHeight)
        {
            ObservableCollection<HotSpotService.ROSHotSpot> rosHotSpots = new ObservableCollection<HotSpotService.ROSHotSpot>();

            foreach (ShopHotSpot shopHot in hotSpots)
            {
                ROSHotSpot rosHot = new ROSHotSpot();

                rosHot.ShopNO = shopHot.DataID.ToString();
                rosHot.HotSpotPoints = new List<Point>(shopHot.ShowPolygon.Points);
                rosHot.ImageWidth = imageWidth;
                rosHot.ImageHeight = imageHeight;
                rosHot.TextInfo = new HotSpotText(shopHot.ShowTextBlock);
                rosHot.ToolTip = shopHot.Comment;

                rosHotSpots.Add(rosHot.ToWebROSHotSpot());
            }

            return rosHotSpots;

        }

        private HotSpotService.ROSHotSpot ToWebROSHotSpot()
        {
            HotSpotService.ROSHotSpot rosHot = new HotSpotService.ROSHotSpot();

            rosHot.SeatNO = this.ShopNO;
            rosHot.HotSpotPoints = new ObservableCollection<HotSpotService.Point>();

            foreach (Point hotSpotPoint in HotSpotPoints)
            {
                HotSpotService.Point point = new HotSpotService.Point();
                point.X = hotSpotPoint.X;
                point.Y = hotSpotPoint.Y;
                rosHot.HotSpotPoints.Add(point);
            }
 
            rosHot.TextInfo = new HotSpotService.HotSpotText();

            rosHot.TextInfo.Text = this.TextInfo.Text;

            rosHot.TextInfo.TextLeft = this.TextInfo.TextLeft;

            rosHot.TextInfo.TextTop = this.TextInfo.TextTop;

            rosHot.TextInfo.TextIsVertical = this.TextInfo.TextIsVertical;

            rosHot.TextInfo.TextVerticalCenterX = this.TextInfo.TextScaleCenterX;

            rosHot.TextInfo.TextVerticalCenterY = this.TextInfo.TextScaleCenterY;

            rosHot.TextInfo.TextVerticalAngle = this.TextInfo.TextVerticalAngle;

            rosHot.TextInfo.FontColor = this.TextInfo.FontColor;

            rosHot.TextInfo.FontFamily = this.TextInfo.FontFamily;

            rosHot.TextInfo.TextScaleCenterX = this.TextInfo.TextScaleCenterX;

            rosHot.TextInfo.TextScaleCenterY = this.TextInfo.TextScaleCenterY;

            rosHot.TextInfo.TextScaleX = this.TextInfo.TextScaleX;

            rosHot.TextInfo.TextScaleY = this.TextInfo.TextScaleY;

            return rosHot;

        }

        //private Polygon ployon; 

        //public void AddToCanvas(ROSHotSpot rosHotSpot, Canvas canvas)
        //{
        //    ployon = new Polygon();

        //    foreach (Point hotSpotPoint in HotSpotPoints)
        //    {
        //        ployon.Points.Add(hotSpotPoint);    
        //    }

        //    ployon.Stroke = new SolidColorBrush(rosHotSpot.GetBrandInfo().BorderColor);
        //    ployon.StrokeThickness = 1;
        //    ployon.Fill = new SolidColorBrush(rosHotSpot.GetBrandInfo().FillColor);

        //    ployon.MouseEnter += new MouseEventHandler(polygon_OnMouseEnter);
        //    ployon.MouseLeave += new MouseEventHandler(polygon_OnMouseLeave);

        //    TextBlock textBlock = new TextBlock();
        //    //textBlock.Foreground =  new SolidColorBrush(rosHotSpot.GetBrandInfo().FontColor);
        //    textBlock.FontFamily = new FontFamily("Arial");
        //    textBlock.Foreground = new SolidColorBrush(Colors.Cyan);
        //    textBlock.Inlines.Add(TextInfo.Text);
        //    Canvas.SetLeft(textBlock, TextInfo.TextLeft);
        //    Canvas.SetTop(textBlock, TextInfo.TextTop);

        //    TransformGroup transformGroup = new TransformGroup();

        //    ScaleTransform scaleTransform = new ScaleTransform();

        //    scaleTransform.CenterX = TextInfo.TextScaleCenterX;
        //    scaleTransform.CenterY = TextInfo.TextScaleCenterY;
        //    scaleTransform.ScaleX = TextInfo.TextScaleX;
        //    scaleTransform.ScaleY = TextInfo.TextScaleY;

        //    transformGroup.Children.Add(scaleTransform);

        //    if (TextInfo.TextIsVertical)
        //    {
        //        RotateTransform rotateTransform = new RotateTransform();

        //        rotateTransform.CenterX = TextInfo.TextVerticalCenterX;
        //        rotateTransform.CenterY = TextInfo.TextVerticalCenterY;
        //        rotateTransform.Angle = TextInfo.TextVerticalAngle;
        //        transformGroup.Children.Add(rotateTransform);
        //    }

        //    textBlock.RenderTransform = transformGroup;

        //    textBlock.MouseEnter += new MouseEventHandler(textBlock_OnMouseEnter);
            
        //    canvas.Children.Add(ployon);
        //    canvas.Children.Add(textBlock);
 
        //}

        //#region OnMove特效

        //private void polygon_OnMouseEnter(object sender, MouseEventArgs e)
        //{
        //    if (sender != null && sender is Polygon)
        //    {
        //        ((Polygon)sender).Fill = new SolidColorBrush(this.GetBrandInfo().FillOverColor);
        //    }
        //}

        //private void polygon_OnMouseLeave(object sender, MouseEventArgs e)
        //{
        //    if (sender != null && sender is Polygon)
        //    {
        //        ((Polygon)sender).Fill = new SolidColorBrush(this.GetBrandInfo().FillColor);
        //    }
        //}

        //private void textBlock_OnMouseEnter(object sender, MouseEventArgs e)
        //{
        //    if (sender != null && sender is TextBlock)
        //    {
        //        ployon.Fill = new SolidColorBrush(this.GetBrandInfo().FillOverColor);
        //    }
        //}

        //#endregion

        public BrandInfo GetBrandInfo()
        {
            return ShopInfo.GetBySeatNo(ShopNO).GetBrandInfo();
        }

        public static List<ROSHotSpot> GetFromShopMallFloorHotspotData(ShopMallFloorHotspotData shopMallFloorData)
        {
            List<ROSHotSpot> spots = new List<ROSHotSpot>();
            for (int i = 0; i < shopMallFloorData.ShopInfos.Count; i++)
            {
                if (shopMallFloorData.ShopInfos[i].HotSpotInfo!=null)
                {
                    ROSHotSpot rosHot = new ROSHotSpot(shopMallFloorData.ShopInfos[i].HotSpotInfo);
                    spots.Add(rosHot);
                }
            }
            return spots;
        }
    }
}
