﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.SPSInterface
{





    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SPSHandler : IHttpHandler
    {
        protected ILog logger = LogManager.GetLogger(typeof (SPSHandler));


        public void ProcessRequest(HttpContext context)
        {
            string fileName = Path.GetFileNameWithoutExtension(context.Request.PhysicalPath);

            SPChannelWrapper channel = SPChannelWrapper.GetChannelByPath(fileName);

            if(channel!=null)
            {
                channel.ProcessRequest(GetRequestValue(context));
            }



        }


        private Hashtable GetRequestValue(HttpContext requestContext)
        {
            Hashtable hb = new Hashtable();

            foreach(string key in requestContext.Request.Params.Keys){
                hb.Add(key,requestContext.Request.Params[key]);
            }

            return hb;
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
