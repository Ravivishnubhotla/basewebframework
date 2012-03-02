using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Commons;
using LD.SPPipeManage.Bussiness.Wrappers;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.AppClass
{
    public class SPXmlHandler : SPXmlRecievedHandler
    {
        protected override string GetXmlNodeName()
        {
            return "message";
        }

        protected override string GetChannelCodeName(HttpContext context)
        {
            string requestFileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);
            return requestFileName.Substring(0, requestFileName.Length - ("Xml").Length);
        }
    }
}
