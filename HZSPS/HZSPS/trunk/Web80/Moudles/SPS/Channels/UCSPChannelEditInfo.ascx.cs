using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
       [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPChannelEditInfo")]
    public partial class UCSPChannelEditInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(id);

                if (obj != null)
                {

                    hidId.Text = id.ToString();

                    if (obj.UperID != null)
                        this.cmbUpperID.Value = obj.UperID.Id;
                    else
                        this.cmbUpperID.ClearValue();

                    winSPChannelEditInfo.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPChannel_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(int.Parse(hidId.Text.Trim()));

                if (this.cmbUpperID.SelectedItem != null && this.cmbUpperID.SelectedItem.Value != null && !string.IsNullOrEmpty(this.cmbUpperID.SelectedItem.Value.ToString()))
                    obj.UperID =
                        SPUperWrapper.FindById(Convert.ToInt32(this.cmbUpperID.SelectedItem.Value.ToString()));
                else
                    obj.UperID = null;

                SPChannelWrapper.Update(obj);

                winSPChannelEditInfo.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }
}