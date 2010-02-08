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
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCPhotoEdit")]
    public partial class UCPhotoEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public void Show(int id)
        {
            PhotoWrapper photo = PhotoWrapper.FindById(id);

            if (photo != null)
            {
                //txtName.Text = photo.Name;
                //txtDescription.Text = photo.Description;
                chkPhotoIsShow.Checked = (photo.IsShow.HasValue) ? photo.IsShow.Value : false;
                NumberField1.SetValue(Convert.ToDouble(photo.OrderIndex));

                this.winEditPhoto.Show();
                hidID.Text = id.ToString();
            }
            else
            {
                Ext.Msg.Alert("操作失败", "数据不存在").Show();
            }
        }

        public void Hide()
        {
            this.winEditPhoto.Hide();
        }


        protected void btnEditPhoto_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                PhotoWrapper photo = PhotoWrapper.FindById(int.Parse(hidID.Text.Trim()));

                photo.IsShow = chkPhotoIsShow.Checked;
                photo.OrderIndex = Convert.ToInt32(NumberField1.Value);
                PhotoWrapper.Update(photo);


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