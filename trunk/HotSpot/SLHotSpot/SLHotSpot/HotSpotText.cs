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
using Newtonsoft.Json.Linq;

namespace SLHotSpot
{
    public class HotSpotText
    {
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

        public HotSpotText(HotSpotService.HotSpotText showTextBlock)
        {

            this.Text = showTextBlock.Text;

            this.TextLeft = showTextBlock.TextLeft;

            this.TextTop = showTextBlock.TextTop;

            this.TextIsVertical = showTextBlock.TextIsVertical;

            this.TextVerticalCenterX = showTextBlock.TextScaleCenterX;

            this.TextVerticalCenterY = showTextBlock.TextScaleCenterY;

            this.TextVerticalAngle = showTextBlock.TextVerticalAngle;

            this.FontColor = showTextBlock.FontColor;

            this.FontFamily = showTextBlock.FontFamily;

            this.TextScaleCenterX = showTextBlock.TextScaleCenterX;

            this.TextScaleCenterY = showTextBlock.TextScaleCenterY;

            this.TextScaleX = showTextBlock.TextScaleX;

            this.TextScaleY = showTextBlock.TextScaleY;
 
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
