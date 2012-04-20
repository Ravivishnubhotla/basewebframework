using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLHotSpot
{
    public partial class cwChangeShopBrand : ChildWindow
    {
        public cwChangeShopBrand()
        {
            Resources.Add("brandInfos", BrandInfo.BrandInfos);
            InitializeComponent();
        }

        public MainPage ParentWindow { get; set; }
        ShopHotSpot shopHotSpot = null;

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmbBrandInfo.SelectedValue == null)
            {
                MessageBox.Show("请选择品牌！");
                //this.DialogResult = false;
                return;
            }

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public ShopHotSpot GetItem()
        {


            //if (this.dataFormHotSpot.ItemsSource is ShopHotSpot)
            //    shopHotSpot = (ShopHotSpot)this.dataFormHotSpot.ItemsSource;

            //if (this.dataFormHotSpot.ItemsSource is List<ShopHotSpot>)
            //    shopHotSpot = ((List<ShopHotSpot>)this.dataFormHotSpot.ItemsSource)[0];


            if (shopHotSpot != null)
            {
                //if(DataMode == DataFormMode.AddNew)

                shopHotSpot.Brand = ((BrandInfo)this.cmbBrandInfo.SelectedValue).Name;
                shopHotSpot.UpdateText();

                return shopHotSpot;
            }

            return null;
        }

        public void ShowEdit(ShopHotSpot hostSpot, MainPage mainPage)
        {
            ParentWindow = mainPage;
 
            shopHotSpot = hostSpot;
            this.txtShopNo.Text = shopHotSpot.DataID;
            this.cmbBrandInfo.SelectedValue = BrandInfo.GetBrandInfo(shopHotSpot.Brand);
            Show();
        }
    }
}

