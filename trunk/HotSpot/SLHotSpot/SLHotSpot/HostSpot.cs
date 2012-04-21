using System;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace SLHotSpot
{
    public class HostSpot : INotifyPropertyChanged
    {
        #region 常量

        private const double GoldenSectionRate = 0.6180339887d;

        #endregion

        #region INotifyPropertyChanged 接口实现

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region 实例变量

        private string name;
        protected Polygon showPolygon;
        protected TextBlock showTextBlock;

        #endregion

        #region 属性

        public Guid ID { get; set; }

        public string DataID { get; set; }

        public string Comment { get; set; }

        #region 热点多边形

        public Color FillColor { get; set; }
        public Color FillOverColor { get; set; }
        public double FillColorOpacity { get; set; }
        public Color BorderColor { get; set; }
        public int BorderThickness { get; set; }

        public List<Point> HostSpotArea { get; set; }
        public List<Rectangle> HostSpotAreaPoints { get; set; }

        private DragMover dragMover;

        public Polygon ShowPolygon
        {
            get
            {
                if (showPolygon == null)
                {
                    showPolygon = GetPolygon();
                }
                return showPolygon;
            }
        }

        public bool DrawingHotSpot { get; set; }

        #endregion

        #region 文字显示

        public TextBlock ShowTextBlock
        {
            get
            {
                if (showTextBlock == null)
                {
                    showTextBlock = GetTextBlock(ShowPolygon);
                }
                return showTextBlock;
            }
        }


        public bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {

                isSelected = value;



                NotifyPropertyChanged("IsSelected");


                if (isSelected)
                    this.ShowPolygon.Fill = new SolidColorBrush(this.FillOverColor);
                else
                    this.ShowPolygon.Fill = new SolidColorBrush(this.FillColor);

            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public bool IsRotate { get; set; }
        public Color FontColor { get; set; }
        public FontFamily FontFamily { get; set; }
        public bool ChangingText { get; set; }
        public List<Point> TextArea { get; set; }
        public List<Rectangle> TextPoints { get; set; }

        #endregion

        public Canvas ParentCanvas
        {
            get
            {
                return (Canvas)showPolygon.Parent;
            }
        }

        #endregion

        #region 绘制热点区域

        private void casDrawPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DrawingHotSpot)
            {
                Canvas canvas = sender as Canvas;

                Point clickPoint = e.GetPosition(canvas);

                HostSpotArea.Add(clickPoint);

                Rectangle rPoint = this.AddHostSpotAreaPoint(clickPoint);

                canvas.Children.Add(rPoint);
            }
        }

        public void BeginDraw(Canvas casDrawPanel)
        {
            if (!this.DrawingHotSpot)
            {
                this.DrawingHotSpot = true;
                casDrawPanel.MouseLeftButtonDown += casDrawPanel_OnMouseLeftButtonDown;
            }
        }

        public bool EndDraw(Canvas casDrawPanel)
        {
            if (this.DrawingHotSpot)
            {
                if (this.HostSpotAreaPoints.Count < 3)
                {
                    return false;
                }
                casDrawPanel.MouseLeftButtonDown -= casDrawPanel_OnMouseLeftButtonDown;
                return true;
            }
            return false;
        }

        #endregion

        Point? lastTextDragPoint;

        public void StartChangeText()
        {
            //TextArea = new List<Point>();
            //TextPoints = new List<Rectangle>();
            //if (showPolygon != null)
            //{
            //    showPolygon.MouseLeftButtonDown += new MouseButtonEventHandler(showPolygonOnMouseLeftButtonDowns);
            //}
            ChangingText = true;

            if(dragMover == null)
            {
                dragMover = new DragMover(showTextBlock);
            }

            dragMover.EnableTracking();

        }

        public void LargeText(double rate)
        {
            if (ShowTextBlock.RenderTransform != null && ShowTextBlock.RenderTransform is TransformGroup)
            {
                foreach (Transform transform in ((TransformGroup)ShowTextBlock.RenderTransform).Children)
                {
                    if (transform is ScaleTransform)
                    {
                        ((ScaleTransform)transform).ScaleX += rate;
                        ((ScaleTransform)transform).ScaleY += rate;
                    }
                }
            }
        }
        public void SmallText(double rate)
        {
            if (ShowTextBlock.RenderTransform != null && ShowTextBlock.RenderTransform is TransformGroup)
            {
                foreach (Transform transform in ((TransformGroup)ShowTextBlock.RenderTransform).Children)
                {
                    if (((ScaleTransform)transform).ScaleX > rate)
                    {
                        ((ScaleTransform)transform).ScaleX -= rate;
                        ((ScaleTransform)transform).ScaleY -= rate;
                    }
                }
            }
        }

        //    if(e.Key == Key.Up && e.Key == Key.Down)
        //    {
        //        if (moveFramework.RenderTransform != null && moveFramework.RenderTransform is TransformGroup)
        //        {
        //            foreach (Transform transform in ((TransformGroup)moveFramework.RenderTransform).Children)
        //            {
        //                if(transform is ScaleTransform)
        //                {
        //                    if (e.Key == Key.Up)
        //                    {
        //                        ((ScaleTransform)transform).ScaleX += 0.2;
        //                        ((ScaleTransform)transform).ScaleX += 0.2;
        //                    }

        //                    if (((ScaleTransform)transform).ScaleX>0.2 && e.Key == Key.Down)
        //                    {
        //                        ((ScaleTransform)transform).ScaleX -= 0.2;
        //                        ((ScaleTransform)transform).ScaleX -= 0.2;
        //                    }


        //                }
        //            }
        //        }
        //    }

        public bool EndChangeText()
        {
            //if (TextArea.Count != 4)
            //{
            //    MessageBox.Show("必须设置四个点！");
            //    return false;
            //}

            //double cx = 0d;
            //double cy = 0d;

            //foreach (Point point in TextArea)
            //{
            //    cx += point.X;
            //    cy += point.Y;
            //}

            //cx = cx / Convert.ToDouble(TextArea.Count);
            //cy = cy / Convert.ToDouble(TextArea.Count);

            //double textX = Math.Min(Math.Abs(TextArea[1].X - TextArea[0].X), Math.Abs(TextArea[2].X - TextArea[3].X));
            //double textY = Math.Min(Math.Abs(TextArea[3].Y - TextArea[0].Y), Math.Abs(TextArea[2].Y - TextArea[1].Y));

            //double textLeftX = TextArea[0].X;
            //double textLeftY = TextArea[0].Y;


            //TransformGroup transformGroup = showTextBlock.RenderTransform as TransformGroup;

            //double scale = textX / showTextBlock.ActualWidth;

            //double scaleX = showTextBlock.ActualWidth / 2d;
            //double scaleY = showTextBlock.ActualHeight / 2d;

            //if (this.IsRotate)
            //{
            //    scale = textY / showTextBlock.ActualHeight;
            //    scaleX = scaleX;
            //    scaleY = scaleY;
            //}

            //if (transformGroup != null)
            //{
            //    foreach (Transform transform in transformGroup.Children)
            //    {
            //        if (transform is ScaleTransform)
            //        {
            //            ScaleTransform scaleTransform = transform as ScaleTransform;

            //            if (scaleTransform != null)
            //            {
            //                scaleTransform.CenterX = scaleX;
            //                scaleTransform.CenterY = scaleY;
            //                //scaleTransform.ScaleX = textX / showTextBlock.ActualWidth;
            //                //scaleTransform.ScaleY = textY / showTextBlock.ActualHeight;
            //                scaleTransform.ScaleX = scale;
            //                scaleTransform.ScaleY = scale;
            //            }
            //        }
            //    }
            //}

            //Point textpoint = new Point(textLeftX + Canvas.GetLeft(showPolygon), textLeftY + Canvas.GetTop(showPolygon));

            //foreach (Rectangle textPoint in TextPoints)
            //{
            //    ParentCanvas.Children.Remove(textPoint);
            //}

            //TextPoints.Clear();
            //TextArea.Clear();

            //if (showPolygon != null)
            //{
            //    showPolygon.MouseLeftButtonDown -= new MouseButtonEventHandler(showPolygonOnMouseLeftButtonDowns);
            //}


            //Canvas.SetLeft(this.ShowTextBlock, textpoint.X);
            //Canvas.SetTop(this.ShowTextBlock, textpoint.Y);

            ChangingText = false;

            if (dragMover != null)
            {
                dragMover.DisableTracking();
            }

            return true;
        }

        private Rectangle AddChangeTextPoint(Point point)
        {
            TextArea.Add(point);
            Rectangle tRPoint = DrawPoint(point);
            TextPoints.Add(tRPoint);
            return tRPoint;
        }



        private void showPolygonOnMouseLeftButtonDowns(object sender, MouseButtonEventArgs e)
        {
            if (ChangingText)
            {
                Point clickPoint = e.GetPosition((Canvas)showPolygon.Parent);

                Rectangle rPoint = AddChangeTextPoint(clickPoint);

                Canvas.SetZIndex(rPoint, 2000);

                ParentCanvas.Children.Add(rPoint);
            }
        }

        private TextBlock GetTextBlock(Polygon polygon)
        {
            TextBlock textBlock = new TextBlock();

            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.TextWrapping = TextWrapping.Wrap;

            textBlock.Inlines.Add(new Run() { Text = this.Name });

            textBlock.FontFamily = new FontFamily("Arial");
 

            Canvas.SetLeft(textBlock, this.GetCenterLeft() - textBlock.ActualWidth / 2);
            Canvas.SetTop(textBlock, this.GetCenterTop() - textBlock.ActualHeight / 2);
            Canvas.SetLeft(textBlock, Canvas.GetLeft(textBlock));
            Canvas.SetTop(textBlock, Canvas.GetTop(textBlock));
            Canvas.SetZIndex(textBlock, 1100);

            double centerX = textBlock.ActualWidth / 2;
            double centerY = textBlock.ActualHeight / 2;

            TransformGroup transform = new TransformGroup();

            if (this.IsRotate)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.CenterY = centerY;
                rotate.CenterX = centerX;
                rotate.Angle = 90;
                transform.Children.Add(rotate);
            }


            double scaleRate = 1;

            if (polygon.Points.Count == 4)
            {
                double polygonX = Math.Min(Math.Abs(polygon.Points[1].X - polygon.Points[0].X), Math.Abs(polygon.Points[2].X - polygon.Points[3].X));
                double polygonY = Math.Min(Math.Abs(polygon.Points[3].Y - polygon.Points[0].Y), Math.Abs(polygon.Points[2].Y - polygon.Points[1].Y));

                double newpolygonX = polygonX * GoldenSectionRate;
                double newpolygonY = polygonY * GoldenSectionRate;

                double textX = textBlock.ActualWidth;
                double textY = textBlock.ActualHeight;

                if (this.IsRotate)
                {
                    textY = textBlock.ActualWidth;
                    textX = textBlock.ActualHeight;
                }

                if (newpolygonX / textX <= newpolygonY / textY)
                {
                    scaleRate = newpolygonX / textX;
                }
                else
                {
                    scaleRate = newpolygonY / textY;
                }
            }

            ScaleTransform scale = new ScaleTransform();

            scale.CenterX = centerX;
            scale.CenterY = centerY;
            scale.ScaleX = scaleRate;
            scale.ScaleY = scaleRate;

            transform.Children.Add(scale);

            textBlock.RenderTransform = transform;
            textBlock.Tag = this;


            textBlock.MouseEnter += new MouseEventHandler(textBlock_OnMouseEnter);

            if (!string.IsNullOrEmpty(this.Comment))
                ToolTipService.SetToolTip(textBlock, this.Comment);

            return textBlock;
        }

        public void AddHotspot(Canvas canvas,Mode mode,MainPage mainPage)
        {
            Polygon polygon = this.ShowPolygon;

            TextBlock textBlock = this.ShowTextBlock;

            canvas.Children.Add(textBlock);

            canvas.Children.Add(polygon);

            AddContextMenu(polygon, mode, mainPage);

            AddContextMenu(textBlock, mode, mainPage);

            foreach (Rectangle rectangle in this.HostSpotAreaPoints)
            {
                if (canvas.Children.Contains(rectangle))
                    canvas.Children.Remove(rectangle);
            }
        }

        public void UpdateHotspot(Canvas canvas,Mode mode,MainPage mainPage)
        {
            canvas.Children.Remove(this.ShowPolygon);

            canvas.Children.Remove(this.ShowTextBlock);

            this.UpdatePolygon();

            Polygon polygon = this.ShowPolygon;

            this.UpdateTextBlock();

            TextBlock textBlock = this.ShowTextBlock;

            canvas.Children.Add(textBlock);

            canvas.Children.Add(polygon);

            AddContextMenu(polygon, mode, mainPage);

            AddContextMenu(textBlock, mode, mainPage);
        }

        public HostSpot(Guid id)
        {
            ID = id;
            IsRotate = false;
            FillColor = Colors.Orange;
            FillColorOpacity = 1d;
            BorderColor = Colors.Green;
            BorderThickness = 3;
            HostSpotArea = new List<Point>();
            HostSpotAreaPoints = new List<Rectangle>();


        }

        public Rectangle AddHostSpotAreaPoint(Point clickPoint)
        {
            Rectangle rPoint = DrawPoint(clickPoint);
            HostSpotAreaPoints.Add(rPoint);
            return rPoint;
        }

        private Polygon GetPolygon()
        {
            Polygon polygon = new Polygon();

            foreach (Point point in this.HostSpotArea)
            {
                polygon.Points.Add(point);
            }

            polygon.Stroke = new SolidColorBrush(this.BorderColor);
            polygon.StrokeThickness = this.BorderThickness;
            SolidColorBrush fillSolidColorBrush = new SolidColorBrush(this.FillColor);
            fillSolidColorBrush.Opacity = this.FillColorOpacity;
            polygon.Fill = fillSolidColorBrush;
            polygon.Tag = this;

            if (!string.IsNullOrEmpty(this.Comment))
                ToolTipService.SetToolTip(polygon, this.Comment);

            polygon.MouseEnter += new MouseEventHandler(polygon_OnMouseEnter);
            polygon.MouseLeave += new MouseEventHandler(polygon_OnMouseLeave);



            return polygon;
        }

        private Rectangle DrawPoint(Point clickPoint)
        {
            Rectangle rPoint = new Rectangle();
            rPoint.Width = 3;
            rPoint.Height = 3;
            rPoint.RadiusX = 5;
            rPoint.RadiusY = 5;
            rPoint.Fill = new SolidColorBrush(Colors.Black);

            Canvas.SetLeft(rPoint, clickPoint.X - 1);
            Canvas.SetTop(rPoint, clickPoint.Y - 1);
            return rPoint;
        }

        public double GetCenterLeft()
        {
            double centerLeft = 0d;

            foreach (Point point in HostSpotArea)
            {
                centerLeft += point.X;
            }

            return centerLeft / (double)HostSpotArea.Count;
        }

        public double GetCenterTop()
        {
            double centerTop = 0d;

            foreach (Point point in HostSpotArea)
            {
                centerTop += point.Y;
            }

            return centerTop / (double)HostSpotArea.Count;
        }

        public void UpdatePolygon()
        {
            showPolygon = GetPolygon();
        }

        public void UpdateTextBlock()
        {
            showTextBlock = GetTextBlock(ShowPolygon);
        }

        protected void AddContextMenu(UIElement uiElement, Mode mode,MainPage mainPage)
        {
            ContextMenu cmAction = new ContextMenu();

            cmAction.Closed+=new RoutedEventHandler(cmAction_Closed);

            MenuItem mOpenPlan = new MenuItem();
            mOpenPlan.Header = "打开";
            mOpenPlan.Tag = this.DataID;
            mOpenPlan.CommandParameter = "Open";
            mOpenPlan.Click += new RoutedEventHandler(mainPage.cmAction_MenuItem_Click);
            cmAction.Items.Add(mOpenPlan);

            switch (mode)
            {
                    case Mode.View:
                        break;
                    case Mode.Design:
                        MenuItem mEditPlan = new MenuItem();
                        mEditPlan.Header = "编辑";
                        mEditPlan.Tag = this.DataID;
                        mEditPlan.CommandParameter = "Edit";
                        mEditPlan.Click += new RoutedEventHandler(mainPage.cmAction_MenuItem_Click);
                        cmAction.Items.Add(mEditPlan);
                        break;
                    case Mode.Change:
                        MenuItem mChangePlan = new MenuItem();
                        mChangePlan.Header = "更改品牌";
                        mChangePlan.Tag = this.DataID;
                        mChangePlan.CommandParameter = "Change";
                        mChangePlan.Click += new RoutedEventHandler(mainPage.cmAction_MenuItem_Click);
                        cmAction.Items.Add(mChangePlan);
                        break;
            }





            ContextMenuService.SetContextMenu(uiElement, cmAction);
        }

        public void ResetFillColor()
        {
            if (this.showPolygon != null)
            {
                this.showPolygon.Fill = new SolidColorBrush(this.FillColor);
            }
        }

        private void cmAction_Closed(object sender, RoutedEventArgs e)
        {
            ResetFillColor();
        }

        #region OnMove特效

        protected void polygon_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != null && sender is Polygon)
            {
                ((Polygon)sender).Fill = new SolidColorBrush(this.FillOverColor);
            }
        }

        protected void polygon_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender != null && sender is Polygon)
            {
                ((Polygon)sender).Fill = new SolidColorBrush(this.FillColor);
            }
        }

        protected void textBlock_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != null && sender is TextBlock)
            {
                ShowPolygon.Fill = new SolidColorBrush(this.FillOverColor);
            }
        }

        #endregion


    }
}
