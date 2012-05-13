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
    public abstract class DrawItem
    {

        public string Id { get; set; }
        public string ExtendDataId { get; set; }
        public string ExtendData { get; set; }

        public string Text { get; set; }
        public double TextAngle { get; set; }
        public double TextScale { get; set; }
        public string Tooltip { get; set; }

        public bool IsSelected { get; set; }
        public bool InDrawing { get; set; }
        public bool InChangingText { get; set; }

        public DrawItemStyle NormalStyle { get; set; }
        public DrawItemStyle HoverStyle { get; set; }
        public DrawItemStyle SelectedStyle { get; set; }

        protected Canvas DrawCanvas { get; set; } 

        #region 常量

        //文字多边形外围比例（默认采用黄金分割比）
        public const double GoldenSectionRate = 0.6180339887d;
        public const int CanvasZindex = -9999;
        public const int AssistlineZindex = 1000;
        public const int ShowShapeZindex = 2000;
        public const int ShowTextBlockZindex = 3000;

        #endregion
 
 
    }
}
