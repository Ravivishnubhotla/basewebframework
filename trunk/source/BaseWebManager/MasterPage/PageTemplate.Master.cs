using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BaseWebManager.MasterPage
{
    public partial class PageTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.AdminCssLink.Attributes["href"] = "/" + @"css/table/" + "default" + @"/Css.css";

        }

        protected override void OnInit(EventArgs e)
        {
        }
    }
}
