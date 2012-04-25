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

namespace SLHotSpot
{
    public class ROSHotSpot
    {
        public ROSHotSpot()
        {
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
                rosHot.ToolTip = shopHot.GetToolTip();

                rosHotSpots.Add(rosHot);
            }
 
            return JsonConvert.SerializeObject(rosHotSpots);
        }

        private Polygon ployon; 

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

        #region OnMove特效

        private void polygon_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != null && sender is Polygon)
            {
                ((Polygon)sender).Fill = new SolidColorBrush(this.GetBrandInfo().FillOverColor);
            }
        }

        private void polygon_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender != null && sender is Polygon)
            {
                ((Polygon)sender).Fill = new SolidColorBrush(this.GetBrandInfo().FillColor);
            }
        }

        private void textBlock_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != null && sender is TextBlock)
            {
                ployon.Fill = new SolidColorBrush(this.GetBrandInfo().FillOverColor);
            }
        }

        #endregion

        public BrandInfo GetBrandInfo()
        {
            return ShopInfo.GetByShopNo(ShopNO).GetBrandInfo();
        }
    }
}
