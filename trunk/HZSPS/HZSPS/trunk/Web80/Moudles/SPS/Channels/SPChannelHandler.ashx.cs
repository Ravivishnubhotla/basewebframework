using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SPChannelHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SPChannelWrapper> channels = SPChannelWrapper.FindAll();

            context.Response.Write(string.Format("{{total:{1},'channels':{0}}}", JSON.Serialize(channels), channels.Count));
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
