using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPSUtil.AppCode;
using WeifenLuo.WinFormsUI.Docking;

namespace SPSUtil.Moudles
{
    public partial class HttpRequestTestList : DockContent
    {
        public HttpRequestTestList()
        {
            InitializeComponent();
        }

        private void HttpRequestTestList_Shown(object sender, EventArgs e)
        {
            //this.dgvList.AutoGenerateColumns = true;
            RefreshList();
        }

        private void RefreshList()
        {
            //this.bsList.DataSource = Program.DbRepository.All<SPSRequestTest>().ToList();
            //this.dgvList.DataSource = this.bsList;
        }

        //private void tsTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    switch (e.ClickedItem.Name)
        //    {
        //        case "tsbAdd":

        //            SPSRequestTest spsRequest = new SPSRequestTest();

        //            Program.DbRepository.Add(spsRequest);
        //            RefreshList();
        //            break;
        //    }
        //}
 

        private void bsList_ListChanged(object sender, ListChangedEventArgs e)
        {
             //if(e.ListChangedType == ListChangedType.ItemAdded)
             //{
             //    if (bsList.Current!=null)
             //    {
             //        SPSRequestTest newSPSRequestTest = bsList.Current as SPSRequestTest;

             //        if (newSPSRequestTest != null)
             //        {
             //            newSPSRequestTest.RequestType = SPSRequestType.HttpGet;
             //            newSPSRequestTest.Name = "新建请求测试";
             //            newSPSRequestTest.Description = "新建请求测试";

             //            int cint =  bsList.Count-1;

             //            bsList[cint] = newSPSRequestTest;

             //            Program.DbRepository.Add(newSPSRequestTest);
             //        }
             //    }
             //}
             //if (e.ListChangedType == ListChangedType.ItemDeleted)
             //{
             //    bsList.
             //}
        }

        private void bvList_ItemAdded(object sender, ToolStripItemEventArgs e)
        {


            MessageBox.Show("1212");

        }

        private void bvList_ItemRemoved(object sender, ToolStripItemEventArgs e)
        {
            MessageBox.Show("1212");
        }

        private void bvList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem":
                                
                    SPSRequestTest newSPSRequestTest = new SPSRequestTest();

                    newSPSRequestTest.RequestType = SPSRequestType.HttpGet;
                    newSPSRequestTest.Name = "新建请求测试";
                    newSPSRequestTest.Description = "新建请求测试";
                    //Program.DbRepository.Add(newSPSRequestTest);

                    bsList.Add(newSPSRequestTest);
                    
                    break;
                case "bindingNavigatorDeleteItem":

                    SPSRequestTest delSPSRequestTest = bvList.BindingSource.Current as SPSRequestTest;

                    //if (delSPSRequestTest != null && delSPSRequestTest.Id>0)
                    //{
                    //    Program.DbRepository.Delete<SPSRequestTest>(delSPSRequestTest.Id);
                    //}

                    bvList.BindingSource.RemoveCurrent();

                    break;
            }
        }

 
    }
}
