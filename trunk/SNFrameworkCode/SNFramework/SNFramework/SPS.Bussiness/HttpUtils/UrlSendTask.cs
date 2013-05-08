using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPS.Bussiness.HttpUtils
{
    [Serializable]
    public class UrlSendTask
    {
        public string DataOkMessage { get; set; }
        public string SendDataUrl { get; set; }
        public string ReportOkMessage { get; set; }
        public string SendReportUrl { get; set; }
        public string Host { get; set; }
        public int ClientID { get; set; }
        public int RecordID { get; set; }

        public const string char_lineSpit = "{$SplitTag}";

        public string ToFileLine()
        {
            StringBuilder sbLine = new StringBuilder();

            sbLine.Append(SendDataUrl + char_lineSpit);
            sbLine.Append(DataOkMessage + char_lineSpit);
            sbLine.Append(SendReportUrl + char_lineSpit);
            sbLine.Append(ReportOkMessage + char_lineSpit);
            sbLine.Append(RecordID);

            return sbLine.ToString();
        }


        public void FromFileLine(string lineText)
        {
            lineText = lineText.Trim();

            string[] splits = lineText.Split(char_lineSpit.ToCharArray());

            SendDataUrl = splits[0];
            DataOkMessage = splits[1];
            SendReportUrl = splits[2];
            ReportOkMessage = splits[3];
            RecordID = Convert.ToInt32(splits[4]);
        }

        public string GetHost()
        {
            Uri uri = new Uri(SendDataUrl);

            return uri.Host;
        }
    }
}
