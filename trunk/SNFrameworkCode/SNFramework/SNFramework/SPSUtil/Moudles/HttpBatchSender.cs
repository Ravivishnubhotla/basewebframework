using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SPSUtil.AppCode;
using WeifenLuo.WinFormsUI.Docking;

namespace SPSUtil.Moudles
{
    public partial class HttpBatchSender : DockContent
    {
        public HttpBatchSender()
        {
            InitializeComponent();
        }

        private void tsTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbUrlSender":


                    frmTestSendTask frmSendTask = new frmTestSendTask();

                    if (frmSendTask.ShowDialog()==DialogResult.OK)
                    {
                        this.tsbUrlSender.Enabled = false;
                        this.tsbProgressBar.Visible = true;
                        this.tsbCancelProgress.Visible = true;

                        this.rtxtOutput.Clear();


                        //this.richTextBox1.a
                        bgwSenderUrl.RunWorkerAsync(frmSendTask.SendTask);

                    }



                    break;
            }
        }

 

        private void bgwSenderUrl_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = sender as BackgroundWorker;

            if (bgw == null)
                return;

            HttpGetSenderTask senderTask = e.Argument as HttpGetSenderTask;


            if (senderTask!=null)
            {
                for (int i = 0; i < senderTask.SendItems.Count; i++)
                {
                    if (bgw.CancellationPending)
                    {
                        e.Cancel = true;
                        bgwSenderUrl.ReportProgress(100, i);
                        break;
                    }
                    // Wait 100 milliseconds.
                    Thread.Sleep(100);

                    senderTask.SendItems[i].Process();
                    // Report progress.
                    bgwSenderUrl.ReportProgress(i * 100 / senderTask.SendItems.Count, senderTask.SendItems[i]);
                }

            }



        }

        
        private void bgwSenderUrl_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            this.tsbProgressBar.Value = e.ProgressPercentage;

            HttpGetSenderTaskItem senderTaskItem = e.UserState as HttpGetSenderTaskItem;

            if(senderTaskItem!=null)
            {
                this.rtxtOutput.AppendText(string.Format("处理第{0}条数据,请求地址{1}。\n", senderTaskItem.TaskIndex+1, senderTaskItem.SendUrl));

                if (senderTaskItem.Result.IsSuccess)
                {
                    this.rtxtOutput.AppendText(senderTaskItem.Result.Message);
                }
                else
                {
                    this.rtxtOutput.AppendText(senderTaskItem.Result.Message);
                }


                // Set the text.
                this.tsbMessage.Text = string.Format("请求发送中，完成进度{0}%", e.ProgressPercentage.ToString());
            }

             


        }

        private void bgwSenderUrl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.tsbUrlSender.Enabled = true;
            this.tsbProgressBar.Visible = false;
            this.tsbCancelProgress.Visible = false;

            if(e.Cancelled)
            {
                this.tsbMessage.Text = string.Format("请求发送取消。");
            }
  
        }

        private void tsbCancelProgress_ButtonClick(object sender, EventArgs e)
        {
            if(!bgwSenderUrl.CancellationPending)
                bgwSenderUrl.CancelAsync();
        }
    }
}
