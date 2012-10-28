using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Ads
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdPackEdit")]
    public partial class UCSPAdPackEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPAdPackWrapper obj = SPAdPackWrapper.FindById(id);

                if (obj != null)
                {
                    //this.numID.Value = obj.ID.ToString();
                    //this.numSPAdID.Value = obj.SPAdID.ToString();
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);




                    hidId.Text = id.ToString();


                    winSPAdPackEdit.Show();

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

        protected void btnSaveSPAdPack_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdPackWrapper obj = SPAdPackWrapper.FindById(int.Parse(hidId.Text.Trim()));
                //obj.ID = Convert.ToInt32(this.numID.Value.Trim());
                //obj.SPAdID = Convert.ToInt32(this.numSPAdID.Value.Trim());
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();


                SPAdPackWrapper.Update(obj);

                winSPAdPackEdit.Hide();
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