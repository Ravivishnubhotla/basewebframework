<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="Common.Logging" %>
<%@ Import Namespace="LD.SPPipeManage.Bussiness.Commons" %>
<%@ Import Namespace="LD.SPPipeManage.Bussiness.Wrappers" %>
<%@ Import Namespace="Legendigital.Common.Web.AppClass" %>
<script runat="server">
    protected static ILog logger = LogManager.GetLogger(typeof(SPRecievedHandler));
    private bool saveLogFailedRequestToDb = false;



    protected void Page_Load(object sender, EventArgs e)
    {
        this.Response.Clear();
        try
        {
            IHttpRequest httpRequest = new HttpGetPostRequest(this.Request);


            //检测是否存在ashx
            if (string.IsNullOrEmpty(httpRequest.RequestFileName))
            {
                LogWarnInfo(httpRequest, "请求失败：没有指定ashx路径。\n", 0, 0);

                return;
            }

            SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath("sphaotian");

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

            string xmlString = HttpXmlPostRequest.GetXmlPostValueFromRequest(this.Request);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            XmlNode msgTypeNodes = doc.SelectSingleNode("pwd_message_list/message_type");

            string msgType = msgTypeNodes.InnerText.Trim();

            XmlNodeList dataNodes = doc.SelectNodes("pwd_message_list/data/message");

            List<IHttpRequest> pRequests = new List<IHttpRequest>();

            foreach (XmlNode dataNode in dataNodes)
            {
                IHttpRequest newRequest = new HttpGetPostRequest(this.Request);
                
                newRequest.RequestParams.Clear();

                foreach (XmlNode subnode in dataNode.ChildNodes)
                {
                    newRequest.RequestParams.Add(subnode.Name.ToLower(), subnode.InnerText);
                }

                if (msgType.ToUpper() == "SMS_PT")
                {
		            if (newRequest.RequestParams["linkid"]==null)
		            {
			            newRequest.RequestParams.Add("linkid",newRequest.RequestParams["msgid"]);
		            }
		            else
		            {
			            newRequest.RequestParams["linkid"]=newRequest.RequestParams["msgid"];
		            }
                }
                
                pRequests.Add(newRequest);

            }

            bool requestOK = true;

            if (msgType.ToUpper() == "SMS_MO")
            {
                foreach (IHttpRequest request in pRequests)
                {
                    RequestError requestError1 = new RequestError();
                    
                    bool result = channel.ProcessStateRequest(request,out requestError1);

                    if (!result)
                    {
                        requestOK = requestOK && (requestError1.ErrorType == RequestErrorType.RepeatLinkID);
                    }   ;
                }
            }
            else if (msgType.ToUpper() == "SMS_PT")
            {
                foreach (IHttpRequest request in pRequests)
                {
                    if (request.RequestParams.ContainsKey(channel.StatParamsName) && request.RequestParams[channel.StatParamsName].ToString().ToLower() == channel.StatParamsValues.ToLower())
                    {
                        RequestError requestError1 = new RequestError();

                        bool result = channel.RecState(request, request.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);

                        if (!result)
                        {
                            requestOK = requestOK && (requestError1.ErrorType == RequestErrorType.RepeatLinkID);
                        }  
                    }
                }
            }


            if (requestOK)
            {
                this.Response.Write(channel.GetOkCode(httpRequest));
            }
            else
            {
                this.Response.Write(channel.GetFailedCode(httpRequest));
            }
        }
        catch (Exception ex)
        {
            try
            {
                IHttpRequest failRequest = new HttpGetPostRequest(this.Request);

                string errorMessage = "处理请求失败:\n错误信息：" + ex.Message;

                logger.Error(errorMessage + "\n请求信息:\n" + failRequest.RequestData, ex);

                if (saveLogFailedRequestToDb)
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