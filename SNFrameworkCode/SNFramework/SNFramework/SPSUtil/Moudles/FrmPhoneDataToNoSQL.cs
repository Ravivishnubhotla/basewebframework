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

        private void bgwDataToNoSQL_DoWork(object sender, DoWorkEventArgs e)
        {
            List<SystemPhoneAreaWrapper> phoneAreaWrappers = SystemPhoneAreaWrapper.FindAll();

            rowCounts = phoneAreaWrappers.Count;

            string title = string.Format("正在从数据库导入手机号段信息，共（" + rowCounts.ToString() + "条）.");

            SetTitle(title, rowCounts);

            using (Mongo mongo = new Mongo(Program.NoSQL_DBConnString))
            {
                //获取databaseName对应的数据库，不存在则自动创建
                MongoDatabase mongoDatabase = mongo.GetDatabase(Program.NoSQL_DbName) as MongoDatabase;

                //获取collectionName对应的集合，不存在则自动创建
                MongoCollection<Document> mongoCollection = mongoDatabase.GetCollection<Document>(Program.NoSQL_CollectionName) as MongoCollection<Document>;

                //链接数据库
                mongo.Connect();

                int i = 0;

                foreach (SystemPhoneAreaWrapper phoneAreaWrapper in phoneAreaWrappers)
                {
                    i++;

                    Document findOne = new Document
                                           {
                                               {"PhonePrefix", phoneAreaWrapper.PhonePrefix}
                                           };

                    ////在集合中查找键值对为ID=1的文档对象
                    Document docFind = mongoCollection.FindOne(findOne);

                    if (docFind != null)
                    {
                        this.Invoke(new Action(delegate()
                        {
                            this.lblProcessProgress.Text = "号码数据导入中（ " + i.ToString() + "/" + rowCounts.ToString() + "）。。。";
                        }));
                        continue;
                    }
                    
                    Document documentInsert = new Document();
                    documentInsert["ID"] = System.Guid.NewGuid().ToString();
                    documentInsert["PhonePrefix"] = phoneAreaWrapper.PhonePrefix;
                    documentInsert["Province"] = phoneAreaWrapper.Province;
                    documentInsert["City"] = phoneAreaWrapper.City;
                    documentInsert["OperatorType"] = phoneAreaWrapper.OperatorType;

                    mongoCollection.Save(documentInsert,false);

                    rowSuccessCounts++;

                    this.Invoke(new Action(delegate()
                    {
                        this.lblProcessProgress.Text = "号码数据导入中（ " + i .ToString() + "/" + rowCounts.ToString() + "）。。。";
                    }));
 
                }

                mongo.Disconnect();
 
            }

            


        }

        private void bgwDataToNoSQL_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
