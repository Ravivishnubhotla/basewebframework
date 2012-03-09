using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SPSUtil.AppCode
{
    [Serializable]
    public class ChannelSendSettings
    {
        public const string ParamsPrefix = "ZXCVBNMAS";
        public const string ParamsSubfix = "OPIUYTREWQ";
        public string SubmitSendUrl { get; set; }
        public string ParamsLinkidName { get; set; }
        public string ParamsLinkidValue { get; set; }
        public string ParamsMoName { get; set; }
        public string ParamsMoValue { get; set; }
        public string ParamsSPCodeName { get; set; }
        public string ParamsSPCodeValue { get; set; }
        public string ParamsMobileName { get; set; }
        public string ParamsMobileValue { get; set; }
        public bool IsStatusReport { get; set; }
        public int RequestType { get; set; }
        public string ParamsStatusName { get; set; }
        public string ParamsStatusValue { get; set; }
        public string ParamsRequestTypeName { get; set; }
        public string ParamsRequestTypeDataValue { get; set; }
        public string ParamsRequestTypeReportValue { get; set; }
        public Hashtable DataUrlParams { get; set; }
        private string dataUrl = null;

        public string DataUrl
        {
            get
            {
                if(dataUrl==null)
                {
                    dataUrl = BuildDataUrl();
                }

                DataUrlParams = new Hashtable();

                Regex regex = new Regex(@"(?<=" + ParamsPrefix + @").*?(?=" + ParamsSubfix + @")");

                MatchCollection mc = regex.Matches(dataUrl);

                foreach (Match match in mc)
                {
                    if (!DataUrlParams.Contains(ParamsPrefix + match.Value + ParamsSubfix))
                    {
                        DataUrlParams.Add(ParamsPrefix + match.Value + ParamsSubfix, Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 1)));
                    }
                }

                return dataUrl;
            }
        }




        private string BuildDataUrl()
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(ParamsLinkidName, ParamsLinkidValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
            queryString.Add(ParamsMoName, ParamsMoValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
            queryString.Add(ParamsSPCodeName, ParamsSPCodeValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
            queryString.Add(ParamsMobileName, ParamsMobileValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));

            if(IsStatusReport)
            {
                if (RequestType==0)
                {
                    queryString.Add(ParamsStatusName, ParamsRequestTypeReportValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
                }
                else if (RequestType == 2)
                {
                    queryString.Add(ParamsRequestTypeName, ParamsRequestTypeDataValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
                }
            }

            Uri uri = new Uri(this.SubmitSendUrl);

            if (string.IsNullOrEmpty(queryString.ToString()))
            {
                return this.SubmitSendUrl;
            }

            if (!string.IsNullOrEmpty(uri.Query.Trim()))
                return string.Format("{0}&{1}", this.SubmitSendUrl, queryString.ToString());

            return string.Format("{0}?{1}", this.SubmitSendUrl, queryString.ToString());
        }

        private string BuildReportUrl()
        {
            if (!IsStatusReport)
                return "";


            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString.Add(ParamsLinkidName, ParamsLinkidValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
 
            if (RequestType == 1)
            {
                queryString.Add(ParamsStatusName, ParamsRequestTypeReportValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
            }
            else if (RequestType == 2)
            {
                queryString.Add(ParamsStatusName, ParamsRequestTypeReportValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
                queryString.Add(ParamsRequestTypeName, ParamsRequestTypeReportValue.Replace("{$", ParamsPrefix).Replace("}", ParamsSubfix));
            }
 

            Uri uri = new Uri(this.SubmitSendUrl);

            if (string.IsNullOrEmpty(queryString.ToString()))
            {
                return this.SubmitSendUrl;
            }

            if (!string.IsNullOrEmpty(uri.Query.Trim()))
                return string.Format("{0}&{1}", this.SubmitSendUrl, queryString.ToString());

            return string.Format("{0}?{1}", this.SubmitSendUrl, queryString.ToString());
        }

    }
}
