using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SL.Drawing
{
    public partial class MainPage : UserControl
    {
        protected DropDrager dropDrager;

        protected DrawPolygonItem drawPolygonItem;

        public MainPage(DrawingSetting setting)
        {
            InitializeComponent();

            dropDrager = new DropDrager(casDrawPanel,ssvDraw,scaleTransform);
 
            LoadImage(setting.BgImageUrl);
        }

        private void LoadImage(string bgImageUrl)
        {
            if (!String.IsNullOrEmpty(bgImageUrl))
            {
                biLoadingImage.IsBusy = true;

                Uri imageuri = new Uri(bgImageUrl);

                WebClient webClient = new WebClient();

                webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

                webClient.OpenReadAsync(imageuri);
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.biLoadingImage.BusyContent = string.Format("图片下载中 {0} 共 100.", e.ProgressPercentage);
            });
        }

        private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            biLoadingImage.IsBusy = false;

            LoadingImage(e.Result);
        }

        private void LoadingImage(Stream imageStream)
        {
            using (Stream fs = imageStream)
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                BitmapImage bi = new BitmapImage();
                bi.SetSource(new MemoryStream(buffer));
                this.casDrawPanel.Width = bi.PixelWidth;
                this.casDrawPanel.Height = bi.PixelHeight;
                this.imgBg.Width = bi.PixelWidth;
                this.imgBg.Height = bi.PixelHeight;
                this.imgBg.Source = bi;
                Canvas.SetZIndex(casDrawPanel, DrawItem.CanvasZindex);
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            ssvDraw.ScrollToVerticalOffset(ssvDraw.VerticalOffset - scaleTransform.ScaleY * 10);
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            ssvDraw.ScrollToHorizontalOffset(ssvDraw.HorizontalOffset - scaleTransform.ScaleX * 10);
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            ssvDraw.ScrollToHorizontalOffset(ssvDraw.HorizontalOffset + scaleTransform.ScaleX * 10);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            ssvDraw.ScrollToVerticalOffset(ssvDraw.VerticalOffset + scaleTransform.ScaleY * 10);
        }

        private void btnLarge_Click(object sender, RoutedEventArgs e)
        {
            double newValue = Math.Min(zoomSlider.Value + 1, zoomSlider.Maximum);

            zoomSlider.Value = newValue;
        }

        private void btnSmall_Click(object sender, RoutedEventArgs e)
        {
            double newValue = Math.Max(zoomSlider.Value - 1, zoomSlider.Minimum);

            zoomSlider.Value = newValue;
        }

        private void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider && this.imgBg != null && this.imgBg.Source != null)
            {
                SetZoom(((Slider)sender).Value);
            }
        }

        [ScriptableMember]
        public void SetZoom(double zoomValue)
        {
            zoomValue = (zoomValue + 3) / 3d;
            scaleTransform.ScaleX = zoomValue;
            scaleTransform.ScaleY = zoomValue;
            layoutTransform.ApplyLayoutTransform();
        }
 

        private void btnAddHotSpot_Click(object sender, RoutedEventArgs e)
        {
            pnlAddHotSpot.Visibility = Visibility.Visible;
            btnAddHotSpot.Visibility = Visibility.Collapsed;
            drawPolygonItem = new DrawPolygonItem();
            drawPolygonItem.Id = Guid.NewGuid().ToString();
        }
 

        private void btnClearLastPoint_Click(object sender, RoutedEventArgs e)
        {
            drawPolygonItem.CancelLastSetPoint();
        }

        private void btnClearPoint_Click(object sender, RoutedEventArgs e)
        {
            drawPolygonItem.CancelAllSetPoint();
        }

        private void chkCheckAllDrawItems_Click(object sender, RoutedEventArgs e)
        {
 
        }


        private void btnStartSetPoint_Click(object sender, RoutedEventArgs e)
        {


            drawPolygonItem.BeginDrawOnCanvas(this.casDrawPanel);

            this.btnStartSetPoint.Visibility = Visibility.Collapsed;
            this.btnClearPoint.Visibility = Visibility.Visible;
            this.btnCancelSetPoint.Visibility = Visibility.Visible;
            this.btnEndSetPoint.Visibility = Visibility.Visible;
            this.btnClearLastPoint.Visibility = Visibility.Visible;
        }

        private void btnEndSetPoint_Click(object sender, RoutedEventArgs e)
        {


            string errorMessage = "";

            if (drawPolygonItem.CanEndDrawOnCanvas(out errorMessage))
            {
                drawPolygonItem.EndDrawOnCanvas(this.casDrawPanel);
                this.btnStartSetPoint.Visibility = Visibility.Visible;
                this.btnClearPoint.Visibility = Visibility.Collapsed;
                this.btnCancelSetPoint.Visibility = Visibility.Collapsed;
                this.btnEndSetPoint.Visibility = Visibility.Collapsed;
                this.btnClearLastPoint.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show(errorMessage);             
            }




        }

        private void btnCancelSetPoint_Click(object sender, RoutedEventArgs e)
        {


            drawPolygonItem.CancelDrawOnCanvas(this.casDrawPanel);

            this.btnStartSetPoint.Visibility = Visibility.Visible;
            this.btnClearPoint.Visibility = Visibility.Collapsed;
            this.btnCancelSetPoint.Visibility = Visibility.Collapsed;
            this.btnEndSetPoint.Visibility = Visibility.Collapsed;
            this.btnClearLastPoint.Visibility = Visibility.Collapsed;
        }
    }
}
