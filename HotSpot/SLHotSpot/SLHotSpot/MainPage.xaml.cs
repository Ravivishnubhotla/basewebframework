using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLHotSpot.DiagramDesigner;
using SLHotSpot.HotSpotService;

namespace SLHotSpot
{
    public enum Mode
    {
        View,
        Design,
        Change
    }

    

    public partial class MainPage : UserControl
    {
        public SLHotSpotSetting setting;

        public ResizeRotateChrome resize = new ResizeRotateChrome();

        private string hotSpotData = "";

        Point? lastDragPoint;

        public bool canDragPanel = true;

        public ObservableCollection<ShopHotSpot> HostSpots = new ObservableCollection<ShopHotSpot>();

        public MainPage(SLHotSpotSetting _hotSpotSetting)
        {
            Resources.Add("brandInfos", CPData.GetAllData());

            resize.Hide();
 
            InitializeComponent();

            //casDrawPanel.MouseLeftButtonUp += ssvDrawOnMouseLeftButtonUp;
            //casDrawPanel.MouseMove += ssvDrawOnMouseMove;
            //casDrawPanel.MouseLeftButtonDown += ssvDrawOnMouseLeftButtonDown;
            casDrawPanel.MouseLeftButtonUp += ssvDrawOnMouseLeftButtonUp;
            casDrawPanel.MouseMove += ssvDrawOnMouseMove;
            casDrawPanel.MouseLeftButtonDown += ssvDrawOnMouseLeftButtonDown;


         


            setting = _hotSpotSetting;

            //LayoutRoot.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);

            switch (setting.ControlMode)
            {
                case Mode.View:
                    LayoutRoot.ColumnDefinitions[0].Width = new GridLength(100, GridUnitType.Star);
                    LayoutRoot.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);  
                    this.pnlAnalysis.Visibility = Visibility.Collapsed;
                    this.pnlManage.Visibility = Visibility.Collapsed;
                    this.pnlView.Visibility = Visibility.Visible;
                    break;
                case Mode.Change:
                    LayoutRoot.ColumnDefinitions[0].Width = new GridLength(85, GridUnitType.Star);
                    LayoutRoot.ColumnDefinitions[1].Width = new GridLength(15, GridUnitType.Star);  
                    this.pnlAnalysis.Visibility = Visibility.Visible;
                    this.pnlManage.Visibility = Visibility.Collapsed;
                    this.pnlView.Visibility = Visibility.Collapsed;
                    break;
                case Mode.Design:
                    //LayoutRoot.ColumnDefinitions[0].Width = new GridLength(25, GridUnitType.Star);
                    LayoutRoot.ColumnDefinitions[0].Width = new GridLength(75, GridUnitType.Star);
                    LayoutRoot.ColumnDefinitions[1].Width = new GridLength(25, GridUnitType.Star);  
                    this.pnlAnalysis.Visibility = Visibility.Collapsed;
                    this.pnlManage.Visibility = Visibility.Visible;
                    this.pnlView.Visibility = Visibility.Collapsed;
                    break;
            }

            if (!String.IsNullOrEmpty(setting.HotSpotBgImage))
            {
                biLoadingImage.IsBusy = true;

                Uri imageuri = new Uri(setting.HotSpotBgImage);
                WebClient webClient = new WebClient();

                webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

                webClient.OpenReadAsync(imageuri);
            }

            if (!String.IsNullOrEmpty(setting.DataID))
            {
                HotSpotWebServiceSoapClient serviceClient = GetHotSpotWebServiceSoapClient();
                serviceClient.LoadHotspotDataCompleted +=new EventHandler<LoadHotspotDataCompletedEventArgs>(serviceClient_LoadHotspotDataCompleted);
                serviceClient.LoadHotspotDataAsync(setting.DataID);
            }


        }

        private void OnItemOpened(HostSpot hostSpot)
        {
            if(ItemOpenedHandle!=null)
            {
                ItemOpenedHandle(hostSpot.DataID, EventArgs.Empty);
            }
        }

        [ScriptableMember]
        public event EventHandler ItemOpenedHandle;

