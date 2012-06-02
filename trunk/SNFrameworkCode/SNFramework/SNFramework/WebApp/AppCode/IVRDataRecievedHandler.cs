using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPS.Bussiness.DataAdapter;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.AppCode
{
    public class IVRDataRecievedHandler : DataRecievedHandler
    {
        protected override void PreProcessRequest(IDataAdapter httpRequestLog)
        {
            throw new NotImplementedException();
        }

        protected override RequestErrorType RecievedRequest(IDataAdapter httpRequestLog, SPChannelWrapper channel, out bool requestOK, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}