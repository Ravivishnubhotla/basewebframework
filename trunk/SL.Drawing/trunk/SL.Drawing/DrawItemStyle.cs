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

        private static DrawItemStyle defaultNormalStyle;
        private static DrawItemStyle hoverNormalStyle;
        private static DrawItemStyle selectedNormalStyle;

        public static DrawItemStyle SelectedNormalStyle
        {
            get { return selectedNormalStyle; }
        }

        public static DrawItemStyle HoverNormalStyle
        {
            get { return hoverNormalStyle; }
        }

        public static DrawItemStyle DefaultNormalStyle
        {
            get { return defaultNormalStyle; }
        }


        static DrawItemStyle()
        {
            defaultNormalStyle = new DrawItemStyle();

            defaultNormalStyle.FillColor = "blue";
            defaultNormalStyle.FillColorOpacity = 1;
            defaultNormalStyle.BorderColor = "black";
            defaultNormalStyle.BorderThickness = 2;
            defaultNormalStyle.BorderDashArray = new double[]{};


            hoverNormalStyle = new DrawItemStyle();

            hoverNormalStyle.FillColor = "blue";
            hoverNormalStyle.FillColorOpacity = 1;
            hoverNormalStyle.BorderColor = "black";
            hoverNormalStyle.BorderThickness = 2;
            hoverNormalStyle.BorderDashArray = new double[] { };


            selectedNormalStyle = new DrawItemStyle();

            selectedNormalStyle.FillColor = "blue";
            selectedNormalStyle.FillColorOpacity = 1;
            selectedNormalStyle.BorderColor = "black";
            selectedNormalStyle.BorderThickness = 2;
            selectedNormalStyle.BorderDashArray = new double[] { };

            
 
        }


 
    }
}