        private void serviceClient_LoadHotspotDataCompleted(object sender, LoadHotspotDataCompletedEventArgs e)
        {
            hotSpotData = e.Result;

            if (string.IsNullOrEmpty(hotSpotData))
                return;

 

            ClearAll();

            JsonSerializer serializer = new JsonSerializer();

            var o = (JObject)serializer.Deserialize(new JsonTextReader(new StringReader(hotSpotData)));
 

            List<ROSHotSpot> rosHotSpots = JsonConvert.DeserializeObject<List<ROSHotSpot>>(o["rows"].ToString());

            foreach (ROSHotSpot rosHotSpot in rosHotSpots)
            {
                if (!(this.chkShowAllShop.IsChecked.HasValue && this.chkShowAllShop.IsChecked.Value) && this.setting.ControlMode == Mode.View && rosHotSpot.GetBrandInfo().Name != "Lenovo" && rosHotSpot.GetBrandInfo().Name != "ThinkPad")
                {
                    continue;
                }
                AddToCanvas(rosHotSpot, setting.ControlMode);
            }
 
            dgHotSpot.ItemsSource = HostSpots;

            if(this.setting.ControlMode == Mode.View)
            {
                dgHotSpotView.ItemsSource = HostSpots;
            }

            dgBrandCP.ItemsSource = CPData.GetAllData();

            //cwZoom coom = new cwZoom();
            //coom.Show();
        }

