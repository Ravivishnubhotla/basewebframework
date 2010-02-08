using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoAblum.Web.Codes.Bussiness.Wrappers;

namespace PhotoAblum.Web
{
    public partial class AblumDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page.IsPostBack)
                return;

            int id = int.Parse(this.Request.QueryString["ID"]);


            List<PhotoWrapper> photos = PhotoWrapper.GetByAlbumID(id);



            this.DataList1.DataSource = photos;
            this.DataList1.DataBind();





        }
    }
}
