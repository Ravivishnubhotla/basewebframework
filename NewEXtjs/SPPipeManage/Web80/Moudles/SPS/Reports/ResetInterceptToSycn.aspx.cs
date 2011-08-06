using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Logging;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.UrlSender;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ResetInterceptToSycn : System.Web.UI.Page
    {
        private ILog logger = LogManager.GetLogger(typeof(ResetInterceptToSycn));

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Ext.IsAjaxRequest)
                return;

            try
            {
                this.hidClientChannelID.Text = this.Request.QueryString["ClientChannelID"];

                RefreshPage();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        [AjaxMethod]
        public void RefreshPage()
        {
            try
            {
                int clientChannleID = Convert.ToInt32(this.hidClientChannelID.Text);
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);


                this.hidClientID.Text = obj.ClinetID.Id.ToString();
                this.hidChannelID.Text = obj.ChannelID.Id.ToString();
                this.lblChannleName.Text = obj.ChannelName;
                this.lblClientName.Text = obj.ClientName;

                int downCount = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(DateTime.Now.Date,
                                                                                      DateTime.Now.Date,
                                                                                      clientChannleID,
                                                                                      DataType.Down.ToString());

                int interceptCount = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(DateTime.Now.Date,
                                                                                           DateTime.Now.Date,
                                                                                           clientChannleID,
                                                                                           DataType.Intercept.ToString());

                this.lblDownCount.Text = downCount.ToString();
                this.lblSycnCount.Text = interceptCount.ToString();
                this.btnResetIntercept.Disabled = !(obj.SyncData.HasValue && obj.SyncData.Value);

                int maxChangeCount = Convert.ToInt32(hidMaxChangeCount.Text);

                numMaxCount.MaxValue = Math.Min(interceptCount, maxChangeCount);
                numMaxCount.Text = Math.Min(interceptCount, Convert.ToInt32(numMaxCount.MaxValue)).ToString();

                SPClientChannelSettingWrapper clientChannelSetting =
                    SPClientChannelSettingWrapper.FindById(clientChannleID);

                if (!(clientChannelSetting.SyncData.HasValue && clientChannelSetting.SyncData.Value))
                {
                    btnResetIntercept.Disabled = true;
                }
                else
                {
                    btnResetIntercept.Disabled = false;
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

 

        protected const string SessionName_CurrentStep = "CurrentStepResetIntercept";
        protected const string SessionName_CurrentStepCount = "CurrentStepCountResetIntercept";

        public int CurrentStep
        {
            get
            {
                if (this.Session[SessionName_CurrentStep] == null)
                {
                    this.Session[SessionName_CurrentStep] = 0;
                }
                return (int)this.Session[SessionName_CurrentStep];
            }
            set
            {
                this.Session[SessionName_CurrentStep] = value;
            }
        }

        public int CurrentStepCount
        {
            get
            {
                if (this.Session[SessionName_CurrentStepCount] == null)
                {
                    this.Session[SessionName_CurrentStepCount] = 0;
                }
                return (int)this.Session[SessionName_CurrentStepCount];
            }
            set
            {
                this.Session[SessionName_CurrentStepCount] = value;
            }
        }

        protected void OnCancel(object sender, AjaxEventArgs e)
        {
            prgProcess.UpdateProgress(1f, "任务被取消");
            CurrentStep = -2;
        }

        protected void btnResetIntercept_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                CurrentStep = 0;
                CurrentStepCount = 0;
                prgProcess.Text = "";

                int clientChannleID = Convert.ToInt32(this.hidClientChannelID.Text);


                SPClientChannelSettingWrapper clientChannelSetting =
                    SPClientChannelSettingWrapper.FindById(clientChannleID);


                if (!(clientChannelSetting.SyncData.HasValue && clientChannelSetting.SyncData.Value))
                {
                    Ext.Msg.Alert("错误", "该通道无法同步数据");
                    winProgress.Hide();
                    return;
                }



                int maxChangeCount = Convert.ToInt32(hidMaxChangeCount.Text);

                int recordCount = 0;

                DataSet ds = SPPaymentInfoWrapper.FindAllPaymentIDByDateAndType(System.DateTime.Now.Date,
                                                                                System.DateTime.Now.Date,
                                                                                clientChannleID,
                                                                                DataType.Intercept.ToString(),
                                                                                maxChangeCount);

                List<UrlSendTask> tasks = new List<UrlSendTask>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SPPaymentInfoWrapper payment =
                        SPPaymentInfoWrapper.FindById(dr[SPPaymentInfoWrapper.PROPERTY_NAME_ID]);

                    if (payment != null && payment.IsIntercept.HasValue && payment.IsIntercept.Value)
                    {
                        payment.IsIntercept = false;
                        payment.IsSycnData = true;
                        payment.SycnRetryTimes = 0;
                        payment.SucesssToSend = false;


                        SPPaymentInfoWrapper.Update(payment);

                        tasks.Add(payment.BulidSendTask());


                    }


                }

                ThreadPool.QueueUserWorkItem(LongAction, tasks);
                ScriptManager1.AddScript("{0}.startTask('longactionprogress');", TaskManager1.ClientID);



            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        private void LongAction(object state)
        {

            if (!(state is List<UrlSendTask>))
                return;

            List<UrlSendTask> sendTasks = state as List<UrlSendTask>;

            CurrentStepCount = sendTasks.Count;

            for (int i = 0; i < sendTasks.Count; i++)
            {
                if (CurrentStep < 0)
                {
                    return;
                }

                UrlSender.SendRequest(sendTasks[i]);

                //hread.Sleep(3000);

                CurrentStep = i + 1;
            }
            CurrentStep = -1;
        }


        protected void RefreshProgress(object sender, AjaxEventArgs e)
        {
            int progress = CurrentStep;

            int maxCount = CurrentStepCount;

            if (progress >= 0)
            {
                prgProcess.UpdateProgress(Convert.ToSingle(progress) / Convert.ToSingle(maxCount), string.Format("任务处理中（{0}/{1})...", progress.ToString(), maxCount));
            }
            else if (progress == -2)
            {
                ScriptManager1.AddScript("{0}.stopTask('longactionprogress');", TaskManager1.ClientID);
                prgProcess.UpdateProgress(1, "任务被取消!");
            }
            else
            {
                ScriptManager1.AddScript("{0}.stopTask('longactionprogress');", TaskManager1.ClientID);
                prgProcess.UpdateProgress(1, "任务完成!");
            }
        }
    }
}