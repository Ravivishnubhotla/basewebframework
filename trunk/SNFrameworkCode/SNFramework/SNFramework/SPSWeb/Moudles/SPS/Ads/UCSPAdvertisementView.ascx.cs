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
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdvertisementView")]
    public partial class UCSPAdvertisementView : System.Web.UI.UserControl
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



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.lblImageUrl.Text = ValueConvertUtil.ConvertStringValue(obj.ImageUrl);
                    this.lblAdPrice.Text = ValueConvertUtil.ConvertStringValue(obj.AdPrice);
                    this.lblAccountType.Text = ValueConvertUtil.ConvertStringValue(obj.AccountType);
                    this.lblApplyStatus.Text = ValueConvertUtil.ConvertStringValue(obj.ApplyStatus);
                    this.lblAdType.Text = ValueConvertUtil.ConvertStringValue(obj.AdType);
                    this.lblAdText.Text = ValueConvertUtil.ConvertStringValue(obj.AdText);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.lblIsDisable.Text = obj.IsDisable.ToString();
                    this.lblAssignedClient.Text = obj.AssignedClient.ToString();
                    this.lblCreateBy.Text = obj.CreateBy.ToString();
                    this.lblCreateAt.Text = obj.CreateAt.ToString();
                    this.lblLastModifyBy.Text = obj.LastModifyBy.ToString();
                    this.lblLastModifyAt.Text = obj.LastModifyAt.ToString();
                    this.lblLastModifyComment.Text = ValueConvertUtil.ConvertStringValue(obj.LastModifyComment);





                    //hidLogID.Text = id.ToString();


                    winSPAdvertisementView.Show();

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
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }
        }


    }






}