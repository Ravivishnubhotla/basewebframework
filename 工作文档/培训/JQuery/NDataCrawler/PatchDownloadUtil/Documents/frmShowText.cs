using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatchDownloadUtil.Documents
{
    public partial class frmShowText : Form
    {
        public frmShowText(string sText)
        {
            InitializeComponent();

            this.txtShowText.Text = sText;
        }
    }
}
