using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.MoudleManage
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemMoudleEdit")]
    public partial class UCSystemMoudleEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
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




                    hidMoudleID.Text = id.ToString();


                    winSystemMoudleEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在！";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemMoudle_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemMoudleWrapper obj = SystemMoudleWrapper.FindById(int.Parse(hidMoudleID.Text.Trim()));
                obj.MoudleNameCn = this.txtMoudleNameCn.Text.Trim();
                obj.MoudleNameEn = this.txtMoudleNameEn.Text.Trim();
                obj.MoudleNameDb = this.txtMoudleNameDb.Text.Trim();
                obj.MoudleDescription = this.txtMoudleDescription.Text.Trim();
                obj.ApplicationID = null;
                obj.MoudleIsSystemMoudle = this.chkMoudleIsSystemMoudle.Checked;


                SystemMoudleWrapper.Update(obj);

                winSystemMoudleEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }


}