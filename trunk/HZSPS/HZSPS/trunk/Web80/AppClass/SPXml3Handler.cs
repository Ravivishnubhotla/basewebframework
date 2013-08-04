using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Legendigital.Common.Web.AppClass
{
    public class SPXml3Handler : SPXmlRecievedHandler
    {
        protected override string GetXmlNodeName()
        {
 

            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["node"]))
                return HttpContext.Current.Request.QueryString["node"];

            string requestFileName = Path.GetFileNameWithoutExtension(HttpContext.Current.Request.PhysicalPath);

            if (requestFileName.Contains("_"))
                return requestFileName.Split(("_").ToCharArray())[1];

            return "";
        }

        protected override string GetChannelCodeName(HttpContext context)
        {
            string requestFileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);

            if (requestFileName.Contains("_"))
                return requestFileName.Split(("_").ToCharArray())[0];

            return requestFileName.Substring(0, requestFileName.Length - ("Xml3").Length);
        }
    }
}