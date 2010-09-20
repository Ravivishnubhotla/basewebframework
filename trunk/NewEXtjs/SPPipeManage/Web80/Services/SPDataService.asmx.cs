using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Legendigital.Common.Web.Services
{
    /// <summary>
    /// Summary description for SPDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SPDataService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet GetAllClientChannelNeedSendData()
        {
            DataSet ds = new DataSet();
            return ds;
        }

        [WebMethod]
        public DataSet GetAllSendLink()
        {
            DataSet ds = new DataSet();
            return ds;
        }
    }
}
