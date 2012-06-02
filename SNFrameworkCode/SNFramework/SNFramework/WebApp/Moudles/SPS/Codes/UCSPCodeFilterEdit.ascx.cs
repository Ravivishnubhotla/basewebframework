using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Codes
{



    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPCodeFilterEdit")]
    public partial class UCSPCodeFilterEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            //try
            //{
            //    SPCodeFilterWrapper obj = SPCodeFilterWrapper.FindById(id);

            //    if (obj != null)
            //    {
            //        this.txtCodeID.Text = obj.CodeID.ToString();
            //        this.txtParamsName.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsName);
            //        this.txtFilterType.Text = ValueConvertUtil.ConvertStringValue(obj.FilterType);
            //        this.txtFilterValue.Text = ValueConvertUtil.ConvertStringValue(obj.FilterValue);




            //        hidId.Text = id.ToString();


            //        winSPCodeFilterEdit.Show();

            //    }
            //    else
            //    {
            //        ResourceManager.AjaxSuccess = false;
            //        ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ResourceManager.AjaxSuccess = false;
            //    ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            //    return;
            //}
        }

        protected void btnSaveSPCodeFilter_Click(object sender, DirectEventArgs e)
        {
            //try
            //{
            //    SPCodeFilterWrapper obj = SPCodeFilterWrapper.FindById(int.Parse(hidId.Text.Trim()));
 
            //    obj.ParamsName = this.txtParamsName.Text.Trim();
            //    obj.FilterType = this.txtFilterType.Text.Trim();
            //    obj.FilterValue = this.txtFilterValue.Text.Trim();


            //    SPCodeFilterWrapper.Update(obj);

            //    winSPCodeFilterEdit.Hide();
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