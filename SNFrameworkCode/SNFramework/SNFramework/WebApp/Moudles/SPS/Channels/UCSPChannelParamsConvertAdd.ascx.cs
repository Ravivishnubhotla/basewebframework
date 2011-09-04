using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPS.Bussiness.Wrappers;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{



    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelParamsConvertAdd")]
    public partial class UCSPChannelParamsConvertAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelParamsConvertAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPChannelParamsConvert_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelParamsConvertWrapper obj = new SPChannelParamsConvertWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.ParamsValue = this.txtParamsValue.Text.Trim();
                obj.ParamsConvertTo = this.txtParamsConvertTo.Text.Trim();
                obj.ParamsConvertType = this.txtParamsConvertType.Text.Trim();
                obj.ParamsConvertCondition = this.txtParamsConvertCondition.Text.Trim();
 
                obj.CreateBy = Convert.ToInt32(this.txtCreateBy.Text.Trim());
                obj.CreateAt = UIHelper.SaftGetDateTime(this.txtCreateAt.Text.Trim());
                obj.LastModifyBy = Convert.ToInt32(this.txtLastModifyBy.Text.Trim());
                obj.LastModifyAt = UIHelper.SaftGetDateTime(this.txtLastModifyAt.Text.Trim());





                SPChannelParamsConvertWrapper.Save(obj);

                winSPChannelParamsConvertAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }


}