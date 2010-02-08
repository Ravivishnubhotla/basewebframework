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
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCPhotoAdd")]
    public partial class UCPhotoAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int aid)
        {
            txtPhotoName.Text = "";
            txPhototDescription.Text = "";
            chkPhotoIsShow.Checked = true;

            if (this.fufPhotoFullImage.PostedFile != null)
            {
                this.fufPhotoFullImage.SetRawValue(null);
                //this.fufPhotoFullImage.Text = "";
            }


            hidAblumID.Text = aid.ToString();
            this.winNewPhoto.Show();
        }

        public void Hide()
        {
            this.winNewPhoto.Hide();
        }




        protected void btnAddPhoto_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                PhotoWrapper photo = new PhotoWrapper();
                //photo.Name = txtName.Text.Trim();
                //photo.Description = txtDescription.Text.Trim();
                photo.IsShow = chkPhotoIsShow.Checked;
                photo.OrderIndex = photo.GeneretaNewOrderIndex();
                photo.AlbumID = Convert.ToInt32(hidAblumID.Text);

                photo.SetImage(this.fufPhotoFullImage.PostedFile);

                PhotoWrapper.Save(photo);

                Hide();

                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }

        }
    }
}