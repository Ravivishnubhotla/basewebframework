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
    public class DropDrager : IDisposable
    {

        protected Canvas casDrawPanel;
        protected ScrollViewer ssvDraw;
        protected ScaleTransform scaleTransform;

        private DropDrager()
        {
        }

        public DropDrager(Canvas _casDrawPanel, ScrollViewer _ssvDraw, ScaleTransform _scaleTransform)
        {
            casDrawPanel = _casDrawPanel;
            ssvDraw = _ssvDraw;
            scaleTransform = _scaleTransform;

            casDrawPanel.MouseLeftButtonUp += ssvDrawOnMouseLeftButtonUp;
            casDrawPanel.MouseMove += ssvDrawOnMouseMove;
            casDrawPanel.MouseLeftButtonDown += ssvDrawOnMouseLeftButtonDown;
        }



        Point? lastDragPoint;

        private void ssvDrawOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(casDrawPanel);
            if (mousePos.X <= ssvDraw.ViewportWidth && mousePos.Y < ssvDraw.ViewportHeight) //make sure we still can use the scrollbars
            {
                casDrawPanel.Cursor = Cursors.Hand;
                lastDragPoint = mousePos;
                casDrawPanel.CaptureMouse();
            }
        }

        private void ssvDrawOnMouseMove(object sender, MouseEventArgs e)
        {

            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(casDrawPanel);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                ssvDraw.ScrollToHorizontalOffset(ssvDraw.HorizontalOffset - scaleTransform.ScaleX * dX);
                ssvDraw.ScrollToVerticalOffset(ssvDraw.VerticalOffset - scaleTransform.ScaleY * dY);
            }
        }

        private void ssvDrawOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            casDrawPanel.Cursor = Cursors.Arrow;
            casDrawPanel.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        public void Dispose()
        {
            if (casDrawPanel!=null)
            {
                casDrawPanel.MouseLeftButtonUp -= ssvDrawOnMouseLeftButtonUp;
                casDrawPanel.MouseMove -= ssvDrawOnMouseMove;
                casDrawPanel.MouseLeftButtonDown -= ssvDrawOnMouseLeftButtonDown;
            }
        }
    }
}
