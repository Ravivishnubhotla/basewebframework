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

namespace SLHotSpot
{
    public class HotSpotPolygon
    {
        public List<Point> HotSpotPoints { get; set; }

        public string FillColor { get; set; }
        public string FillOverColor { get; set; }
        public double FillColorOpacity { get; set; }
        public string BorderColor { get; set; }
        public int BorderThickness { get; set; }
    }
}
