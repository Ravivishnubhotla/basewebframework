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
        public int GetAllClientChannelNeedSendDataCount()
        {
            List<SPSSendUrlEntity> sendUrlEntities = new List<SPSSendUrlEntity>();

            List<SPClientChannelSettingWrapper> allNeedResendChannleClientSetting = SPClientChannelSettingWrapper.GetAllNeedRendSetting();

            foreach (SPClientChannelSettingWrapper channelSetting in allNeedResendChannleClientSetting)
            {
                List<SPPaymentInfoWrapper> spReSendPaymentInfos = SPPaymentInfoWrapper.FindAllNotSendData(channelSetting.ChannelID.Id,
                                                                                     channelSetting.ClinetID.Id, System.DateTime.Now.Date,
                                                                                     System.DateTime.Now.Date);

                foreach (SPPaymentInfoWrapper reSendPaymentInfo in spReSendPaymentInfos)
                {
                    SPSSendUrlEntity sendUrlEntity = new SPSSendUrlEntity();
                    sendUrlEntity.PaymentID = reSendPaymentInfo.Id;
                    sendUrlEntity.ClientID = channelSetting.ClinetID.Id;
                    sendUrlEntity.ChannelID = channelSetting.ChannelID.Id;
                    sendUrlEntity.SycnRetryTimes = (reSendPaymentInfo.SycnRetryTimes.HasValue
                                                        ? reSendPaymentInfo.SycnRetryTimes.Value
                                                        : 0);
                    sendUrlEntity.SendUrl = reSendPaymentInfo.ReBuildUrl();

                    sendUrlEntities.Add(sendUrlEntity);
                }
            }

            return sendUrlEntities.Count;

        }

        [WebMethod]
        public List<SPSSendUrlEntity> GetAllClientChannelNeedSendData()
        {
            List<SPSSendUrlEntity> sendUrlEntities = new List<SPSSendUrlEntity>();

            List<SPClientChannelSettingWrapper> allNeedResendChannleClientSetting = SPClientChannelSettingWrapper.GetAllNeedRendSetting();

            foreach (SPClientChannelSettingWrapper channelSetting in allNeedResendChannleClientSetting)
            {
                List<SPPaymentInfoWrapper> spReSendPaymentInfos = SPPaymentInfoWrapper.FindAllNotSendData(channelSetting.ChannelID.Id,
                                                                                     channelSetting.ClinetID.Id, System.DateTime.Now.Date,
                                                                                     System.DateTime.Now.Date);

                foreach (SPPaymentInfoWrapper reSendPaymentInfo in spReSendPaymentInfos)
                {
                    SPSSendUrlEntity sendUrlEntity = new SPSSendUrlEntity();
                    sendUrlEntity.PaymentID = reSendPaymentInfo.Id;
                    sendUrlEntity.ClientID = channelSetting.ClinetID.Id;
                    sendUrlEntity.ChannelID = channelSetting.ChannelID.Id;
                    sendUrlEntity.SycnRetryTimes = (reSendPaymentInfo.SycnRetryTimes.HasValue
                                                        ? reSendPaymentInfo.SycnRetryTimes.Value
                                                        : 0);
                    sendUrlEntity.SendUrl = reSendPaymentInfo.ReBuildUrl();

                    sendUrlEntities.Add(sendUrlEntity);
                }
            }

            return sendUrlEntities;
        }

        [WebMethod]
        public void UpdatePaymentSend(int id, bool isSendOk, string sendUrl, int sycnRetryTimes)
        {
            SPPaymentInfoWrapper spPaymentInfoWrapper = SPPaymentInfoWrapper.FindById(id);

            spPaymentInfoWrapper.SucesssToSend = isSendOk;

            spPaymentInfoWrapper.IsSycnData = true;

            spPaymentInfoWrapper.SSycnDataUrl = sendUrl;

            spPaymentInfoWrapper.SycnRetryTimes = sycnRetryTimes;

            SPPaymentInfoWrapper.Update(spPaymentInfoWrapper);
        }
    }
}
