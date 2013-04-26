using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;
using SPSUtil.AppCode;

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
                DataTable loadExcelData = ExcelFileReader.ReadExcelSheet(opfLoadExcel.FileName,true);
                this.dataGridView1.DataSource = loadExcelData;
            }
        }

        private void btnSaveSendText_Click(object sender, EventArgs e)
        {
            //List<string> sendUrls = new List<string>();

            //DataTable dt = this.dataGridView1.DataSource as DataTable;

            //foreach (DataRow row in dt.Rows)
            //{
            //    string url = this.txturl.Text.Trim();

            //    foreach (DataColumn dataColumn in dt.Columns)
            //    {
            //        url = url.Replace("{$" + dataColumn + "}", row[dataColumn].ToString());
            //    }
                
            //    sendUrls.Add(url);
            //}


            //if(sfdSendText.ShowDialog()==DialogResult.OK)
            //{
            //    File.WriteAllLines(sfdSendText.FileName,sendUrls.ToArray());
            //}

        }

 

        private void btnSendData_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadText_Click(object sender, EventArgs e)
        {
            if (opfLoadText.ShowDialog() == DialogResult.OK)
            {
                DataTable loadTextData = CsvFileReader.LoadTextFile(opfLoadText.FileName, "Select * from [$FileName]", false, ",");
                this.dataGridView1.DataSource = loadTextData;
            }
        }

        private void frmDataSendTask_Shown(object sender, EventArgs e)
        {
            List<SPChannelWrapper> channels = SPChannelWrapper.FindAll();

            this.cmbChannelList.DataSource = channels;
        }

        private void cmbChannelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChannelList.SelectedValue != null)
            {
                SPChannelWrapper channel = cmbChannelList.SelectedValue as SPChannelWrapper;

                if (channel != null)
                {
                    ChannelSendSettings channelSetting = new ChannelSendSettings();

                    channelSetting.SubmitSendUrl = channel.GetInterfaceUrl("http://localhost:55662");

                    channelSetting.ParamsLinkidName = channel.ChannelParams[DictionaryConst.Dictionary_SPField_LinkID_Key];

                    channelSetting.ParamsMoName = channel.ChannelParams[DictionaryConst.Dictionary_SPField_MO_Key];

                    channelSetting.ParamsMobileName =  channel.ChannelParams[DictionaryConst.Dictionary_SPField_Mobile_Key];

                    channelSetting.ParamsSPCodeName =  channel.ChannelParams[DictionaryConst.Dictionary_SPField_SpNumber_Key];

                    channelSetting.DataOkMessage = channel.DataOkMessage;

                    channelSetting.IsStatusReport = channel.IsStateReport;

                    channelSetting.ParamsStatusName = channel.StateReportParamName;

                    channelSetting.RequestType = 0;

                    if (!channel.IsStateReport)
                    {
                        channelSetting.RequestType = 0;
                    }
                    else
                    {
                        if (channel.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendOnce_Key)
                        {
                            channelSetting.RequestType = 0;
                        }
                        else if (channel.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwice_Key)
                        {
                            channelSetting.RequestType = 1;
                        }
                        else if (channel.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key)
                        {
                            channelSetting.RequestType = 2;
                        }
                    }

 

                    channelSetting.ParamsStatusValue = channel.StateReportParamValue;

                    channelSetting.ParamsRequestTypeDataValue = channel.RequestTypeParamDataReportValue;

                    channelSetting.ParamsRequestTypeName = channel.RequestTypeParamName;

                    channelSetting.ParamsRequestTypeReportValue = channel.RequestTypeParamStateReportValue;

                    channelSetting.ReportOkMesage = channel.ReportOkMessage;    

                    this.ucChannelParams1.ChannelSetting = channelSetting;
                }

            }
        }

        private void btnGenerateTestData_Click(object sender, EventArgs e)
        {
            List<string> sendUrls = new List<string>();

            DataTable dt = this.dataGridView1.DataSource as DataTable;

            if (dt == null)
            {
                MessageBox.Show("加载数据存在");
                return;
            }

            ChannelSendSettings channelSetting = this.ucChannelParams1.ChannelSetting;

            foreach (DataRow row in dt.Rows)
            {
                sendUrls.AddRange(channelSetting.GenerateDataUrls(row));
            }

            if (sfdSendText.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfdSendText.FileName, sendUrls.ToArray());
            }
        }

 
    }
}
