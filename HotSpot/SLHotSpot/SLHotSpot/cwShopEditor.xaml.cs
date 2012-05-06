using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace SLHotSpot
{
    public partial class cwShopEditor : ChildWindow
    {
        public cwShopEditor()
        {
            //cmbShopNo.ItemsSource = shopNOs;
            InitializeComponent();


            //this.cmbShopNo.ItemsSource = ShopInfo.AllShopInfo;
            //cmbShopNo.ItemsSource = shopNOs;
        }

        public ObservableCollection<ShopInfo> AllShopNOs
        {
            get
            {
                ObservableCollection<ShopInfo> shops = new ObservableCollection<ShopInfo>();

                foreach (ShopInfo shopInfo in ShopInfo.AllShopInfo)
                {
                    shops.Add(shopInfo);
                }

                return shops;
            }
        }

        public ObservableCollection<ShopInfo> NotAssignedShopNOs
        {
            get
            {
                ObservableCollection<ShopInfo> shops = new ObservableCollection<ShopInfo>();

                foreach (ShopInfo shopInfo in ShopInfo.AllShopInfo)
                {
                    if (ParentWindow.GetHotSpotByDataID(shopInfo.SeatNO)==null)
                        shops.Add(shopInfo);
                }

                return shops;
            }
        }

        public MainPage ParentWindow { get; set; }
        public DataFormMode DataMode { get; set; }

        ShopHotSpot shopHotSpot = null;

        public ShopHotSpot GetItem()
        {


            //if (this.dataFormHotSpot.ItemsSource is ShopHotSpot)
            //    shopHotSpot = (ShopHotSpot)this.dataFormHotSpot.ItemsSource;

            //if (this.dataFormHotSpot.ItemsSource is List<ShopHotSpot>)
            //    shopHotSpot = ((List<ShopHotSpot>)this.dataFormHotSpot.ItemsSource)[0];


            if (shopHotSpot != null)
            {
                //if(DataMode == DataFormMode.AddNew)

                shopHotSpot.DataID = ((ShopInfo)this.cmbShopNo.SelectedValue).SeatNO.ToString();
                shopHotSpot.IsRotate = this.chkTextIsVertical.IsChecked.HasValue && this.chkTextIsVertical.IsChecked.Value;
                shopHotSpot.UpdateInfo();

                return shopHotSpot;
            }

            return null;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmbShopNo.SelectedValue == null)
            {
                MessageBox.Show("请输入席位号！");
                //this.DialogResult = false;
                return;
            }

            string showN0 = ((ShopInfo)this.cmbShopNo.SelectedValue).SeatNO;

            if (ParentWindow.GetHotSpotByIDAndDataID(shopHotSpot.ID, showN0) != null)
            {
                MessageBox.Show(string.Format("席位号{0}已存在！", showN0));
                //this.DialogResult = false;
                return;
            }

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void ShowAdd(ShopHotSpot hostSpot, MainPage parentWindow)
        {

            ParentWindow = parentWindow;
            this.cmbShopNo.ItemsSource = NotAssignedShopNOs;
            DataMode = DataFormMode.AddNew;
            shopHotSpot = hostSpot;
            this.cmbShopNo.SelectedValue = shopHotSpot.DataID;
            this.chkTextIsVertical.IsChecked = shopHotSpot.IsRotate;
            Show();
        }

        public void ShowEdit(ShopHotSpot hostSpot, MainPage parentWindow)
        {

            ParentWindow = parentWindow;
            this.cmbShopNo.ItemsSource = AllShopNOs;
            DataMode = DataFormMode.Edit;
            shopHotSpot = hostSpot;
            this.cmbShopNo.SelectedValue = ShopInfo.GetBySeatNo(shopHotSpot.DataID);
            this.chkTextIsVertical.IsChecked = shopHotSpot.IsRotate;
            Show();
        }
    }
}

