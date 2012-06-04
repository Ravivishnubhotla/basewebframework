
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Logging;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    /// <summary>
    /// Summary description for SPClientHandler
    /// </summary>
    public class SPClientHandler : IHttpHandler
    {
        protected static ILog logger = LogManager.GetLogger(typeof(SPClientHandler));
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            int start = 0;
            int limit = 10;
            string sort = string.Empty;
            string dir = string.Empty;
            string query = string.Empty;

            if (!string.IsNullOrEmpty(context.Request["start"]))
            {
                start = int.Parse(context.Request["start"]);
            }

            if (!string.IsNullOrEmpty(context.Request["limit"]))
            {
                limit = int.Parse(context.Request["limit"]);
            }

            if (!string.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"];
            }

            if (!string.IsNullOrEmpty(context.Request["dir"]))
            {
                dir = context.Request["dir"];
            }

            if (!string.IsNullOrEmpty(context.Request["query"]))
            {
                query = context.Request["query"];
            }

            List<QueryFilter> filters = new List<QueryFilter>();

            if(!string.IsNullOrEmpty(query))
            {
                filters.Add(new QueryFilter(SPSClientWrapper.PROPERTY_NAME_NAME,query ,FilterFunction.Contains ));
            }

            //filters.Add(new QueryFilter(SPSClientWrapper.PROPERTY_NAME_ISDEFAULTCLIENT,"True",FilterFunction.NotEqualTo));

            List<SPSClientWrapper> clients = SPSClientWrapper.FindAllByOrderByAndFilter(filters,"",true);

            try
            {
                JSonResult<SPSClientWrapper> results = new JSonResult<SPSClientWrapper>(clients);
                context.Response.Write(JSON.Serialize(results));
            }
            catch (Exception e)
            {
                logger.Error("读取通道错误", e);
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