using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGeneratetionWin.Forms
{
    public partial class OutPutForm : Form
    {
        public OutPutForm()
        {
            InitializeComponent();
        }

        public void ShowText(string text)
        {
            this.textBox1.Text = text;
        }
    }
}
