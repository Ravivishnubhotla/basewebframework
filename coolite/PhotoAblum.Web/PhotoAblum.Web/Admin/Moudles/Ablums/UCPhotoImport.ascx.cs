using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using PhotoAblum.Web.Codes.Bussiness.Wrappers;

namespace PhotoAblum.Web.Admin.Moudles.Ablums
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCPhotoImport")]
    public partial class UCPhotoImport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int id)
        {
            hidPhotoID.Text = id.ToString();

            Reload();

            this.winPhotoImport.Show();
        }

        protected void storeImportFile_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            Reload();

        }

        [AjaxMethod]
        public void Reload()
        {
            int id = int.Parse(hidPhotoID.Text);

            storeImportFile.DataSource = PhotoWrapper.GetAllImportFile(id, this.Server.MapPath("~/ImportPath/"));
            storeImportFile.DataBind();
        }
    }
}