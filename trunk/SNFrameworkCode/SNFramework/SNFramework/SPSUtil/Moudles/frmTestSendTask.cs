using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPSUtil.AppCode;

namespace SPSUtil.Moudles
{
    public partial class frmTestSendTask : Form
    {
        public frmTestSendTask()
        {
            InitializeComponent();
        }

        public HttpGetSenderTask SendTask
        {
            get
            {
                HttpGetSenderTask senderTask = new HttpGetSenderTask(this.txtTemplateUrl.Text.Trim(), this.txtOkMessage.Text.Trim(), Convert.ToInt32(this.nudTimeOut.Value), Convert.ToInt32(this.nudIntreval.Value)
                    , Convert.ToInt32(this.nudRetryTime.Value), Convert.ToInt32(this.nudSendCount.Value));

                return senderTask;
            }
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTemplateUrl.Text.Trim()))
            {
                MessageBox.Show("请输入请求测试信息！");
                return;
            }
            if(string.IsNullOrEmpty(this.txtOkMessage.Text.Trim()))
            {
                MessageBox.Show("请输入成功响应信息！");
                return;
            }

            try
            {
                HttpGetSenderTask sendertask = SendTask;

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
