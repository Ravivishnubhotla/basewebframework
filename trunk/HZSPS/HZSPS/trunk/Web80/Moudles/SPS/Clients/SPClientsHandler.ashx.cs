using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    /// <summary>
    /// Summary description for SPClientsHandler
    /// </summary>
    public class SPClientsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SPClientWrapper> clientGroups = new List<SPClientWrapper>();

            if (context.Request.QueryString["DataType"] == "GetAllClient")
            {
                clientGroups = SPClientWrapper.FindAll();
            }
            if (context.Request.QueryString["DataType"] == "GetAllDefaultClient")
            {
                clientGroups = SPClientWrapper.GetAllDefaultClient();
            }
            if (context.Request.QueryString["DataType"] == "GetAllClientByClientGroup")
            {
                int clientGroupID = Convert.ToInt32(context.Request.QueryString["ClientGroupID"]);

                SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(clientGroupID);

                clientGroups = SPClientWrapper.FindAllBySPClientGroupID(clientGroup);
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