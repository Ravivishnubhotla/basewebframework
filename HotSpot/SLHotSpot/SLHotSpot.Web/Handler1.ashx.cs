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
            bool showallShop = false;

            if (context.Request.Params["showAllBrandInf"] != null && context.Request.Params["showAllBrandInf"].ToLower()=="true")
            {
                showallShop = true;
            }
 
            DataRecordArray<RosShopInfo> datas = new DataRecordArray<RosShopInfo>(HotSpotWebService.LoadShopData("M001001", "F1_0", showallShop));
            
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