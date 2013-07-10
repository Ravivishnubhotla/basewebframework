<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Common.Logging" %>
<%@ Import Namespace="LD.SPPipeManage.Bussiness.Commons" %>
<%@ Import Namespace="LD.SPPipeManage.Bussiness.Wrappers" %>
<%@ Import Namespace="Legendigital.Common.Web.AppClass" %>

<script runat="server">

    protected static ILog logger = LogManager.GetLogger(typeof(SPRecievedHandler));
    private bool saveLogFailedRequestToDb = false;
    private string xmlString = string.Empty;


    public static string GetXmlPostValueFromRequest(HttpRequest request)
    {
        StringBuilder fileContent = new StringBuilder();

        using (StreamReader sr = new StreamReader(request.InputStream, Encoding.GetEncoding("gb2312")))
        {

            fileContent.Append(sr.ReadToEnd());
            sr.Close();
        }

        return fileContent.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Response.Clear();
        try
        {


            xmlString = GetXmlPostValueFromRequest(this.Request);

            IHttpRequest httpRequest = new HttpXmlPostRequest(this.Request, xmlString, "ResultCode");

            SPChannelWrapper channel = SPChannelWrapper.FindByAlias("yaSMS");

            //如果没有找到通道
            if (channel == null)
            {
                LogWarnInfo(httpRequest, "处理请求失败：无法找到对应的通道。\n", 0, 0);

                return;
            }

            saveLogFailedRequestToDb = channel.LogFailedRequestToDb;

            //如果通道未能运行
            if (channel.CStatus != ChannelStatus.Run)
            {
                LogWarnInfo(httpRequest, "请求失败：\n" + "通道“" + channel.Name + "”未运行。\n", channel.Id, 0);

                this.Response.Write(channel.GetFailedCode(httpRequest));

                return;
            }
            //如果通道是监视通道，记录请求。
            if (channel.IsMonitoringRequest.HasValue && channel.IsMonitoringRequest.Value)
            {
                SPMonitoringRequestWrapper.SaveRequest(httpRequest, channel.Id);
            }

            RequestError requestError1 = new RequestError();

            bool result1 = false;


            string linkid = httpRequest.RequestParams["MobileNo"].ToString() + httpRequest.RequestParams["OccurTime"].ToString().Replace(" ", "").Replace(":", "");

            if (httpRequest.RequestParams["linkid"] == null)
		    {
                httpRequest.RequestParams.Add("linkid", linkid);
		    }
		    else
		    {
                httpRequest.RequestParams["linkid"] = linkid;
		    }

            result1 = channel.ProcessRequest(httpRequest, out requestError1);



            //正确数据返回OK
            if (result1)
            {
 
                Response.Write(channel.GetOkCode(httpRequest));
                return;
            }

            //重复数据返回OK
            if (requestError1.ErrorType == RequestErrorType.RepeatLinkID)
            {
 
                logger.Warn(requestError1.ErrorMessage);
                Response.Write(channel.GetOkCode(httpRequest));
                return;
            }

            //其他错误类型记录错误请求
 
            LogWarnInfo(httpRequest, requestError1.ErrorMessage, channel.Id, 0);

            Response.Write(channel.GetFailedCode(httpRequest));

            return;




        }
        catch (Exception ex)
        {
	    Response.Write(ex.Message);	
            try
            {
                IHttpRequest failRequest = new HttpGetPostRequest(Request);

                string errorMessage = "处理请求失败:\n错误信息：" + ex.Message;

                logger.Error(errorMessage + "\n请求信息:\n" + failRequest.RequestData, ex);

                if (1==1)
                    SPFailedRequestWrapper.SaveFailedRequest(failRequest, errorMessage, 0, 0);
            }
            catch (Exception exx)
            {
                logger.Error("处理请求失败:\n错误信息：" + exx.Message);
            }
        }


 



    }


    private void LogWarnInfo(IHttpRequest httpRequest, string errorInfo, int channelID, int clientID)
    {
        logger.Warn(errorInfo + "请求信息：\n" + httpRequest.RequestData);

        if (saveLogFailedRequestToDb)
            SPFailedRequestWrapper.SaveFailedRequest(httpRequest, errorInfo, channelID, clientID);
    }
</script>
