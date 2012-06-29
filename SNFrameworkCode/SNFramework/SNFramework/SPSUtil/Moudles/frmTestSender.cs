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
    public partial class frmTestSender : DockContent
    {
        public frmTestSender()
        {
            InitializeComponent();
        }

        private void chkHasPostData_CheckedChanged(object sender, EventArgs e)
        {
            tblRequestMessage.Visible = chkHasPostData.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(chkHasPostData.Checked)
            {
                this.txtResponseMessge.Text = HttpGetSenderTaskItem.SendRequest(this.txtUrl.Text.Trim(),this.txtRequestMessage.Text.Trim(), 15000);
            }
            else
            {
                this.txtResponseMessge.Text = HttpGetSenderTaskItem.SendRequest(this.txtUrl.Text.Trim(), 15000);
            }
        }
    }
}
