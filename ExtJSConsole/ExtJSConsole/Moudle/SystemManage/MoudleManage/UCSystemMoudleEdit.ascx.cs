using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.MoudleManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemMoudleEdit")]
    public partial class UCSystemMoudleEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SystemMoudleWrapper obj = SystemMoudleWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtMoudleNameCn.Text = obj.MoudleNameCn.ToString();
                    this.txtMoudleNameEn.Text = obj.MoudleNameEn.ToString();
                    this.txtMoudleNameDb.Text = obj.MoudleNameDb.ToString();
                    this.txtMoudleDescription.Text = obj.MoudleDescription.ToString();
                    this.txtApplicationID.Text = obj.ApplicationID.ToString();
                    this.chkMoudleIsSystemMoudle.Checked = obj.MoudleIsSystemMoudle;



                    hidSystemMoudleID.Text = id.ToString();


                    winSystemMoudleEdit.Show();

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

        protected void btnSaveSystemMoudle_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemMoudleWrapper obj = SystemMoudleWrapper.FindById(int.Parse(hidSystemMoudleID.Text.Trim()));
                obj.MoudleNameCn = this.txtMoudleNameCn.Text.Trim();
                obj.MoudleNameEn = this.txtMoudleNameEn.Text.Trim();
                obj.MoudleNameDb = this.txtMoudleNameDb.Text.Trim();
                obj.MoudleDescription = this.txtMoudleDescription.Text.Trim();
                //obj.ApplicationID = Convert.ToInt32(this.txtApplicationID.Text.Trim());
                obj.MoudleIsSystemMoudle = this.chkMoudleIsSystemMoudle.Checked;

                SystemMoudleWrapper.Update(obj);

                winSystemMoudleEdit.Hide();
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
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