using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Legendigital.Common.Web.AppClass
{
    public class SPXml2Handler : SPXmlRecievedHandler
    {
        protected override string GetXmlNodeName()
        {
            return "hk-cp";
        }

        protected override string GetChannelCodeName(HttpContext context)
        {
            string requestFileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);
            return requestFileName.Substring(0, requestFileName.Length - ("Xml2").Length);
        }
    }
}