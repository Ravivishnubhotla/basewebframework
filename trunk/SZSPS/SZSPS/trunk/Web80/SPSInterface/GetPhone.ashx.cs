using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.SPSInterface
{
    /// <summary>
    /// Summary description for GetPhone
    /// </summary>
    public class GetPhone : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string phone = context.Request.QueryString["phone"];
            string phoneArea = "自定义1";

            if (string.IsNullOrEmpty(phone))
            {
                context.Response.Write("Failed");
                return;
            }

 
            try
            {
                SPCustomPhoneAreaWrapper spCustomPhoneArea = new SPCustomPhoneAreaWrapper();

                spCustomPhoneArea.AreaName = phoneArea;
                spCustomPhoneArea.Phone = phone;

                SPCustomPhoneAreaWrapper.Save(spCustomPhoneArea);

                context.Response.Write("Ok");
            }
            catch (Exception)
            {
                context.Response.Write("Failed");
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