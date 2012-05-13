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

namespace SL.Drawing
{
    public class DrawItemStyle
    {
        public string FillColor { get; set; }
        public double FillColorOpacity { get; set; }

        public string BorderColor { get; set; }
        public int BorderThickness { get; set; }
        public double[] BorderDashArray { get; set; }


        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
    }
}
