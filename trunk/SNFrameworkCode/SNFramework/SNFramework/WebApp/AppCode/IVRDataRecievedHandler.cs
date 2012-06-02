using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using SPS.Bussiness.DataAdapter;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.AppCode
{
    public class IVRDataRecievedHandler : DataRecievedHandler
    {
        protected override void PreProcessRequest(IDataAdapter httpRequestLog)
        {
            return;
        }

        protected override RequestErrorType RecievedRequest(IDataAdapter httpRequestLog, SPChannelWrapper channel, out bool requestOK, out string errorMessage)
        {
            RequestType requestType = channel.GetRequestType(httpRequestLog);

            RequestErrorType requestError = RequestErrorType.NoError;

            errorMessage = "";

            requestOK = false;

            int feetime = Convert.ToInt32(channel.GetFeetime(httpRequestLog));

            string linkid = channel.GetLinkID(httpRequestLog);

            bool statusOk = true;

 
            if (requestType == RequestType.DataStatusReport)
            {
                statusOk = channel.GetStatus(httpRequestLog);
            }

            if (statusOk == false)
            {
                requestOK = true;
                return requestError;
            }


            for (int i = 0; i < feetime; i++)
            {
                IDataAdapter request = new HttpGetPostAdapter(httpRequestLog);

                request.RequestParams[channel.ChannelParams[DictionaryConst.Dictionary_SPField_LinkID_Key]] = linkid + "-" + i.ToString();

                requestOK = channel.ProcessRequest(httpRequestLog, statusOk, out requestError, out errorMessage);
            }

            return requestError;
        }
    }
}