using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Legendigital.Common.WebApp.TestCP
{
    /// <summary>
    /// Summary description for EmuCP
    /// </summary>
    public class EmuCP : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string okMessage = "ok";

            string failedMessage = "failed";

            int failedRate = 0;

            if (!string.IsNullOrEmpty(context.Request["okmsg"]))
                okMessage = context.Request["okmsg"];

            if (!string.IsNullOrEmpty(context.Request["frate"]))
                failedRate = Convert.ToInt32(context.Request["frate"]);

            context.Response.ContentType = "text/plain";

            if (failedRate>0)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                if(random.Next(0,99)<=failedRate)
                {
                    context.Response.Write(failedMessage);
                }
                else
                {
                    context.Response.Write(okMessage);
                }
            }
            else
            {
                context.Response.Write(okMessage);
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