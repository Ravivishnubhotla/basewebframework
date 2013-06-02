<%@ Page Language="C#" %>

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
            IHttpRequest httpRequest = new HttpGetPostRequest(Request);

            SPChannelWrapper channel = SPChannelWrapper.FindByAlias("spzhocenivr");

            //���û���ҵ�ͨ��
            if (channel == null)
            {
                LogWarnInfo(httpRequest, "��������ʧ�ܣ��޷��ҵ���Ӧ��ͨ����\n", 0, 0);

                return;
            }

            saveLogFailedRequestToDb = channel.LogFailedRequestToDb;

            //���ͨ��δ������
            if (channel.CStatus != ChannelStatus.Run)
            {
                LogWarnInfo(httpRequest, "����ʧ�ܣ�\n" + "ͨ����" + channel.Name + "��δ���С�\n", channel.Id, 0);

                this.Response.Write(channel.GetFailedCode(httpRequest));

                return;
            }
            //���ͨ���Ǽ���ͨ������¼����
            if (channel.IsMonitoringRequest.HasValue && channel.IsMonitoringRequest.Value)
            {
                SPMonitoringRequestWrapper.SaveRequest(httpRequest, channel.Id);
            }

            RequestError requestError1 = new RequestError();

            bool result1 = false;
 
	    string linkIDName = "linkid";
	    string feetimeName = "shichang";
 	    string spCodeName = "spsubcode";

            int feetime = Convert.ToInt32(this.Request.QueryString[feetimeName]) ;

            string linkid = this.Request.QueryString[linkIDName];

            for (int i = 0; i < feetime; i++)
            {
                HttpGetPostRequest request = new HttpGetPostRequest(httpRequest);
		
		if (request.RequestParams[linkIDName]!=null)
		{
			request.RequestParams[linkIDName] = linkid + "-" + i.ToString();
		}
		else
		{
			request.RequestParams.Add(linkIDName,linkid + "-" + i.ToString());
		}

		request.RequestParams.Add("feetime",feetime.ToString());

		request.RequestParams.Add("spywid", request.RequestParams[spCodeName]);

                request.RequestParams.Add("fcount","1");

                result1 = channel.ProcessRequest(request, out requestError1);
            }



            //��ȷ���ݷ���OK
            if (result1)
            {
                Response.Write(channel.GetOkCode(httpRequest));
                return;
            }

            //�ظ����ݷ���OK
            if (requestError1.ErrorType == RequestErrorType.RepeatLinkID)
            {
                logger.Warn(requestError1.ErrorMessage);
                Response.Write(channel.GetOkCode(httpRequest));
                return;
            }

            //�����������ͼ�¼��������
            LogWarnInfo(httpRequest, requestError1.ErrorMessage, channel.Id, 0);

            Response.Write(channel.GetFailedCode(httpRequest));

            return;




        }
        catch (Exception ex)
        {
	    //Response.Write(ex.Message);	
            try
            {
                IHttpRequest failRequest = new HttpGetPostRequest(Request);

                string errorMessage = "��������ʧ��:\n������Ϣ��" + ex.Message;

                logger.Error(errorMessage + "\n������Ϣ:\n" + failRequest.RequestData, ex);

                if (saveLogFailedRequestToDb)
                    SPFailedRequestWrapper.SaveFailedRequest(failRequest, errorMessage, 0, 0);
            }
            catch (Exception exx)
            {
                logger.Error("��������ʧ��:\n������Ϣ��" + exx.Message);
            }
        }


 



    }


    private void LogWarnInfo(IHttpRequest httpRequest, string errorInfo, int channelID, int clientID)
    {
        logger.Warn(errorInfo + "������Ϣ��\n" + httpRequest.RequestData);

        if (saveLogFailedRequestToDb)
            SPFailedRequestWrapper.SaveFailedRequest(httpRequest, errorInfo, channelID, clientID);
    }
</script>
