using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoAblum.Web.Codes.Bussiness.Wrappers;

namespace PhotoAblum.Web
{
    public partial class _Default : Spring.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack)
                return;

            BindData();
        }

        public void BindData()
        {
            this.DataList1.DataSource = AlbumWrapper.FindAll();
            this.DataList1.DataBind();
        }
    }
}
