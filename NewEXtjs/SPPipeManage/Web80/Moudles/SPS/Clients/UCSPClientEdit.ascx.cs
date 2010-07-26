using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = System.Web.UI.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientEdit")]
    public partial class UCSPClientEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientWrapper obj = SPClientWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = obj.Name.ToString();
                    this.txtDescription.Text = obj.Description.ToString();
                    this.txtRecieveDataUrl.Text = obj.RecieveDataUrl.ToString();
                    this.chkSyncDate.Checked = obj.SyncData.HasValue ? obj.SyncData.Value:false;
                    this.txtOkMessage.Text = obj.OkMessage;
                    this.txtFailedMessage.Text = obj.FailedMessage;
                    if(!string.IsNullOrEmpty((obj.SyncType)))
                        this.cmbSycnType.SetValue(obj.SyncType);


                    hidId.Text = id.ToString();


                    winSPClientEdit.Show();

                }
                else
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
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

        protected void btnSaveSPClient_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientWrapper obj = SPClientWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.RecieveDataUrl = this.txtRecieveDataUrl.Text.Trim();
                obj.SyncData = this.chkSyncDate.Checked;
                obj.OkMessage = this.txtOkMessage.Text.Trim();
                obj.FailedMessage = this.txtFailedMessage.Text.Trim();
                obj.SyncType = this.cmbSycnType.SelectedItem.Value;

                SPClientWrapper.Update(obj);

                winSPClientEdit.Hide();
                
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
 