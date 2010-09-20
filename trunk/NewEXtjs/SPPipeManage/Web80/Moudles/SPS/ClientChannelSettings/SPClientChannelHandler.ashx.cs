using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    /// <summary>
    /// Summary description for SPClientChannelHandler
    /// </summary>
    public class SPClientChannelHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            string dataType = context.Request.QueryString["DataType"];

            int clientID = 0;

            switch (dataType)
            {
                case "GetChannelByClientID":

                    clientID = Convert.ToInt32(context.Request.QueryString["ClientID"]);

                    List<SPChannelWrapper> channels = SPClientChannelSettingWrapper.GetSettingByClientID(clientID);

                    context.Response.Write(string.Format("{{total:{1},'data':{0}}}", JSON.Serialize(channels), channels.Count));

                    break;
                case "GetChannelClientIDSettingByClientIDAndChannelID":
                    clientID = Convert.ToInt32(context.Request.QueryString["ClientID"]);

                    List<SPClientChannelSettingWrapper> settingWrappers = SPClientChannelSettingWrapper.GetSettingByChannelAndClientID(clientID);

                    context.Response.Write(string.Format("{{total:{1},'data':{0}}}", JSON.Serialize(settingWrappers), settingWrappers.Count));

                    break;
            }



        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}