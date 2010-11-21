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
        public List<SPSSendUrlEntity> GetAllClientChannelNeedSendData(int maxDataCount, int maxAllDataCount)
        {
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

                    if(dataCount>=maxAllDataCount)
                        return sendUrlEntities;


                }
            }

            return sendUrlEntities;
        }



        [WebMethod]
        public List<SPSSendUrlEntity> GetAllClientChannelNeedSendHistoryData(int maxDataCount, int maxAllDataCount,DateTime startDate,DateTime endDate)
        {
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
    }
}
