using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legendigital.Framework.Common.Utility;

namespace SPSUtil.Moudles
{
    public partial class frmDataSendTask : Form
    {
        public frmDataSendTask()
        {
            InitializeComponent();
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            if(opfLoadExcel.ShowDialog()==DialogResult.OK)
            {
                DataTable loadExcelData = ExcelFileReader.ReadExcelSheet("查询", opfLoadExcel.FileName);
                this.dataGridView1.DataSource = loadExcelData;
            }
        }

        private void btnSaveSendText_Click(object sender, EventArgs e)
        {
            List<string> sendUrls = new List<string>();

            DataTable dt = this.dataGridView1.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                string url = this.txturl.Text.Trim();

                foreach (DataColumn dataColumn in dt.Columns)
                {
                    url = url.Replace("{$" + dataColumn + "}", row[dataColumn].ToString());
                }
                
                sendUrls.Add(url);
            }


            if(sfdSendText.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllLines(sfdSendText.FileName,sendUrls.ToArray());
            }




        }

 
    }
}
