using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.DataService
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
        public string GetAllSendTask(DateTime startDate, DateTime endDate,int? clientID,int codeID)
        {
            return "Hello World";
        }

        [WebMethod]
        public bool CheckPaymentNeedSend(int id)
        {
            SPRecordWrapper record = SPRecordWrapper.FindById(id);

            if (record == null)
                return false;

            if (record.IsIntercept)
            {
                return false;
            }

            if (record.IsSycnSuccessed)
            {
                return false;
            }

            if (record.SycnRetryTimes > 1)
            {
                return false;
            }

            return true;
        }


        [WebMethod]
        public void UpdatePaymentSend(int id, bool isSendOk, string sendUrl,string responseMessage, int sycnRetryTimes)
        {
            SPRecordWrapper record = SPRecordWrapper.FindById(id);

            if (record==null)
                return;

            if (record.IsIntercept)
                return;

            if (isSendOk)
                record.IsSycnSuccessed = isSendOk;

            record.IsSycnToClient = true;

            record.SycnRetryTimes = sycnRetryTimes;

            SPRecordWrapper.Update(record);

            record.ExtendInfo.SSycnDataUrl = sendUrl;
            record.ExtendInfo.SSycnDataFailedMessage = responseMessage;

            SPRecordExtendInfoWrapper.Update(record.ExtendInfo);

 
 
        }
    }
}
