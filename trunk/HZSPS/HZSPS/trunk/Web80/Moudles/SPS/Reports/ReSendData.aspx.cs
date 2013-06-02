using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using Common.Logging;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.UrlSender;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
 
namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ReSendData : PageResend
    {
        private ILog logger = LogManager.GetLogger(typeof(ReSendData));

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

            int clientChannleID = Convert.ToInt32(this.Request.QueryString["ClientChannelID"]);

            SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);


            this.lblChannleName.Text = obj.ChannelName;
            this.lblClientName.Text = obj.ClientName;


            int downCount = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                                            System.DateTime.Now.Date,
                                                            clientChannleID,
                                                            DataType.Down.ToString());

            int downSycnCount = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                                            System.DateTime.Now.Date,
                                                            clientChannleID,
                                                            DataType.DownSycn.ToString());


            int downNotSycn = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                            System.DateTime.Now.Date,
                                            clientChannleID,
                                            DataType.DownNotSycn.ToString());

            int sycnFailed = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                            System.DateTime.Now.Date,
                            clientChannleID,
                            DataType.SycnFailed.ToString());



            this.lblDownCount.Text = downCount.ToString();
            this.lblSycnCount.Text = downSycnCount.ToString();
            this.lblDownNotSycnCount.Text = downNotSycn.ToString();
            this.lblSycnFailedCount.Text = sycnFailed.ToString();

            this.btnReSendDown.Disabled = (downCount <= 0);
            this.btnReSendSycn.Disabled = (downSycnCount <= 0);
            this.btnReSendDownNotSycn.Disabled = (downNotSycn <= 0);
            this.btnReSendSycnFailed.Disabled = (sycnFailed <= 0);
        }

 

        protected void btnReSendDown_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                ReSendPayment(DataType.Down.ToString());
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnReSendDownNotSycn_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                ReSendPayment(DataType.DownNotSycn.ToString());
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnReSendSycn_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                ReSendPayment(DataType.DownSycn.ToString());
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnReSendSycnFailed_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                ReSendPayment(DataType.SycnFailed.ToString());
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        private void ReSendPayment(string dataType)
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
                prgProcess.Hide();
                return;
            }


            int maxChangeCount = Convert.ToInt32(hidMaxChangeCount.Text);

            int recordCount = 0;

            DataSet ds = SPPaymentInfoWrapper.FindAllPaymentIDByDateAndType(System.DateTime.Now.Date,
                                                                            System.DateTime.Now.Date,
                                                                            clientChannleID,
                                                                            dataType,
                                                                            maxChangeCount);

            List<UrlSendTask> tasks = new List<UrlSendTask>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SPPaymentInfoWrapper payment =
                    SPPaymentInfoWrapper.FindById(dr[SPPaymentInfoWrapper.PROPERTY_NAME_ID]);



                if (payment != null && CheckPaymentIsDataType(payment, dataType))
                {
                    payment.IsIntercept = false;
                    payment.IsSycnData = true;
                    payment.SycnRetryTimes = 0;
                    payment.SucesssToSend = false;


                    SPPaymentInfoWrapper.Update(payment);

                    tasks.Add(payment.BulidSendTask());
                }
            }

            if (tasks.Count <= 0)
            {
                Ext.Msg.Alert("错误", "没有需要重发的数据");
                prgProcess.Hide();
                return;
            }

            ThreadPool.QueueUserWorkItem(LongAction, tasks);
            ScriptManager1.AddScript("{0}.startTask('longactionprogress');", TaskManager2.ClientID);
        }

        private bool CheckPaymentIsDataType(SPPaymentInfoWrapper payment, string dataType)
        {
            if (dataType == DataType.Down.ToString())
            {
                if (payment.IsIntercept.HasValue && !payment.IsIntercept.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (dataType == DataType.DownNotSycn.ToString())
            {
                if (payment.IsIntercept.HasValue && !payment.IsIntercept.Value && payment.IsSycnData.HasValue && !payment.IsSycnData.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (dataType == DataType.DownSycn.ToString())
            {
                if (payment.IsIntercept.HasValue && !payment.IsIntercept.Value && payment.SucesssToSend.HasValue && payment.SucesssToSend.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (dataType == DataType.SycnFailed.ToString())
            {
                if (payment.IsIntercept.HasValue && !payment.IsIntercept.Value && payment.SucesssToSend.HasValue && !payment.SucesssToSend.Value && payment.IsSycnData.HasValue && payment.IsSycnData.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override string GetSessionName_CurrentStep()
        {
            return "Session_Name_ReSend_CurrentStep";
        }

        public override string GetSessionName_CurrentStepCount()
        {
            return "Session_Name_ReSend_CurrentStepCount";
        }

        public override ProgressBar GetControl_ProgressBar()
        {
            return prgProcess;
        }

        public override ScriptManagerProxy GetControl_ScriptManager()
        {
            return ScriptManager1;
        }


        public override TaskManager GetControl_TaskManager()
        {
            return TaskManager2;
        }

        public override void ExecuteLongAction(object state)
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

                CurrentStep = i + 1;
            }
            CurrentStep = -1;
        }
    }
}