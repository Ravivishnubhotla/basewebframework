using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SPSWeb.Moudles.DataService
{
    /// <summary>
    /// Summary description for DictionaryDataService
    /// </summary>
    public class DictionaryDataService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            string groupCode = context.Request["GroupCode"];

            List<SystemDictionaryWrapper> dictionaryWrappers =
                SystemDictionaryWrapper.GetDictionaryByGroupCode(groupCode);

            context.Response.Write(string.Format("{{total:{1},'dictionarys':{0}}}", JSON.Serialize(dictionaryWrappers), dictionaryWrappers.Count));
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