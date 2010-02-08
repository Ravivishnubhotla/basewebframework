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
    public partial class UCAblumAddControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveAblum_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                AlbumWrapper album = new AlbumWrapper();
                album.DirName = txtDirName.Text.Trim();
                album.Name = txtName.Text.Trim();
                album.Description = txtDescription.Text.Trim();
                album.IsShow = chkIsShow.Checked;
                album.ViewPassword = txtViewPassword.Text.Trim();
                album.OrderIndex = album.GeneretaNewOrderIndex();

                string errorMessage = "";

                if (album.CheckDir(out errorMessage))
                {
                    AlbumWrapper.Save(album);
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
                    this.winAblumAdd.Hide();
                }
                else
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = string.Format(errorMessage, album.DirName);
                    return;
                }

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
            
        }


    }
}