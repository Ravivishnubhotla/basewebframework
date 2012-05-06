using System;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLHotSpot
{
    [ScriptableType]
    public class ShopHotSpot : HostSpot
    {
 
        public ShopHotSpot(Guid id, string brand)
            : base(id)
        {
            this.Brand = brand;
        }

        private string _brand;

        public ShopHotSpot(ROSHotSpot rosHotSpot, Canvas canvas,Mode mode,MainPage mainPage)
            : base(Guid.NewGuid())
        {
            this.DataID = rosHotSpot.ShopNO;
            this.Brand = rosHotSpot.GetBrandInfo().Name;
            this.Name = rosHotSpot.TextInfo.Text;
            this.IsRotate = rosHotSpot.TextInfo.TextIsVertical;

            showPolygon = new Polygon();

            foreach (Point hotSpotPoint in rosHotSpot.HotSpotPoints)
            {
                showPolygon.Points.Add(hotSpotPoint);
                HostSpotArea.Add(hotSpotPoint);
            }

            showPolygon.Stroke = new SolidColorBrush(rosHotSpot.GetBrandInfo().BorderColor);
            showPolygon.StrokeThickness = 1;
            showPolygon.Fill = new SolidColorBrush(rosHotSpot.GetBrandInfo().FillColor);

            showPolygon.MouseEnter += new MouseEventHandler(polygon_OnMouseEnter);
            showPolygon.MouseLeave += new MouseEventHandler(polygon_OnMouseLeave);

            showTextBlock = new TextBlock();

            showTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            showTextBlock.VerticalAlignment = VerticalAlignment.Center;
            showTextBlock.TextAlignment = TextAlignment.Left;
            showTextBlock.TextWrapping = TextWrapping.Wrap;

            //textBlock.Foreground =  new SolidColorBrush(rosHotSpot.GetBrandInfo().FontColor);
            showTextBlock.FontFamily = new FontFamily("Arial");
            showTextBlock.Foreground = new SolidColorBrush(ColorFromString.ToColor("#AAFCFA"));
            showTextBlock.Inlines.Add(rosHotSpot.TextInfo.Text);
            Canvas.SetLeft(showTextBlock, rosHotSpot.TextInfo.TextLeft);
            Canvas.SetTop(showTextBlock, rosHotSpot.TextInfo.TextTop);

            TransformGroup transformGroup = new TransformGroup();

            ScaleTransform scaleTransform = new ScaleTransform();

            scaleTransform.CenterX = rosHotSpot.TextInfo.TextScaleCenterX;
            scaleTransform.CenterY = rosHotSpot.TextInfo.TextScaleCenterY;
            scaleTransform.ScaleX = rosHotSpot.TextInfo.TextScaleX;
            scaleTransform.ScaleY = rosHotSpot.TextInfo.TextScaleY;

            transformGroup.Children.Add(scaleTransform);

            if (rosHotSpot.TextInfo.TextIsVertical)
            {
                RotateTransform rotateTransform = new RotateTransform();

                rotateTransform.CenterX = rosHotSpot.TextInfo.TextVerticalCenterX;
                rotateTransform.CenterY = rosHotSpot.TextInfo.TextVerticalCenterY;
                rotateTransform.Angle = rosHotSpot.TextInfo.TextVerticalAngle;
                transformGroup.Children.Add(rotateTransform);
            }

            showTextBlock.RenderTransform = transformGroup;

            showTextBlock.MouseEnter += new MouseEventHandler(textBlock_OnMouseEnter);

            showPolygon.Tag = this;
            showTextBlock.Tag = this;


            AddContextMenu(showTextBlock, mode, mainPage);
            AddContextMenu(showPolygon, mode, mainPage);


            ToolTipService.SetToolTip(showPolygon, this.Comment);
            ToolTipService.SetToolTip(ShowTextBlock, this.Comment);

            canvas.Children.Add(showPolygon);
            canvas.Children.Add(showTextBlock);


        }

        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {

                _brand = value;
                BrandInfo brandInfo = BrandInfo.GetBrandInfo(_brand);

                if (brandInfo != null)
                {
                    this.FillColor = brandInfo.FillColor;
                    this.FillColorOpacity = 1;
                    this.FillOverColor = brandInfo.FillOverColor;
                    this.FontColor = brandInfo.FontColor;
                    this.FontFamily = new FontFamily("Arial");
                    this.BorderColor = brandInfo.BorderColor;
                    this.BorderThickness = 2;
                }

                NotifyPropertyChanged("Brand");
            }

        }

  


        public void UpdateInfo()
        {
            if (!string.IsNullOrEmpty(this.DataID))
            {
                ShopInfo shopInfo = ShopInfo.GetBySeatNo(this.DataID);

                this.Name = shopInfo.ShowText;

                this.Comment = shopInfo.ShowTooltip;

                this.Brand = shopInfo.ShopBrandInfo;

            }
        }

        public void UpdateText()
        {
            if (!string.IsNullOrEmpty(this.DataID))
            {
                ShopInfo shopInfo = ShopInfo.GetBySeatNo(this.DataID);

                this.Name = shopInfo.ShopBrandInfo;

                this.Comment = shopInfo.ShowTooltip; ;

            }
        }

 


    }
}
