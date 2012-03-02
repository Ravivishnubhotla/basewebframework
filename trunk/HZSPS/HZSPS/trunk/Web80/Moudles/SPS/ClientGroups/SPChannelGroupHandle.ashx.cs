using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientGroups
{
    /// <summary>
    /// Summary description for SPChannelGroupHandle
    /// </summary>
    public class SPChannelGroupHandle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SPClientGroupWrapper> clientGroups = new List<SPClientGroupWrapper>();

            if (context.Request.QueryString["DataType"] == "GetAllClientGroup")
            {
                clientGroups = SPClientGroupWrapper.FindAll();
            }

            context.Response.Write(string.Format("{{total:{1},'datas':{0}}}", JSON.Serialize(clientGroups), clientGroups.Count));

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