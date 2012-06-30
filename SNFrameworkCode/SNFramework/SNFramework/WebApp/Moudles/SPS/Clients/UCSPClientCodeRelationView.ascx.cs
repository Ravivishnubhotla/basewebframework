using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{


    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientCodeRelationView")]
    public partial class UCSPClientCodeRelationView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPClientCodeRelationWrapper obj = SPClientCodeRelationWrapper.FindById(id);

                if (obj != null)
                {



 
                    this.lblPrice.Text = obj.Price.ToString();
                    this.lblInterceptRate.Text = obj.InterceptRate.ToString();
 
                    this.lblSycnRetryTimes.Text = ValueConvertUtil.ConvertStringValue(obj.SycnRetryTimes);

                    if (obj.SyncDataSetting != null)
                    {
                        this.lblSyncType.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SyncType);
                        this.lblSycnDataUrl.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SycnMOUrl);
                        this.lblSycnOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SycnMOOkMessage);
                        this.lblSycnFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SycnMOFailedMessage);
                    }
                    else
                    {
                        this.lblSyncType.Text = "";
                        this.lblSycnDataUrl.Text = "";
                        this.lblSycnOkMessage.Text = "";
                        this.lblSycnFailedMessage.Text = "";
                    }


                    this.lblStartDate.Text = obj.StartDate.ToString();
                    this.lblEndDate.Text = obj.EndDate.ToString();
 
                    this.lblSycnNotInterceptCount.Text = obj.SycnNotInterceptCount.ToString();
                    this.lblCreateBy.Text = obj.CreateBy.ToString();
                    this.lblCreateAt.Text = obj.CreateAt.ToString();
                    this.lblLastModifyBy.Text = obj.LastModifyBy.ToString();
                    this.lblLastModifyAt.Text = obj.LastModifyAt.ToString();





                    //hidLogID.Text = id.ToString();


                    winSPClientCodeRelationView.Show();

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