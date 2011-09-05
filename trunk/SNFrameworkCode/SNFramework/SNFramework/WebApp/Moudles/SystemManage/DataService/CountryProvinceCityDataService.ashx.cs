using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.DataService
{
    /// <summary>
    /// Summary description for CountryProvinceCityDataService
    /// </summary>
    public class CountryProvinceCityDataService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            string dataType = context.Request["DataType"];

            if(dataType.ToLower().Equals("country"))
            {
                List<SystemCountryWrapper> countrys =
                    SystemCountryWrapper.FindAll();

                context.Response.Write(string.Format("{{total:{1},'datas':{0}}}", JSON.Serialize(countrys), countrys.Count));
            }
            else if (dataType.ToLower().Equals("province"))
            {
                string country = context.Request["Country"];

                SystemCountryWrapper countryWrapper = SystemCountryWrapper.FindByCode3(country);

                List<SystemProvinceWrapper> provinces =
                    SystemProvinceWrapper.FindAllByCountryID(countryWrapper);

                context.Response.Write(string.Format("{{total:{1},'datas':{0}}}", JSON.Serialize(provinces), provinces.Count));
            }
            else if (dataType.ToLower().Equals("city"))
            {
                string country = context.Request["Province"];

                //SystemProvinceWrapper provinceWrapper = SystemProvinceWrapper.FindByCode3(country);

                //List<SystemProvinceWrapper> provinces =
                //    SystemProvinceWrapper.FindAllByCountryID(countryWrapper);

                //context.Response.Write(string.Format("{{total:{1},'datas':{0}}}", JSON.Serialize(provinces), provinces.Count));
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