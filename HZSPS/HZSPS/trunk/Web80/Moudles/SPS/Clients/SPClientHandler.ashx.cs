using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.MobileControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SPClientHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SPClientWrapper> clients = new List<SPClientWrapper>();

            if (context.Request.QueryString["DataType"] == "GetChannelSycnClient")
            {
                int channelID = 0;

                if(context.Request.QueryString["ChannleID"]!=null)
                {
                    channelID = Convert.ToInt32(context.Request.QueryString["ChannleID"]);

                    if(channelID>0)
                    {
                        List<SPClientChannelSettingWrapper> settings = SPChannelWrapper.FindById(channelID).GetAllClientChannelSetting();

                        foreach (SPClientChannelSettingWrapper spClientChannelSettingWrapper in settings)
                        {
                            int cid = spClientChannelSettingWrapper.ClinetID.Id;
                            bool sycnData = spClientChannelSettingWrapper.SyncData.HasValue &&
                                            spClientChannelSettingWrapper.SyncData.Value;

                            bool hasSycnDataUrl = !string.IsNullOrEmpty(spClientChannelSettingWrapper.SyncDataUrl);

                            if (!clients.Exists(p => (p.Id == cid)) && sycnData && hasSycnDataUrl)
                            {
                                clients.Add(spClientChannelSettingWrapper.ClinetID);
                            }
                        }
                    }


                }
            }

            if (context.Request.QueryString["DataType"]==null || string.IsNullOrEmpty(context.Request.QueryString["DataType"]))
            {
                clients = SPClientWrapper.FindAll();
            }

            context.Response.Write(string.Format("{{total:{1},'clients':{0}}}", JSON.Serialize(clients), clients.Count));
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
