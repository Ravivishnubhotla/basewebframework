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



        public ShopMallLayoutData LoadShopMallLayoutData(string shopMallLayoutNo)
        {
            return null;
        }

        public List<BrandInfo> GetAllBrandInfo()
        {
            return null;
        }

        public List<RosShopInfo> CaculateNewCompleteNumber(List<RosShopInfo> rosShopInfos)
        {
            return null;
        }

 

    }
}
