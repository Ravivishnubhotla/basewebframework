using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Csv;

namespace SPSUtil.Moudles
{
    public partial class FrmLoadPhoneData : Form
    {
        public FrmLoadPhoneData()
        {
            InitializeComponent();
        }

        protected string filePath;
        protected int rowCounts;
        protected int rowSuccessCounts;

        public void LoadText(string fileName)
        {
            filePath = fileName;

            string title = string.Format("正在从文本文件“{0}”导入手机号段信息.", Path.GetFileName(fileName));

            this.Text = title;

            lblTitle.Text = title;

            this.lblFilePath.Text = fileName;

            this.lblProcessStatus.Text = "文本文件读取中。。。";

            bgwLoadPhoneData.RunWorkerAsync(fileName);
        }

        public void SetTitle(string text,int fileCount)
        {
            //if (this.InvokeRequired)
            //{
                this.Invoke(new Action(delegate()
                {
                    this.Text = text;
                    this.lblTitle.Text = text;
                    this.lblProcessStatus.Text = "开始导入号码数据。。。";
                    this.pgbProgress.Maximum = fileCount;
                    this.pgbProgress.Minimum = 0;
                }));
            //}
            //else
            //{
            //    this.Text = text;
            //    this.lblTitle.Text = text;
            //    this.lblProcessStatus.Text = "开始导入号码数据。。。";
            //    this.pgbProgress.Maximum = fileCount;
            //    this.pgbProgress.Minimum = 0;
            //}
        }

        private void bgwLoadPhoneData_DoWork(object sender, DoWorkEventArgs e)
        {
            string loadFile = e.Argument as string;

            int fileCount = File.ReadAllLines(loadFile).Length;


            using (CsvReader csv = new CsvReader(new StreamReader(loadFile, Encoding.UTF8), false))  
            {
                string title = string.Format("正在从文本文件“{0}”导入手机号段信息，共（" + fileCount.ToString() + "条）." ,Path.GetFileName(loadFile));

                SetTitle(title, fileCount);

                rowCounts = fileCount;

                //只进的游标读取  

                HashSet<string> phonePrefixs = SystemPhoneAreaWrapper.GetAllPhonePrefix();

                while (csv.ReadNextRecord())
                {
                    if (bgwLoadPhoneData.CancellationPending)
                        break;

                    try
                    {
                        bgwLoadPhoneData.ReportProgress(Convert.ToInt32(csv[0]), fileCount);

                        string phonePrefix = csv[1];

                        if (string.IsNullOrEmpty(phonePrefix))
                        {
                            rowSuccessCounts++;

                            this.Invoke(new Action(delegate()
                            {
                                this.lblProcessProgress.Text = "号码数据导入中（ " + Convert.ToInt32(csv[0]) + "/" + fileCount.ToString() + "）。。。";
                            }));

                            continue;
                        }
                        

                        if (phonePrefixs.Contains(phonePrefix))
                        {
                            rowSuccessCounts++;

                            this.Invoke(new Action(delegate()
                            {
                                this.lblProcessProgress.Text = "号码数据导入中（ " + Convert.ToInt32(csv[0]) + "/" + fileCount.ToString() + "）。。。";
                            }));

                            continue;
                        }

                        SystemPhoneAreaWrapper sytemPhoneArea = new SystemPhoneAreaWrapper();

                        sytemPhoneArea.PhonePrefix = phonePrefix;
                        sytemPhoneArea.Province = csv[2].Split((" ").ToArray())[0];
                        sytemPhoneArea.City = csv[2].Split((" ").ToArray())[1];

                        string cardName = csv[3];

                        string operatorType = "";
                        string cardType = "";
                        string[] cardNames = null;


                        if (cardName.Contains("移动"))
                        {
                            operatorType = "移动";
                            cardNames = cardName.Split(("移动").ToArray());
                            cardType = cardNames[cardNames.Length-1];
                        }
                        else if (cardName.Contains("联通"))
                        {
                            operatorType = "联通";
                            cardNames = cardName.Split(("联通").ToArray());
                            cardType = cardNames[cardNames.Length - 1];
                        }
                        else if (cardName.Contains("电信"))
                        {
                            operatorType = "电信";
                            cardNames = cardName.Split(("电信").ToArray());
                            cardType = cardNames[cardNames.Length - 1];
                        }

                        sytemPhoneArea.OperatorType = operatorType;
                        sytemPhoneArea.CardType = cardType;
                        sytemPhoneArea.AreaCode = csv[4];
                        sytemPhoneArea.ZipCode = csv[5];

                        SystemPhoneAreaWrapper.Save(sytemPhoneArea);

                        rowSuccessCounts++;
 
                        this.Invoke(new Action(delegate()
                        {
                            this.lblProcessProgress.Text = "号码数据导入中（ " + Convert.ToInt32(csv[0]) + "/" + fileCount.ToString() + "）。。。";
                        }));
          
                    }
                    catch (Exception ex)
                    {
                       
                    }


                }  
            }  

            
        } 

        private void bgwLoadPhoneData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pgbProgress.Value = e.ProgressPercentage;
        }

        private void bgwLoadPhoneData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (this.InvokeRequired)
            //{
                this.lblProcessStatus.Text = "导入号码数据完成。。。";
                this.pgbProgress.Value = this.pgbProgress.Maximum;

                string title = string.Format("从文本文件“{0}”导入手机号段信息成功，成功的添加了{1}条号码段数据.", Path.GetFileName(filePath), rowSuccessCounts);

                this.Text = title;

                lblTitle.Text = title;

                this.btnCancel.Enabled = false;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgwLoadPhoneData.CancelAsync();
        }
    }
}
