using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Ads
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdvertisementEdit")]
    public partial class UCSPAdvertisementEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPAdvertisementWrapper obj = SPAdvertisementWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    if (obj.UpperID != null)
                        this.cmbUpper.SetValue(obj.UpperID.Id.ToString());
                    else
                        this.cmbUpper.ClearValue();
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.txtImageUrl.Text = ValueConvertUtil.ConvertStringValue(obj.ImageUrl);
                    this.txtAdPrice.Text = ValueConvertUtil.ConvertStringValue(obj.AdPrice);
                    cmbAccountType.SetValue(obj.AccountType); 
                    this.cmbAdType.SetValue(obj.AdType);
                    this.txtAdText.Text = ValueConvertUtil.ConvertStringValue(obj.AdText);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    //this.chkIsDisable.Checked = obj.IsDisable.ToString();
                    //this.numAssignedClient.Value = obj.AssignedClient.ToString();
                    //this.numCreateBy.Value = obj.CreateBy.ToString();
                    //this.dateCreateAt.Value = obj.CreateAt.ToString();
                    //this.numLastModifyBy.Value = obj.LastModifyBy.ToString();
                    //this.dateLastModifyAt.Value = obj.LastModifyAt.ToString();
 




                    hidId.Text = id.ToString();


                    winSPAdvertisementEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPAdvertisement_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdvertisementWrapper obj = SPAdvertisementWrapper.FindById(int.Parse(hidId.Text.Trim()));
                if (this.cmbUpper.SelectedItem != null)
                    obj.UpperID = SPUpperWrapper.FindById(Convert.ToInt32(this.cmbUpper.SelectedItem.Value));
                else
                    obj.UpperID = null;
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.ImageUrl = this.txtImageUrl.Text.Trim();
                obj.AdPrice = this.txtAdPrice.Text.Trim();
                obj.AccountType = cmbAccountType.SelectedItem.Value.Trim();
                //obj.ApplyStatus = this.txtApplyStatus.Text.Trim();
                obj.AdType = cmbAdType.SelectedItem.Value.Trim();
                obj.AdText = this.txtAdText.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
 
                //obj.AssignedClient = Convert.ToInt32(this.numAssignedClient.Value.Trim());
                //obj.CreateBy = Convert.ToInt32(this.numCreateBy.Value.Trim());
                //obj.CreateAt = UIHelper.SaftGetDateTime(this.dateCreateAt.Value.Trim());
                //obj.LastModifyBy = Convert.ToInt32(this.numLastModifyBy.Value.Trim());
                //obj.LastModifyAt = UIHelper.SaftGetDateTime(this.dateLastModifyAt.Value.Trim());
                obj.LastModifyBy = ((BasePage)this.Page).CurrentLoginUser.UserID;
                obj.LastModifyAt = System.DateTime.Now;
                obj.LastModifyComment = "创建用户。";


                SPAdvertisementWrapper.Update(obj);

                winSPAdvertisementEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }
    }




}