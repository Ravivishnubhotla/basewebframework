using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Common.Logging;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    /// <summary>
    /// Summary description for SPChannelHandler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SPChannelHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPChannelHandler));
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            //int start = 0;
            //int limit = 10;
            //string sort = string.Empty;
            //string dir = string.Empty;
            //string query = string.Empty;

            //if (!string.IsNullOrEmpty(context.Request["start"]))
            //{
            //    start = int.Parse(context.Request["start"]);
            //}

            //if (!string.IsNullOrEmpty(context.Request["limit"]))
            //{
            //    limit = int.Parse(context.Request["limit"]);
            //}

            //if (!string.IsNullOrEmpty(context.Request["sort"]))
            //{
            //    sort = context.Request["sort"];
            //}

            //if (!string.IsNullOrEmpty(context.Request["dir"]))
            //{
            //    dir = context.Request["dir"];
            //}

            //if (!string.IsNullOrEmpty(context.Request["query"]))
            //{
            //    query = context.Request["query"];
            //}

            List<SPChannelWrapper> channels = SPChannelWrapper.FindAll();

            try
            {
                context.Response.Write(string.Format("{{Total:{1},'Datas':{0}}}", JSON.Serialize(channels), channels.Count));
            }
            catch (Exception e)
            {
                logger.Error("读取通道错误",e);
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