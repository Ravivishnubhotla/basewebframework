using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Users
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetAUserByChannel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SystemUserWrapper> users = SPClientChannelSettingWrapper.GetAvailableUser();
 
            //string clientID = context.Request.QueryString["ClinetID"];

            //if (string.IsNullOrEmpty(clientID))
            //{
            //    users = new List<SystemUserWrapper>();
            //}
            //else
            //{
            //    int cid = int.Parse(clientID);

            //    users = SPClientChannelSettingWrapper.GetAvailableUser(0,cid);

            //}

            context.Response.Write(string.Format("{{total:{1},'users':{0}}}", JSON.Serialize(users), users.Count));
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
