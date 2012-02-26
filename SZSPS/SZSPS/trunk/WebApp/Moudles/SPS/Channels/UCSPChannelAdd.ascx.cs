using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelAdd")]
    public partial class UCSPChannelAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPChannel_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelWrapper obj = new SPChannelWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDecription.Text.Trim();
                obj.Area = this.txtArea.Text.Trim();
                obj.CreateTime = System.DateTime.Now;
                obj.CreateBy = this.ParentPage.CurrentLoginUser.UserID;





                SPChannelWrapper.Save(obj);

                winSPChannelAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}