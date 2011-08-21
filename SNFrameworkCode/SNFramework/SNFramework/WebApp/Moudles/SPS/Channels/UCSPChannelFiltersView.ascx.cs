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
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelFiltersView")]
    public partial class UCSPChannelFiltersView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelFiltersWrapper obj = SPChannelFiltersWrapper.FindById(id);

                if (obj != null)
                {



                    this.lblChannelID.Text = obj.ChannelID.ToString();
                    this.lblParamsName.Text = ValueConvertUtil.ConvertStringValue(obj.ParamsName);
                    this.lblFilterType.Text = ValueConvertUtil.ConvertStringValue(obj.FilterType);
                    this.lblFilterValue.Text = ValueConvertUtil.ConvertStringValue(obj.FilterValue);





                    //hidLogID.Text = id.ToString();


                    winSPChannelFiltersView.Show();

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