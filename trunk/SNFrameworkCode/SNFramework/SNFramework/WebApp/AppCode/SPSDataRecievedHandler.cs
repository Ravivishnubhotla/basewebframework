using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using SPS.Bussiness.ConstClass;
using SPS.Bussiness.DataAdapter;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.AppCode
{
    public class SPSDataRecievedHandler : DataRecievedHandler
    {
        protected override void PreProcessRequest(IDataAdapter httpRequestLog)
        {
            return;
        }

        protected override RequestErrorType RecievedRequest(IDataAdapter httpRequestLog, SPChannelWrapper channel,
                                                        out bool requestOK, out string errorMessage)
        {
            RequestType requestType = channel.GetRequestType(httpRequestLog);

            RequestErrorType requestError = RequestErrorType.NoError;

            errorMessage = "";

            requestOK = false;

            if (requestType == RequestType.DataReport)
            {
                bool statusOk = true;

                if (channel.IsStateReport &&
                    (channel.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key ||
                     channel.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwice_Key))
                {
                    statusOk = false;
                }

                requestOK = channel.ProcessRequest(httpRequestLog, statusOk, out requestError, out errorMessage);
            }
            else if (requestType == RequestType.StatusReport)
            {
                bool statusOk = channel.GetStatus(httpRequestLog);

                requestOK = channel.ProcessStatusReport(httpRequestLog, statusOk, out requestError, out errorMessage);
            }
            else if (requestType == RequestType.DataStatusReport)
            {
                bool statusOk = channel.GetStatus(httpRequestLog);

                requestOK = channel.ProcessRequest(httpRequestLog, statusOk, out requestError, out errorMessage);
            }
            return requestError;
        }
    }
}
