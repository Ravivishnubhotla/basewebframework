using System;
using System.Collections.Generic;
using System.Linq;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientGroups
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientGroupEdit")]
    public partial class UCSPClientGroupEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientGroupWrapper obj = SPClientGroupWrapper.FindById(id);

                if (obj != null)
                {
					this.txtName.Text = obj.Name.ToString();          	
              	    this.txtDescription.Text = obj.Description.ToString();
                    this.txtDefaultSycnMoUrl.Text = obj.DefaultSycnMoUrl;
                    this.txtDefaultInterceptRate.Text = obj.DefaultInterceptRate.ToString();
                    this.txtDefaultNoInterceptCount.Text = obj.DefaultNoInterceptCount.ToString();

                    if (obj.AssignedUserID != null && obj.AssignedUserID.Value>0)
                    {
                        cmbSelectAssignedUser.Value = obj.AssignedUserID;
                    }
                    else
                    {
                        cmbSelectAssignedUser.ClearValue();
                    }

                    hidId.Text = id.ToString();

                    winSPClientGroupEdit.Show();

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

        protected void btnSaveSPClientGroup_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientGroupWrapper obj = SPClientGroupWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.DefaultSycnMoUrl = this.txtDefaultSycnMoUrl.Text.Trim();
                obj.DefaultInterceptRate = Convert.ToInt32(this.txtDefaultInterceptRate.Text);
                obj.DefaultNoInterceptCount = Convert.ToInt32(this.txtDefaultNoInterceptCount.Text);

                if (cmbSelectAssignedUser.SelectedItem != null)
                    obj.AssignedUserID = Convert.ToInt32(cmbSelectAssignedUser.SelectedItem.Value);
                else
                    obj.AssignedUserID = null;
                SPClientGroupWrapper.Update(obj);

                winSPClientGroupEdit.Hide();
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