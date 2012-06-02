using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{



    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelFiltersEdit")]
    public partial class UCSPChannelFiltersEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                //SPChannelFiltersWrapper obj = SPChannelFiltersWrapper.FindById(id);

                //if (obj != null)
                //{
                //    this.txtChannelID.Text = obj.ChannelID.ToString();
                //    this.txtParamsName.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsName);
                //    this.txtFilterType.Text = ValueConvertUtil.ConvertStringValue(obj.FilterType);
                //    this.txtFilterValue.Text = ValueConvertUtil.ConvertStringValue(obj.FilterValue);




                //    hidId.Text = id.ToString();


                //    winSPChannelFiltersEdit.Show();

                //}
                //else
                //{
                //    ResourceManager.AjaxSuccess = false;
                //    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                //    return;
                //}
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPChannelFilters_Click(object sender, DirectEventArgs e)
        {
            //try
            //{
            //    SPChannelFiltersWrapper obj = SPChannelFiltersWrapper.FindById(int.Parse(hidId.Text.Trim()));
 
            //    obj.ParamsName = this.txtParamsName.Text.Trim();
            //    obj.FilterType = this.txtFilterType.Text.Trim();
            //    obj.FilterValue = this.txtFilterValue.Text.Trim();


            //    SPChannelFiltersWrapper.Update(obj);

            //    winSPChannelFiltersEdit.Hide();
            //    ResourceManager.AjaxSuccess = true;
            //}
            //catch (Exception ex)
            //{
            //    ResourceManager.AjaxSuccess = false;
            //    ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            //    return;
            //}

        }
    }





}