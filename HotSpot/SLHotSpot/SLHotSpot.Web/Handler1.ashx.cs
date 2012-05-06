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

            string dataString = string.Empty;

            List<RosShopInfo> shopDatas = new List<RosShopInfo>(HotSpotWebService.LoadShopData("M001001", "F1_0", showallShop));

            if (context.Request.Params["data"] != null && context.Request.Params["data"].ToLower() == "true")
            {
                List<ROSHotSpot> dataarrays = new List<ROSHotSpot>();
                foreach (RosShopInfo shopInfo in shopDatas)
                {
                    dataarrays.Add(shopInfo.HotSpotInfo);
                }
                dataString = JsonConvert.SerializeObject(dataarrays);
            }
            else
            {
                DataRecordArray<RosShopInfo> datas = new DataRecordArray<RosShopInfo>(shopDatas);
                dataString = JsonConvert.SerializeObject(datas);
            }

            
            context.Response.ContentType = "text/plain";
            context.Response.Write(dataString);
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