using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SPSUtil.AppCode;

namespace SPSUtil.Moudles
{
    public partial class FrmPhoneDataToNoSQL : Form
    {
        public FrmPhoneDataToNoSQL()
        {
            InitializeComponent();
        }

        protected int rowCounts;
        protected int rowSuccessCounts;

        private void FrmPhoneDataToNoSQL_Shown(object sender, EventArgs e)
        {
            string title = string.Format("正在数据库导入手机号段信息到NoSQL.");

            this.Text = title;

            lblTitle.Text = title;

            this.lblProcessStatus.Text = "数据库数据读取中。。。";

            bgwDataToNoSQL.RunWorkerAsync();
        }


        public void SetTitle(string text, int fileCount)
        {

            this.Invoke(new Action(delegate()
            {
                this.Text = text;
                this.lblTitle.Text = text;
                this.lblProcessStatus.Text = "开始导入号码数据。。。";
                this.pgbProgress.Maximum = fileCount;
                this.pgbProgress.Minimum = 0;
            }));

        }

        private void bgwDataToNoSQL_DoWork(object sender, DoWorkEventArgs doWorkEventArg)
        {
            List<SystemPhoneAreaWrapper> phoneAreaWrappers = SystemPhoneAreaWrapper.FindAll();

            rowCounts = phoneAreaWrappers.Count;

            string title = string.Format("正在从数据库导入手机号段信息，共（" + rowCounts.ToString() + "条）.");

            SetTitle(title, rowCounts);

            var client = new MongoClient(Program.NoSQL_DBConnString);
         
            var server = client.GetServer();

            var database = server.GetDatabase(Program.NoSQL_DbName);

            var collection = database.GetCollection(Program.NoSQL_CollectionName);

            int i = 0;

            foreach (SystemPhoneAreaWrapper phoneAreaWrapper in phoneAreaWrappers)
            {
                i++;

                if (bgwDataToNoSQL.CancellationPending)
                    break;

                bgwDataToNoSQL.ReportProgress(i, rowCounts);

                ////var query = Query<PhoneArea>.EQ(e => e.PhonePrefix, phoneAreaWrapper.PhonePrefix);

                ////if (collection.FindOne(query) != null)
                ////{
                ////    this.Invoke(new Action(delegate()
                ////    {
                ////        this.lblProcessProgress.Text = "号码数据导入中（ " + i.ToString() + "/" + rowCounts.ToString() + "）。。。";
                ////    }));

                ////    continue;
                ////}
                

                var entity = new PhoneArea()
                                 {
                                     PhonePrefix = phoneAreaWrapper.PhonePrefix,
                                     Province = phoneAreaWrapper.Province,
                                     City = phoneAreaWrapper.City,
                                     OperatorType = phoneAreaWrapper.OperatorType,
                                 };

                MongoInsertOptions mongoInsert = new MongoInsertOptions() { WriteConcern = WriteConcern.Unacknowledged };

                rowSuccessCounts++;

                this.Invoke(new Action(delegate()
                {
                    this.lblProcessProgress.Text = "号码数据导入中（ " + i.ToString() + "/" + rowCounts.ToString() + "）。。。";
                }));

                collection.Save(entity, mongoInsert);
            }
 
        }

        private void bgwDataToNoSQL_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pgbProgress.Value = e.ProgressPercentage;
        }

        private void bgwDataToNoSQL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblProcessStatus.Text = "导入号码数据完成。。。";
            this.pgbProgress.Value = this.pgbProgress.Maximum;

            string title = string.Format("从数据库导入手机号段信息成功，成功的添加了{0}条号码段数据.", rowSuccessCounts);

            this.Text = title;

            lblTitle.Text = title;

            this.btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgwDataToNoSQL.CancelAsync();
        }
    }
}
