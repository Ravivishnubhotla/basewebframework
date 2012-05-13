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
        public List<DrawPoint> PolygonPoints { get; set; }

        //绘点辅助线
        protected Polyline Assistline { get; set; }


    }
}
