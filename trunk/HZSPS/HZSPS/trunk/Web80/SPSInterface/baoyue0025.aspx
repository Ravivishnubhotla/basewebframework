<%@ Page Language="C#" %>

<%@ Import Namespace="Common.Logging" %>
<%@ Import Namespace="LD.SPPipeManage.Bussiness.Commons" %>
<%@ Import Namespace="LD.SPPipeManage.Bussiness.Wrappers" %>
<%@ Import Namespace="Legendigital.Common.Web.AppClass" %>
<script runat="server">

    protected static ILog logger = LogManager.GetLogger(typeof(SPRecievedHandler));
    private bool saveLogFailedRequestToDb = false;
    public static byte[] ConvertHexToBytes(string value)
    {
        int len = value.Length / 2;
        byte[] ret = new byte[len];
        for (int i = 0; i < len; i++)
            ret[i] = (byte)(Convert.ToInt32(value.Substring(i * 2, 2), 16));
        return ret;
    }
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

            SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath("0025baoyue");

            bool isReportRequest = false;

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
                    
            if (httpRequest.RequestParams.ContainsKey("msg:"))
            {
                httpRequest.RequestParams["msg"] = Encoding.ASCII.GetString(ConvertHexToBytes(Request.Params["msg:"].Replace(" ","").Trim()));
            }
            else
            {
                httpRequest.RequestParams.Add("msg", Encoding.ASCII.GetString(ConvertHexToBytes(Request.Params["msg:"].Replace(" ","").Trim())));
            }


        
            
            if(httpRequest.RequestParams.ContainsKey("linkid"))
            {
                httpRequest.RequestParams["linkid"] = Request.Params["ItemId"] + Request.Params["UserNumber"];
            }
            else
            {
                httpRequest.RequestParams.Add("linkid", Request.Params["ItemId"] + Request.Params["UserNumber"]);
            }

            if (httpRequest.RequestParams.ContainsKey("spnumber"))
            {
                if (httpRequest.RequestParams["spnumber"]!=null && string.IsNullOrEmpty(httpRequest.RequestParams["spnumber"].ToString()))
                    httpRequest.RequestParams["spnumber"] = "10660025";
            }
            else
            {
                httpRequest.RequestParams.Add("spnumber", "10660025");
            }
 

            //if (httpRequest.RequestParams.ContainsKey("spnumber"))
            //{

            //}


            //httpRequest.RequestData = httpRequest.GetRequestData();



            //如果状态报告通道
            if (channel.RecStatReport.HasValue && channel.RecStatReport.Value)
            {
                RequestError requestError1 = new RequestError();

                bool result1 = false;

                //分类型请求
                if (channel.HasRequestTypeParams.HasValue && channel.HasRequestTypeParams.Value)
                {
                    //报告状态请求
                    if (httpRequest.IsRequestContainValues(channel.RequestTypeParamName, channel.RequestReportTypeValue))
                    {
                        if (httpRequest.IsRequestContainValues(channel.StatParamsName, channel.StatParamsValues))
                        {
                            isReportRequest = true;
                            result1 = channel.RecState(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                        }
                        else
                        {
                            //channel.SaveStatReport(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString());

                            this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));

                            return;
                        }
                    }
                    //发送数据请求
                    else if (httpRequest.IsRequestContainValues(channel.RequestTypeParamName, channel.RequestDataTypeValue))
                    {
                        result1 = channel.ProcessStateRequest(httpRequest, out requestError1);
                    }
                    else
                    {
                        LogWarnInfo(httpRequest, "未知类型请求", channel.Id, 0);

                        this.Response.Write(channel.GetFailedCode(httpRequest));

                        return;
                    }
                }
                else
                {
                    if (httpRequest.RequestParams.ContainsKey(channel.StatParamsName.ToLower()))
                    {
                        if (httpRequest.IsRequestContainValues(channel.StatParamsName, channel.StatParamsValues))
                        {
                            if (channel.StatSendOnce.HasValue && channel.StatSendOnce.Value)
                            {
                                result1 = channel.ProcessRequest(httpRequest, out requestError1);
                            }
                            else
                            {
                                result1 = channel.RecState(httpRequest, httpRequest.RequestParams[channel.StatParamsName.ToLower()].ToString(), out requestError1);
                            }
                        }
                        else
                        {


                            this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));

                            return;
                        }
                    }
                    else
                    {
                        result1 = channel.ProcessStateRequest(httpRequest, out requestError1);
                    }
                }

                //正确数据返回OK
                if (result1)
                {
                    if (isReportRequest)
                    {
                        this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));
                        return;
                    }
                    this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));
                    return;
                }



                //重复数据返回OK
                if (requestError1.ErrorType == RequestErrorType.RepeatLinkID)
                {
                    logger.Warn(requestError1.ErrorMessage);
                    this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));
                    return;
                }

                //其他错误类型记录错误请求

                LogWarnInfo(httpRequest, requestError1.ErrorMessage, channel.Id, 0);

                this.Response.Write(channel.GetFailedCode(httpRequest));

                return;

            }

            RequestError requestError;

            bool result = channel.ProcessRequest(httpRequest, out requestError);

            if (result)
            {
                this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));

                return;
            }

            //重复数据返回OK
            if (requestError.ErrorType == RequestErrorType.RepeatLinkID)
            {
                logger.Warn(requestError.ErrorMessage);
                this.Response.Write(string.Format("received commandid={0}", this.Request["commandid"]));
                return;
            }

            LogWarnInfo(httpRequest, requestError.ErrorMessage, channel.Id, 0);

            this.Response.Write(channel.GetFailedCode(httpRequest));

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
