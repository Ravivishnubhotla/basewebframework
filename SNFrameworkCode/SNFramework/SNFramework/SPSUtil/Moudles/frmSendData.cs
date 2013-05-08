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
    public partial class frmSendData : Form
    {
        public frmSendData()
        {
            InitializeComponent();
        }

        public void ShowSendData(ChannelSendSettings channelSetting, DataTable dt)
        {
            this.ShowDialog();
        }
    }
}
