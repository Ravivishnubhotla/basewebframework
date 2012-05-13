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

namespace SL.Drawing
{
    public class DrawPolygonItem : DrawItem
    {

        public DrawPolygonItem()
        {
            NormalStyle = DrawItemStyle.DefaultNormalStyle;
        }


        public List<DrawPoint> PolygonPoints { get; set; }

        //绘点辅助线
        protected Polyline Assistline { get; set; }
        private Polygon showPolygon;

        public void BeginDrawOnCanvas(Canvas casDrawPanel)
        {
            CreateNewPolyline();
            this.InDrawing = true;
            DrawCanvas = casDrawPanel;
            casDrawPanel.Children.Add(Assistline);
            casDrawPanel.MouseLeftButtonDown += new MouseButtonEventHandler(casDrawPanel_OnMouseLeftButtonDown); 
        }

        private void CreateNewPolyline()
        {
            Assistline = new Polyline();
            Assistline.Stroke = new SolidColorBrush(Colors.Black);
            Assistline.StrokeThickness = 3;
            Canvas.SetZIndex(Assistline, DrawItem.AssistlineZindex);
        }

        private void casDrawPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InDrawing)
            {
                Canvas canvas = sender as Canvas;

                Point clickPoint = e.GetPosition(canvas);

                if (Assistline.Points.Count==0)
                {
                    Assistline.Points.Add(clickPoint);
                    Point npoint = new Point();
                    npoint.X = clickPoint.X + 3;
                    npoint.Y = clickPoint.Y;
                    Assistline.Points.Add(npoint);
                }
                else
                {
                    Assistline.Points.Add(clickPoint);
                }
            }
        }




        public void CancelDrawOnCanvas(Canvas casDrawPanel)
        {
            if (this.InDrawing)
            {
                Assistline.Points.Clear();
                casDrawPanel.Children.Remove(Assistline);
                casDrawPanel.MouseLeftButtonDown -= new MouseButtonEventHandler(casDrawPanel_OnMouseLeftButtonDown);
                InDrawing = false;
            }
        }

        public bool CanEndDrawOnCanvas(out string errorMessage)
        {
            errorMessage = "";
            if (!(this.Assistline.Points.Count > 3))
            {
                errorMessage = "请至少描绘3个点";
                return false;
            }
            return true;
        }

        public void EndDrawOnCanvas(Canvas casDrawPanel)
        {
            if (InDrawing)
            {
                CreateNewPolygon();
                showPolygon = CreateNewPolygon();
                SetStyleToPolygon(showPolygon,this.NormalStyle);
                int i = 0;
                foreach (Point point in Assistline.Points)
                {
                    if(i==1)
                    {
                        i++;
                        continue;
                    }

                    showPolygon.Points.Add(point);

                    i++;
                }
                casDrawPanel.Children.Add(showPolygon);
                Assistline.Points.Clear();
                casDrawPanel.Children.Remove(Assistline);
                casDrawPanel.MouseLeftButtonDown -= new MouseButtonEventHandler(casDrawPanel_OnMouseLeftButtonDown);
                InDrawing = false;
            }
        }

        private Polygon CreateNewPolygon()
        {
            Polygon polygon = new Polygon();
            polygon.Stroke = new SolidColorBrush(ColorConvertor.ToColor(DrawItemStyle.DefaultNormalStyle.BorderColor));
            polygon.StrokeThickness = DrawItemStyle.DefaultNormalStyle.BorderThickness;
            SolidColorBrush fillSolidColorBrush = new SolidColorBrush(ColorConvertor.ToColor(DrawItemStyle.DefaultNormalStyle.FillColor));
            fillSolidColorBrush.Opacity = DrawItemStyle.DefaultNormalStyle.FillColorOpacity;
            polygon.Fill = fillSolidColorBrush;
            Canvas.SetZIndex(Assistline, DrawItem.ShowShapeZindex);
            return polygon;
        }

        private void SetStyleToPolygon(Polygon polygon, DrawItemStyle style)
        {

        }

        public void CancelAllSetPoint()
        {
            if (Assistline.Points.Count > 0)
            {
                Assistline.Points.Clear();
            }
        }

        public void CancelLastSetPoint()
        {
            if(Assistline.Points.Count>0)
            {
                if(Assistline.Points.Count==2)
                {
                    Assistline.Points.Clear();
                }
                else
                {
                    Assistline.Points.RemoveAt(Assistline.Points.Count-1);
                }
            }
        }
    }
}
