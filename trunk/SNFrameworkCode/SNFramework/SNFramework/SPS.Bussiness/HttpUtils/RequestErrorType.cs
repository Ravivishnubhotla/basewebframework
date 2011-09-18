using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.HttpUtils
{
    public enum RequestErrorType
    {
        NoError,
        NoLinkID,
        RepeatLinkID,
        NoChannelClientSetting,
        DataSaveError,
        NoReportData
    }
}
