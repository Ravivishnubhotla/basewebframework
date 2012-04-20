using System;
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
    public class HotSpotText
    {
        public HotSpotText()
        {
        }

        public HotSpotText(TextBlock showTextBlock)
        {
            TextLeft = Canvas.GetLeft(showTextBlock);
            TextTop = Canvas.GetTop(showTextBlock);

            Text = showTextBlock.Text;

            if(showTextBlock.RenderTransform is TransformGroup)
            {
                TransformGroup transformGroup = showTextBlock.RenderTransform as TransformGroup;

                if(transformGroup!=null)
                {
                    foreach (Transform transform in transformGroup.Children)
                    {
                        if (transform is ScaleTransform)
                        {
                            TextScaleCenterX = ((ScaleTransform)transform).CenterX;
                            TextScaleCenterY = ((ScaleTransform)transform).CenterY;
                            TextScaleX = ((ScaleTransform)transform).ScaleX;
                            TextScaleY = ((ScaleTransform)transform).ScaleY;
                        }
                        if (transform is RotateTransform)
                        {
                            TextIsVertical = true;
                            TextVerticalCenterX = ((RotateTransform)transform).CenterX;
                            TextVerticalCenterY = ((RotateTransform)transform).CenterY;
                            TextVerticalAngle = ((RotateTransform)transform).Angle;
                        }
                    }
                }

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
}
