using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Ads
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdvertisementAdd")]
    public partial class UCSPAdvertisementAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPAdvertisementAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
            }
        }

        protected void btnSaveSPAdvertisement_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdvertisementWrapper obj = new SPAdvertisementWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.ImageUrl = this.txtImageUrl.Text.Trim();
                obj.AdPrice = this.txtAdPrice.Text.Trim();
                obj.AccountType = cmbAccountType.SelectedItem.Value.Trim();
                //obj.ApplyStatus = this.txtApplyStatus.Text.Trim();
                obj.AdType = cmbAdType.SelectedItem.Value.Trim();
                obj.AdText = this.txtAdText.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsDisable = false;
                //obj.AssignedClient = Convert.ToInt32(this.numAssignedClient.Value.Trim());
                obj.CreateBy = ((BasePage)this.Page).CurrentLoginUser.UserID;
                obj.CreateAt = System.DateTime.Now;
                obj.LastModifyBy = ((BasePage)this.Page).CurrentLoginUser.UserID;
                obj.LastModifyAt = System.DateTime.Now;
                obj.LastModifyComment = "创建用户。";

 
                SPAdvertisementWrapper.Save(obj);

                winSPAdvertisementAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }

}