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
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsView")]
    public partial class UCSPChannelParamsView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelParamsWrapper obj = SPChannelParamsWrapper.FindById(id);

                if (obj != null)
                {



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.lblIsEnable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable).ToString();
                    this.lblIsRequired.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsRequired).ToString();
                    this.lblParamsType.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsType);
 
                    this.lblParamsMappingName.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsMappingName);
                    this.lblTitle.Text = ValueConvertUtil.ConvertStringValue(obj.Title);
                    this.lblShowInClientGrid.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.ShowInClientGrid).ToString();
                    this.lblParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);





                    //hidLogID.Text = id.ToString();


                    winSPChannelParamsView.Show();

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