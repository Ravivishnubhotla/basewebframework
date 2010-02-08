using System;
using System.Collections.Generic;
using System.Web.UI;
using Coolite.Ext.Web;
using PhotoAblum.Web.Codes.Bussiness.Wrappers;
using ScriptManager=Coolite.Ext.Web.ScriptManager;

namespace PhotoAblum.Web.Admin.Moudles.Ablums
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCAblumEditControl")]
    public partial class UCAblumEditControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        [AjaxMethod]
        public void Show(int id)
        {
            AlbumWrapper album = AlbumWrapper.FindById(id);

            if (album != null)
            {
                txtName.Text = album.Name;
                txtDescription.Text = album.Description;
                txtDirName.Text = album.DirName;
                chkIsShow.Checked = (album.IsShow.HasValue) ? album.IsShow.Value : false;
                txtViewPassword.Text = album.ViewPassword;
                numOrderIndex.SetValue(Convert.ToDouble(album.OrderIndex));

                hidID.Text = id.ToString();


                this.imgFullImage.ImageUrl = album.SmallImageUrl;

                if (this.fufFullImage.PostedFile != null)
                    this.fufFullImage.SetRawValue(null);

                this.TabPanel1.SetActiveTab(0);

                winEditAblum.Show();

            }
            else
            {
                Ext.Msg.Alert("操作失败", "数据不存在").Show();
            }
        }

        protected void storePhotos_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int id = int.Parse(hidID.Text);
            List<PhotoWrapper> photos = null;


            photos = PhotoWrapper.GetByAlbumID(id);


            storePhotos.DataSource = photos;
            storePhotos.DataBind();
        }

        protected void btnSaveEditAblumBaseInfo_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                AlbumWrapper album = AlbumWrapper.FindById(int.Parse(hidID.Text.Trim()));
                album.Name = txtName.Text.Trim();
                album.Description = txtDescription.Text.Trim();
                album.IsShow = chkIsShow.Checked;
                album.ViewPassword = txtViewPassword.Text.Trim();
                album.OrderIndex = Convert.ToInt32(numOrderIndex.Value);
                AlbumWrapper.Update(album);
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnUploadCover_Click(object sender, AjaxEventArgs e)
        {
            if (this.fufFullImage.HasFile)
            {
                try
                {
                    AlbumWrapper album = AlbumWrapper.FindById(int.Parse(hidID.Text.Trim()));

                    album.SetImage(this.fufFullImage.PostedFile);

                    this.imgFullImage.ImageUrl = album.SmallImageUrl;

                    ScriptManager.AjaxSuccess = true;
                }
                catch (Exception ex)
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                    return;
                }
            }
            else
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：没有选择上传文件！";
            }

        }


        [AjaxMethod]
        public void DeletePhoto(int id)
        {
            try
            {
                PhotoWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;

                Ext.Msg.Alert("操作成功", "成功删除照片", new JFunction { Fn = "RefreshPhotoData" }).Show();
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }


    }
}