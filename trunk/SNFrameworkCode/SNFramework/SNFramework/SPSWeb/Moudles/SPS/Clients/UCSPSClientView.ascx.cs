using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Clients
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPSClientView")]
    public partial class UCSPSClientView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPSClientWrapper obj = SPSClientWrapper.FindById(id);

                if (obj != null)
                {



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    //this.lblRecieveDataUrl.Text = ValueConvertUtil.ConvertStringValue(obj.RecieveDataUrl);
                    //this.lblUserID.Text = obj.UserID.ToString();
                    ////this.lblSyncData.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.SyncData);
                    //this.lblOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.OkMessage);
                    //this.lblFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.FailedMessage);
                    if (obj.SyncDataSetting != null)
                        this.lblSyncType.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SyncType);
                    else
                        this.lblSyncType.Text = "";
                    this.lblAlias.Text = ValueConvertUtil.ConvertStringValue(obj.Alias);
                    this.lblInterceptRate.Text = obj.InterceptRate.ToString();
                    this.lblDefaultPrice.Text = obj.DefaultPrice.ToString();





                    //hidLogID.Text = id.ToString();


                    winSPSClientView.Show();

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