using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Channels
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelView")]
    public partial class UCSPChannelView : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(id);

                if (obj != null)
                {
                    obj.UpdateChannelDetailInfo();


                    this.winSPChannelView.Title = string.Format("通道“{0}”详细信息", obj.Name);

                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);

                    this.lblChannelDetailInfo.Text = ValueConvertUtil.ConvertStringValue(obj.ChannelDetailInfo);

                    winSPChannelView.Show();

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


    }
}