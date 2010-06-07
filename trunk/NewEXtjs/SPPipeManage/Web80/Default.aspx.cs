using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}