        //private Visifire.Charts.Chart chart;


 

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.biLoadingImage.BusyContent = string.Format("Downloading image {0} of 100.", e.ProgressPercentage);
            });
        }

        private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            biLoadingImage.IsBusy = false;

            LoadingImage(e.Result);
        }

        private void ssvDrawOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(canDragPanel)
            {
                var mousePos = e.GetPosition(casDrawPanel);
                if (mousePos.X <= ssvDraw.ViewportWidth && mousePos.Y < ssvDraw.ViewportHeight) //make sure we still can use the scrollbars
                {
                    casDrawPanel.Cursor = Cursors.Hand;
                    lastDragPoint = mousePos;
                    casDrawPanel.CaptureMouse();
                }
            }
        }

        private void ssvDrawOnMouseMove(object sender, MouseEventArgs e)
        {
            if (canDragPanel)
            {
                if (lastDragPoint.HasValue)
                {
                    Point posNow = e.GetPosition(casDrawPanel);

                    double dX = posNow.X - lastDragPoint.Value.X;
                    double dY = posNow.Y - lastDragPoint.Value.Y;

                    lastDragPoint = posNow;

                    


                    ssvDraw.ScrollToHorizontalOffset(ssvDraw.HorizontalOffset - scaleTransform.ScaleX * dX);
                    ssvDraw.ScrollToVerticalOffset(ssvDraw.VerticalOffset - scaleTransform.ScaleY * dY);

                    //Point pp = e.GetPosition(LayoutRoot);

                    //fg.Text = string.Format("{0},{1}", pp.X, pp.Y) + "\n" + string.Format("{0},{1}", posNow.X, posNow.Y);

                    //MessageBox.Show(string.Format("{0},{1}", pp.X, pp.Y));

                    //MessageBox.Show(string.Format("{0},{1}", pp.X, pp.Y));

                    //Canvas.SetLeft(xxx, posNow.X - pp.X + scaleTransform.ScaleX *20);
                    //Canvas.SetTop(xxx, posNow.Y - pp.Y + scaleTransform.ScaleY * 20);
                    //ssvDraw.ScrollToHorizontalOffset(scaleTransform.ScaleX * dX);
                    //ssvDraw.ScrollToVerticalOffset(scaleTransform.ScaleY * dY);
                }
            }
        }

        private void ssvDrawOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (canDragPanel)
            {
                casDrawPanel.Cursor = Cursors.Arrow;
                casDrawPanel.ReleaseMouseCapture();
                lastDragPoint = null;
            }
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.png";

            dialog.InitialDirectory = @"D:\";

            if (dialog.ShowDialog() == true)
            {
                LoadingImage(dialog.File.OpenRead());
            }
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
                Canvas.SetZIndex(casDrawPanel, -9999);
            }

            btnSelectImage.Visibility = Visibility.Collapsed;
            btnDrawArea.Visibility = Visibility.Visible;
            txtzoom.Visibility = Visibility.Visible;
            zoomSlider.Visibility = Visibility.Visible;
            //btnClearHotSpot.Visibility = Visibility.Visible;
            dgHotSpot.Visibility = Visibility.Visible;
            btnSaveHotSpot.Visibility = Visibility.Visible;
            //btnLoadHotSpot.Visibility = Visibility.Visible;
        }

        private ShopHotSpot hostSpot = new ShopHotSpot(Guid.NewGuid(), "Lenovo");

        private void btnDrawArea_Click(object sender, RoutedEventArgs e)
        {
            if (btnDrawArea.IsChecked.HasValue && btnDrawArea.IsChecked.Value)
            {
                btnDrawArea.Content = "绘制热点结束";
                hostSpot.BeginDraw(casDrawPanel);
            }
            else
            {
                if (hostSpot.EndDraw(casDrawPanel))
                {
                    cwShopEditor cwShop = new cwShopEditor();
                    cwShop.ShowAdd(hostSpot, this);
                    cwShop.Closed += new EventHandler(winHotSpot_Closed);
                }
                else
                {
                    MessageBox.Show("请至少输入3个点！");
                    btnDrawArea.IsChecked = !btnDrawArea.IsChecked;
                    return;
                }
            }
        }

        private void winHotSpot_Closed(object sender, EventArgs e)
        {
            cwShopEditor hotSpotEditor = sender as cwShopEditor;

            if (hotSpotEditor == null)
            {
                btnDrawArea.IsChecked = true;
                return;
            }

            if (!(hotSpotEditor.DialogResult.HasValue && hotSpotEditor.DialogResult.Value))
            {
                if (hotSpotEditor.DataMode == DataFormMode.AddNew)
                    btnDrawArea.IsChecked = true;
                return;
            }

            if (hotSpotEditor.DataMode == DataFormMode.AddNew)
            {
                ShopHotSpot newhostSpot = hotSpotEditor.GetItem();

                newhostSpot.AddHotspot(casDrawPanel, this.setting.ControlMode, this);

                HostSpots.Add(newhostSpot);

                dgHotSpot.ItemsSource = HostSpots;

                hostSpot = new ShopHotSpot(Guid.NewGuid(), "Lenovo");

                btnDrawArea.Content = "开始绘制热点";
            }
            else if (hotSpotEditor.DataMode == DataFormMode.Edit)
            {
                ShopHotSpot shopHotSpot = hotSpotEditor.GetItem();
 
                shopHotSpot.UpdateHotspot(casDrawPanel, this.setting.ControlMode, this);
                dgHotSpot.ItemsSource = HostSpots;
            }
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
            zoomValue = (zoomValue+3)/3d;
            scaleTransform.ScaleX = zoomValue;
            scaleTransform.ScaleY = zoomValue;
            layoutTransform.ApplyLayoutTransform();
        }

        [ScriptableMember]
        public void SetHotSpotSelected(string shopNO,bool selected)
        {
            ShopHotSpot spot = GetHotSpotByDataID(shopNO);

            if(spot!=null)
            {
                spot.IsSelected = selected;
            }
        }

        private void btnClearHotSpot_Click(object sender, RoutedEventArgs e)
        {
            List<UIElement> removedElements = new List<UIElement>();

            foreach (UIElement element in casDrawPanel.Children)
            {
                if (element is Rectangle && ((Rectangle)element).Tag == null)
                {
                    removedElements.Add(element);
                }
            }
            foreach (UIElement removedElement in removedElements)
            {
                casDrawPanel.Children.Remove(removedElement);
            }
        }

        private void ClearAll()
        {
            List<UIElement> removedElements = new List<UIElement>();

            foreach (UIElement element in casDrawPanel.Children)
            {
                if (!(element is Image) && !(element is Rectangle))
                {
                    removedElements.Add(element);
                }
            }
            foreach (UIElement removedElement in removedElements)
            {
                casDrawPanel.Children.Remove(removedElement);
            }
            HostSpots.Clear();
        }

        private void dgHotSpot_OnEditClick(object sender, RoutedEventArgs e)
        {
            Button lbtn = sender as Button;

            if (lbtn != null)
            {
                if (lbtn.CommandParameter is Guid)
                {
                    Guid editID = (Guid)lbtn.CommandParameter;
                    EditHotSpot(editID);
                }
            }
        }

        private void dgHotSpot_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            Button lbtn = sender as Button;

            if (lbtn != null)
            {
                if (lbtn.CommandParameter is Guid)
                {
                    Guid deleteID = (Guid)lbtn.CommandParameter;
                    DeleteHotSpot(deleteID);
                }
            }
        }

        private void EditHotSpot(Guid editId)
        {
            ShopHotSpot shopHotEdit = GetHotSpotBy(editId);

            cwShopEditor winHotSpot = new cwShopEditor();
            winHotSpot.ShowEdit(shopHotEdit,this);
            winHotSpot.Closed += new EventHandler(winHotSpot_Closed);

        }

        private void EditHotSpot(string shopNO)
        {
            ShopHotSpot shopHotEdit = GetHotSpotByDataID(shopNO);

            cwShopEditor winHotSpot = new cwShopEditor();
            winHotSpot.ShowEdit(shopHotEdit, this);
            winHotSpot.Closed += new EventHandler(winHotSpot_Closed);

        }

        private ShopHotSpot GetHotSpotByDataID(string shopNO)
        {
            foreach (ShopHotSpot hotSpot in HostSpots)
            {
                if (hotSpot.DataID == shopNO)
                    return hotSpot;
            }
            return null;
        }

        private void DeleteHotSpot(Guid deleteId)
        {
            ShopHotSpot shopHot = GetHotSpotBy(deleteId);

            List<UIElement> removedElements = new List<UIElement>();

            foreach (UIElement element in casDrawPanel.Children)
            {
                if (element is Polygon && ((Polygon)element).Tag == shopHot)
                {
                    removedElements.Add((Polygon)element);
                }
                if (element is TextBlock && ((TextBlock)element).Tag == shopHot)
                {
                    removedElements.Add((TextBlock)element);
                }
            }
            foreach (UIElement removedElement in removedElements)
            {
                casDrawPanel.Children.Remove(removedElement);
            }

            HostSpots.Remove(shopHot);

            //this.dgHotSpot.ItemsSource = HostSpots;
        }

        private ShopHotSpot GetHotSpotBy(Guid id)
        {
            foreach (ShopHotSpot hotSpot in HostSpots)
            {
                if (hotSpot.ID == id)
                    return hotSpot;
            }
            return null;
        }

        public ShopHotSpot GetHotSpotByIDAndDataID(Guid id, string dataID)
        {
            foreach (ShopHotSpot hotSpot in HostSpots)
            {
                if (hotSpot.DataID == dataID && hotSpot.ID != id)
                    return hotSpot;
            }
            return null;
        }

        private ToggleButton tbtn;

        private void dgHotSpot_OnChangeTextPosionClick(object sender, RoutedEventArgs e)
        {
            tbtn = sender as ToggleButton;

            if (tbtn != null)
            {
                ShopHotSpot shopHotSpot = GetHotSpotBy((Guid)tbtn.CommandParameter);

                if (tbtn.IsChecked.HasValue && tbtn.IsChecked.Value)
                {
                    shopHotSpot.StartChangeText();
                    canDragPanel = false;
                    tbtn.Content = "调整结束";

                    if (tbtn.Parent is StackPanel)
                    {
                        foreach (UIElement uiElement in ((StackPanel)tbtn.Parent).Children)
                        {
                            if (uiElement is StackPanel)
                            {
                                ((StackPanel)uiElement).Visibility = Visibility.Visible;
                            }
                        }
                    }



                }
                else
                {
                    if (shopHotSpot.EndChangeText())
                    {
                        canDragPanel = true;
                        tbtn.Content = "文字调整";
                        if (tbtn.Parent is StackPanel)
                        {
                            foreach (UIElement uiElement in ((StackPanel)tbtn.Parent).Children)
                            {
                                if (uiElement is StackPanel)
                                {
                                    ((StackPanel)uiElement).Visibility = Visibility.Collapsed;
                                }
                            }
                        }
                    }
                }
            }



        }

        private void btnSaveHotSpot_Click(object sender, RoutedEventArgs e)
        {
 
            HotSpotWebServiceSoapClient serviceClient = GetHotSpotWebServiceSoapClient();
 
            serviceClient.SaveHotspotDataAsync(setting.DataID, ROSHotSpot.HotSpotsToJson(HostSpots, imgBg.Width, imgBg.Height));
            serviceClient.SaveHotspotDataCompleted +=new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(serviceClient_SaveHotspotDataCompleted);

        }

        private HotSpotWebServiceSoapClient GetHotSpotWebServiceSoapClient()
        {
            BasicHttpBinding basicBinding = new BasicHttpBinding();

            basicBinding.MaxBufferSize = 2147483647;
            basicBinding.MaxReceivedMessageSize = 2147483647;

            CustomBinding binding = new CustomBinding(basicBinding);

            BindingElement binaryElement = new BinaryMessageEncodingBindingElement();

            EndpointAddress endPoint = new EndpointAddress(setting.WebServiceUrl);

            HotSpotWebServiceSoapClient serviceClient = new HotSpotWebServiceSoapClient(binding, endPoint);
 
            return serviceClient;
        }

        private void serviceClient_SaveHotspotDataCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error!=null)
            {
                MessageBox.Show("保存失败" + e.Error.Message);
            }
            else
            {
                MessageBox.Show("保存成功");
            }
        }
 
        public void cmAction_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            string dataID = menuItem.Tag as string;

            string actionType = menuItem.CommandParameter as string;

            switch (actionType)
            {
                case "Open":
                    HostSpot hotspot = GetHotSpotByDataID(dataID);
                    OnItemOpened(hotspot);
                    //HtmlPage.Window.Eval("window.open ('http://localhost:12031/Shop_ShopDetail.aspx?CSN=D0017216','newwindow','resizable=1,width=860,height=645,scrollbars=1');");
                    break;
                case "Edit":
                    EditHotSpot(dataID);
                    break;
                case "Change":
                    ChangeHotSpot(dataID);
                    break;
            }



        }

        private void ChangeHotSpot(string shopNo)
        {
            ShopHotSpot shopHotEdit = GetHotSpotByDataID(shopNo);

            cwChangeShopBrand winHotSpot = new cwChangeShopBrand();
            winHotSpot.ShowEdit(shopHotEdit, this);
            winHotSpot.Closed += new EventHandler(ChangeHotSpot_Closed);
        }

        private void ChangeHotSpot_Closed(object sender, EventArgs e)
        {
            cwChangeShopBrand hotSpotEditor = sender as cwChangeShopBrand;

            if (hotSpotEditor == null)
            {
                return;
            }

            if (!(hotSpotEditor.DialogResult.HasValue && hotSpotEditor.DialogResult.Value))
            {
                return;
            }

            ShopHotSpot shopHotSpot = hotSpotEditor.GetItem();

            //shopHotSpot.UpdateText();

            shopHotSpot.UpdateHotspot(casDrawPanel, setting.ControlMode, this);

            dgHotSpot.ItemsSource = HostSpots;

            CPData.CaculateAllData();
 
        }

        private void AddToCanvas(ROSHotSpot rosHotSpot,Mode mode)
        {
            ShopHotSpot shopHot = new ShopHotSpot(rosHotSpot, casDrawPanel, mode,this);

            HostSpots.Add(shopHot);
        }

        private void btnStartAnalysis_Click(object sender, RoutedEventArgs e)
        { 
            CPData.CaculateAllData();
        }

        private void chkShowAllShop_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();

            List<ROSHotSpot> rosHotSpots = JsonConvert.DeserializeObject<List<ROSHotSpot>>(hotSpotData);

            foreach (ROSHotSpot rosHotSpot in rosHotSpots)
            {
                if (!(this.chkShowAllShop.IsChecked.HasValue && this.chkShowAllShop.IsChecked.Value) && this.setting.ControlMode == Mode.View && rosHotSpot.GetBrandInfo().Name != "Lenovo" && rosHotSpot.GetBrandInfo().Name != "ThinkPad")
                {
                    continue;
                }
                AddToCanvas(rosHotSpot, setting.ControlMode);
            }

            dgHotSpot.ItemsSource = HostSpots;

            if (this.setting.ControlMode == Mode.View)
            {
                dgHotSpotView.ItemsSource = HostSpots;
            }
        }

        private void dgHotSpot_OnTextChangeClick(object sender, RoutedEventArgs e)
        {
            Button btnOnTextChange = sender as Button;

            if (btnOnTextChange != null && btnOnTextChange.Tag!=null)
            {
                ShopHotSpot shopHotSpot = GetHotSpotBy((Guid)btnOnTextChange.CommandParameter);

                if (shopHotSpot !=null && btnOnTextChange.Tag.ToString() == "+")
                {
                    shopHotSpot.LargeText(0.1);
                }
                else if (shopHotSpot !=null && btnOnTextChange.Tag.ToString() == "-")
                {
                    shopHotSpot.SmallText(0.1);
                }
            }
        }

        private void chkCheckAlldgHotSpotView_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;

            bool selected = checkBox.IsChecked.HasValue ? checkBox.IsChecked.Value : false;

            foreach (var hostSpot in HostSpots)
            {
                hostSpot.IsSelected = selected;
            }
        }


        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            HtmlPage.RegisterScriptableObject("SLControl",this);
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
    }
}
