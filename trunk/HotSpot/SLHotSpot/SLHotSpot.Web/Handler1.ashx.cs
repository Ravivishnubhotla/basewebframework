using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SLHotSpot.Web
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DataRecordArray<ROSHotSpot> datas = new DataRecordArray<ROSHotSpot>(HotSpotWebService.LoadHotspotData("M001001", "F1_0",true));
            context.Response.ContentType = "text/plain";
            context.Response.Write(JsonConvert.SerializeObject(datas));
            context.Response.End();
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