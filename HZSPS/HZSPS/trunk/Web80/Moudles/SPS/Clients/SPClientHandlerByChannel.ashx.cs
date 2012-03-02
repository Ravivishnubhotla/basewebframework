using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SPClientHandlerByChannel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SPClientWrapper> clients = null;

            string clientID = context.Request.QueryString["ClinetID"];

            if (string.IsNullOrEmpty(clientID))
            {
                clients = new List<SPClientWrapper>();
            }
            else
            {
                int cid = int.Parse(clientID);

                clients = SPClientWrapper.FindByChannelID(cid);

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
