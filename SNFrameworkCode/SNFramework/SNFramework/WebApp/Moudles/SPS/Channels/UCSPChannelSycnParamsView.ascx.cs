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

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelSycnParamsView")]
    public partial class UCSPChannelSycnParamsView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelSycnParamsWrapper obj = SPChannelSycnParamsWrapper.FindById(id);

                if (obj != null)
                {



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.lblIsEnable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable).ToString();
                    this.lblChannelID.Text = obj.ChannelID.ToString();
                    this.lblMappingParams.Text = ValueConvertUtil.ConvertStringValue(obj.MappingParams);
                    this.lblTitle.Text = ValueConvertUtil.ConvertStringValue(obj.Title);
                    this.lblParamsValue.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsValue);
                    this.lblParamsType.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsType);





                    //hidLogID.Text = id.ToString();


                    winSPChannelSycnParamsView.Show();

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