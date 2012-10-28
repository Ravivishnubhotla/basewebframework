using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Ads
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdvertisementAdd")]
    public partial class UCSPAdvertisementAdd : System.Web.UI.UserControl
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
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
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
                obj.AccountType = this.txtAccountType.Text.Trim();
                obj.ApplyStatus = this.txtApplyStatus.Text.Trim();
                obj.AdType = this.txtAdType.Text.Trim();
                obj.AdText = this.txtAdText.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.IsDisable = this.chkIsDisable.Checked;
                //obj.AssignedClient = Convert.ToInt32(this.numAssignedClient.Value.Trim());
                //obj.CreateBy = Convert.ToInt32(this.numCreateBy.Value.Trim());
                //obj.CreateAt = UIHelper.SaftGetDateTime(this.dateCreateAt.Value.Trim());
                //obj.LastModifyBy = Convert.ToInt32(this.numLastModifyBy.Value.Trim());
                //obj.LastModifyAt = UIHelper.SaftGetDateTime(this.dateLastModifyAt.Value.Trim());
                obj.LastModifyComment = this.txtLastModifyComment.Text.Trim();





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