using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.MobileControls;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Services
{
    /// <summary>
    /// Summary description for SPDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SPDataService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Connect()
        {
            return true;
        }

        [WebMethod]
        public string GetAllClientChannelSendWebDomain(int clientChannleID)
        {
            SPClientChannelSettingWrapper channelSettingWrapper = SPClientChannelSettingWrapper.FindById(clientChannleID);

            if (channelSettingWrapper == null)
                return "";

            if (string.IsNullOrEmpty(channelSettingWrapper.SyncDataUrl))
                return "";

            Uri uri = new Uri(channelSettingWrapper.SyncDataUrl);

            return uri.Host;
        }

        [WebMethod]
        public int[] GetGetAllClientChannelIDNeed(DateTime startDate, DateTime endDate)
        {
            this.Server.ScriptTimeout = 360;
            return SPPaymentInfoWrapper.GetGetAllClientChannelIDNeed(startDate.Date, endDate.Date);
        }

        [WebMethod]
        public List<SPSSendUrlEntity> GetSSendUrlByClientChannelIDAndDate(DateTime startDate, DateTime endDate, int ClientChannelID, int maxRetryCount)
        {
            this.Server.ScriptTimeout = 360;

            List<SPPaymentInfoWrapper> spReSendPaymentInfos = SPPaymentInfoWrapper.FindAllNotSendData(ClientChannelID, startDate.Date, endDate.Date, maxRetryCount);

            return ChangePaymentToUrl(spReSendPaymentInfos);
        }

        private List<SPSSendUrlEntity> ChangePaymentToUrl(List<SPPaymentInfoWrapper> spReSendPaymentInfos)
        {
            List<SPSSendUrlEntity> sendUrlEntities = new List<SPSSendUrlEntity>();

            foreach (SPPaymentInfoWrapper reSendPaymentInfo in spReSendPaymentInfos)
            {
                if (!reSendPaymentInfo.IsIntercept.HasValue)
                    continue;

                if (reSendPaymentInfo.IsIntercept.Value)
                    continue;


                SPSSendUrlEntity sendUrlEntity = PaymentToSendUrlEntity(reSendPaymentInfo);

                sendUrlEntities.Add(sendUrlEntity);
            }

            return sendUrlEntities;
        }

        [WebMethod]
        public List<SPSSendUrlEntity> GetAllClientChannelNeedSendData(int maxDataCount, int maxAllDataCount)
        {
            this.Server.ScriptTimeout = 360;

            List<SPSSendUrlEntity> sendUrlEntities = new List<SPSSendUrlEntity>();

            List<SPClientChannelSettingWrapper> allNeedResendChannleClientSetting = SPClientChannelSettingWrapper.GetAllNeedRendSetting();

            int dataCount = 0;

            foreach (SPClientChannelSettingWrapper channelSetting in allNeedResendChannleClientSetting)
            {
                List<SPPaymentInfoWrapper> spReSendPaymentInfos = SPPaymentInfoWrapper.FindAllNotSendData(channelSetting.ChannelID.Id,
                                                                                     channelSetting.ClinetID.Id, System.DateTime.Now.Date,
                                                                                     System.DateTime.Now.Date, maxDataCount);

                foreach (SPPaymentInfoWrapper reSendPaymentInfo in spReSendPaymentInfos)
                {
                    if (!reSendPaymentInfo.IsIntercept.HasValue)
                        continue;

                    if (reSendPaymentInfo.IsIntercept.Value)
                        continue;

                    SPSSendUrlEntity sendUrlEntity = PaymentToSendUrlEntity(reSendPaymentInfo);

                    sendUrlEntities.Add(sendUrlEntity);

                    dataCount++;

                    if(dataCount>=maxAllDataCount)
                        return sendUrlEntities;
                }
            }

            return sendUrlEntities;
        }

        private SPSSendUrlEntity PaymentToSendUrlEntity(SPPaymentInfoWrapper reSendPaymentInfo)
        {
            SPSSendUrlEntity sendUrlEntity = new SPSSendUrlEntity();
            sendUrlEntity.PaymentID = reSendPaymentInfo.Id;
            sendUrlEntity.ClientID = reSendPaymentInfo.ClientID.Id;
            sendUrlEntity.ChannelID = reSendPaymentInfo.ChannelID.Id;
            sendUrlEntity.SycnRetryTimes = (reSendPaymentInfo.SycnRetryTimes.HasValue
                                                ? reSendPaymentInfo.SycnRetryTimes.Value
                                                : 0);
            sendUrlEntity.SendUrl = reSendPaymentInfo.ReBuildUrl();
            return sendUrlEntity;
        }


        [WebMethod]
        public List<SPSSendUrlEntity> GetAllClientChannelNeedSendHistoryData(int maxDataCount, int maxAllDataCount,DateTime startDate,DateTime endDate)
        {
            this.Server.ScriptTimeout = 360;

            List<SPSSendUrlEntity> sendUrlEntities = new List<SPSSendUrlEntity>();

            List<SPClientChannelSettingWrapper> allNeedResendChannleClientSetting = SPClientChannelSettingWrapper.GetAllNeedRendSetting();

            int dataCount = 0;

            DateTime startDateTime = startDate;

            if (startDate > System.DateTime.Now.AddDays(-1))
            {
                startDateTime = System.DateTime.Now.AddDays(-1);
            }
            DateTime endDateTime = endDate;

            if (endDate > System.DateTime.Now.AddDays(-1))
            {
                endDateTime = System.DateTime.Now.AddDays(-1);
            }

            foreach (SPClientChannelSettingWrapper channelSetting in allNeedResendChannleClientSetting)
            {
                List<SPPaymentInfoWrapper> spReSendPaymentInfos = SPPaymentInfoWrapper.FindAllNotSendData(channelSetting.ChannelID.Id,
                                                                                     channelSetting.ClinetID.Id, startDateTime.Date,
                                                                                     endDateTime.Date, maxDataCount);

                foreach (SPPaymentInfoWrapper reSendPaymentInfo in spReSendPaymentInfos)
                {
                    if (!reSendPaymentInfo.IsIntercept.HasValue)
                        continue;

                    if (reSendPaymentInfo.IsIntercept.Value)
                        continue;


                    SPSSendUrlEntity sendUrlEntity = new SPSSendUrlEntity();
                    sendUrlEntity.PaymentID = reSendPaymentInfo.Id;
                    sendUrlEntity.ClientID = channelSetting.ClinetID.Id;
                    sendUrlEntity.ChannelID = channelSetting.ChannelID.Id;
                    sendUrlEntity.SycnRetryTimes = (reSendPaymentInfo.SycnRetryTimes.HasValue
                                                        ? reSendPaymentInfo.SycnRetryTimes.Value
                                                        : 0);
                    sendUrlEntity.SendUrl = reSendPaymentInfo.ReBuildUrl();

                    sendUrlEntities.Add(sendUrlEntity);

                    dataCount++;

                    if (dataCount >= maxAllDataCount)
                        return sendUrlEntities;
                }
            }

            return sendUrlEntities;
        }


        [WebMethod]
        public bool CheckPaymentNeedSend(int id)
        {
            SPPaymentInfoWrapper spPaymentInfoWrapper = SPPaymentInfoWrapper.FindById(id);

            if(spPaymentInfoWrapper==null)
                return false;

            if (spPaymentInfoWrapper.IsIntercept.HasValue && spPaymentInfoWrapper.IsIntercept.Value)
            {
                return false;
            }

            if (spPaymentInfoWrapper.SucesssToSend.HasValue && spPaymentInfoWrapper.SucesssToSend.Value)
            {
                return false;
            }

            if (spPaymentInfoWrapper.SycnRetryTimes.HasValue && spPaymentInfoWrapper.SycnRetryTimes.Value>1)
            {
                return false;
            }

            return true;

        }


        [WebMethod]
        public void UpdatePaymentSend(int id, bool isSendOk, string sendUrl, int sycnRetryTimes)
        {
            SPPaymentInfoWrapper spPaymentInfoWrapper = SPPaymentInfoWrapper.FindById(id);

            if (spPaymentInfoWrapper.IsIntercept.HasValue && spPaymentInfoWrapper.IsIntercept.Value)
                return;

            if (isSendOk)
                spPaymentInfoWrapper.SucesssToSend = isSendOk;

            spPaymentInfoWrapper.IsSycnData = true;

            spPaymentInfoWrapper.SSycnDataUrl = sendUrl;

            spPaymentInfoWrapper.SycnRetryTimes = sycnRetryTimes;

            SPPaymentInfoWrapper.Update(spPaymentInfoWrapper);
        }

        [WebMethod]
        public void ReGenerateDayReportByDate(DateTime reportDate)
        {
            SPDayReportWrapper.ReGenerateDayReport(reportDate.Date);
        }

        [WebMethod]
        public void ReGenerateDayReportByDateRange(DateTime startDate,DateTime endDate)
        {
            SPDayReportWrapper.ReGenerateDayReport(startDate.Date, endDate.Date);
        }
    }
}
