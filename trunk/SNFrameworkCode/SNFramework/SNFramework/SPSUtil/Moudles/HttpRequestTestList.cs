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
            this.dgvList.AutoGenerateColumns = true;
            RefreshList();
        }

        private void RefreshList()
        {
            this.bsList.DataSource = Program.DbRepository.All<SPSRequestTest>().ToList();
            this.dgvList.DataSource = this.bsList;
        }

        private void tsTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbAdd":

                    SPSRequestTest spsRequest = new SPSRequestTest();
                    spsRequest.RequestType = SPSRequestType.HttpGet;
                    spsRequest.Name = "新建请求测试";
                    spsRequest.Description = "新建请求测试";
                    Program.DbRepository.Add(spsRequest);
                    RefreshList();
                    break;
            }
        }
    }
}
