using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace SLHotSpot.Web
{
    /// <summary>
    /// Summary description for HotSpotWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HotSpotWebService : System.Web.Services.WebService
    {

 

 //电脑城楼层 




        [WebMethod]
        public void SaveHotspotData(string shopNo,string hotSpotData)
        {
            string fileName = this.Server.MapPath("~/DataFiles/" + shopNo + ".txt");

            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
 
            File.WriteAllText(fileName, hotSpotData);
        }


        [WebMethod]
        public string LoadHotspotData(string shopNo)
        {
            string fileName = this.Server.MapPath("~/DataFiles/" + shopNo + ".txt");

            if (File.Exists(fileName))
            {
                return File.ReadAllText(fileName);
            }

            return "";
        }

        [WebMethod]
        public void SaveShopMallFloorHotspotData(string shopMallNo, string floorNo, string hotSpotData)
        {
            string fileName = this.Server.MapPath("~/DataFiles/" + shopMallNo + "_" + floorNo + ".txt");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.WriteAllText(fileName, hotSpotData);
        }


        [WebMethod]
        public string LoadShopMallFloorHotspotData(string shopMallNo, string floorNo)
        {
            string fileName = this.Server.MapPath("~/DataFiles/" + shopMallNo + "_" + floorNo + ".txt");

            if (File.Exists(fileName))
            {
                return File.ReadAllText(fileName);
            }

            return "";
        }

        public string GetRootUrl()
        {
            HttpContext context = HttpContext.Current;

            if (context == null)
                return "";

            string rootUrl = "";

            if (context.Request.Url.Port == 80)
                rootUrl = string.Format("{0}://{1}/{0}{2}", context.Request.Url.Scheme,
                                     context.Request.Url.Host, context.Request.ApplicationPath);
            else
            {
                rootUrl = string.Format("{0}://{1}:{2}{3}", context.Request.Url.Scheme,
                                 context.Request.Url.Host,
                                 context.Request.Url.Port, context.Request.ApplicationPath);
            }




            return rootUrl;
        }

        [WebMethod]
        public ShopMallFloorHotspotData LoadShopMallLayoutData(string shopMallNo, string floorNo)
        {
            ShopMallFloorHotspotData shopMallFloorHotspotData = new ShopMallFloorHotspotData();
            shopMallFloorHotspotData.ShopMallNo = shopMallNo;
            shopMallFloorHotspotData.ShopMallFloorNo = floorNo;
            shopMallFloorHotspotData.ImageUrl = GetRootUrl() + "Images/" + string.Format("{0}_{1}-3.png", shopMallNo, floorNo);

            shopMallFloorHotspotData.Brands = BrandData.GetAllBrandInfos();
            
            shopMallFloorHotspotData.ShopInfos = new List<RosShopInfo>();


            for (int i = 0; i < shopMallFloorHotspotData.Brands.Count; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    RosShopInfo rosShopInfo = new RosShopInfo();
                    rosShopInfo.ShopNO = "BA10" + (i + 1).ToString("D2") + (j + 1).ToString("D2");
                    rosShopInfo.CompleteNumber = 60;
                    rosShopInfo.ShopName = "北京市北京昌隆鑫丰商贸有限公司鼎好店";
                    rosShopInfo.ShopBrandInfo = shopMallFloorHotspotData.Brands[i].Name;
                    rosShopInfo.HotSpotInfo = "";
                    shopMallFloorHotspotData.ShopInfos.Add(rosShopInfo);
                }
            }

            return shopMallFloorHotspotData;
        }

 

        public List<RosShopInfo> CaculateNewCompleteNumber(List<RosShopInfo> rosShopInfos)
        {
            return null;
        }

 

    }
}
