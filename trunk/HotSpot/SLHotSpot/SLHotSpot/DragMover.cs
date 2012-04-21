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
    public class DragMover
    {
        bool trackingMouseMove = false;
        Point mousePosition;
        FrameworkElement moveFramework;

        public DragMover(FrameworkElement _moveFramework)
        {
            moveFramework = _moveFramework;
        }

        public void EnableTracking()
        {
            moveFramework.MouseLeftButtonDown += new MouseButtonEventHandler(OnMouseDown);
            moveFramework.MouseMove += new MouseEventHandler(OnMouseMove);
            moveFramework.MouseLeftButtonUp += new MouseButtonEventHandler(OnMouseUp);
            //((Canvas)moveFramework.Parent).KeyDown += new KeyEventHandler(OnKeyDown);
        }

        //private void OnKeyDown(object sender, KeyEventArgs e)
        //{
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
 
        //}

        public void DisableTracking()
        {
            moveFramework.MouseLeftButtonDown -= new MouseButtonEventHandler(OnMouseDown);
            moveFramework.MouseMove -= new MouseEventHandler(OnMouseMove);
            moveFramework.MouseLeftButtonUp -= new MouseButtonEventHandler(OnMouseUp);
        }

        void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            mousePosition = e.GetPosition(null);
            trackingMouseMove = true;
            if (null != element)
            {
                element.CaptureMouse();
                element.Cursor = Cursors.Hand;
            }
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (trackingMouseMove)
            {
                double deltaV = e.GetPosition(null).Y - mousePosition.Y;
                double deltaH = e.GetPosition(null).X - mousePosition.X;
                double newTop = deltaV + (double)element.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)element.GetValue(Canvas.LeftProperty);

                element.SetValue(Canvas.TopProperty, newTop);
                element.SetValue(Canvas.LeftProperty, newLeft);

                mousePosition = e.GetPosition(null);
            }
        }

        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            trackingMouseMove = false;
            element.ReleaseMouseCapture();

            mousePosition.X = mousePosition.Y = 0;
            element.Cursor = null;
        }


    }
}
