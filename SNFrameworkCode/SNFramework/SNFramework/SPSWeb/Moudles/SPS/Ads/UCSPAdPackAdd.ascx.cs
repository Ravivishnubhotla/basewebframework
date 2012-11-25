using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Ads
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdPackAdd")]
    public partial class UCSPAdPackAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public SPAdvertisementWrapper AdvertisementID
        {
            get
            {
                if (this.Request.QueryString["AdvertisementID"] != null)
                {
                    return
                        SPAdvertisementWrapper.FindById(int.Parse(this.Request.QueryString["AdvertisementID"]));
                }
                return null;
            }
        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPAdPackAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPAdPack_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdPackWrapper obj = new SPAdPackWrapper();
                //obj.Id = Convert.ToInt32(this.numID.Value.Trim());
                obj.SPAdID = AdvertisementID;
                obj.Name = this.txtName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.AdPrice = Convert.ToDecimal(this.numAdPrice.Value);




                SPAdPackWrapper.Save(obj);

                winSPAdPackAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }



}