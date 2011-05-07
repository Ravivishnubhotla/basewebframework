using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;


namespace Legendigital.Common.WebApp.Moudles.SystemManage.LogManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemLogEdit")]
    public partial class UCSystemLogEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemLogWrapper obj = SystemLogWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtLogLevel.Text = obj.LogLevel.ToString();
                    this.txtLogType.Text = obj.LogType.ToString();
                    this.txtLogDate.Text = obj.LogDate.ToString();
                    this.txtLogSource.Text = obj.LogSource.ToString();
                    this.txtLogUser.Text = obj.LogUser.ToString();
                    this.txtLogDescrption.Text = obj.LogDescrption.ToString();
                    this.txtLogRequestInfo.Text = obj.LogRequestInfo.ToString();
                    //this.txtLogRelateMoudleID.Text = obj.LogRelateMoudleID.ToString();
                    //this.txtLogRelateMoudleDataID.Text = obj.LogRelateMoudleDataID.ToString();
                    this.txtLogRelateUserID.Text = obj.LogRelateUserID.ToString();
                    this.txtLogRelateDateTime.Text = obj.LogRelateDateTime.ToString();




                    hidLogID.Text = id.ToString();


                    winSystemLogEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }
        }

        protected void btnSaveSystemLog_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemLogWrapper obj = SystemLogWrapper.FindById(int.Parse(hidLogID.Text.Trim()));
                obj.LogLevel = this.txtLogLevel.Text.Trim();
                obj.LogType = this.txtLogType.Text.Trim();
                obj.LogDate = UIHelper.SaftGetDateTime(this.txtLogDate.Text.Trim()).Value;
                obj.LogSource = this.txtLogSource.Text.Trim();
                obj.LogUser = this.txtLogUser.Text.Trim();
                obj.LogDescrption = this.txtLogDescrption.Text.Trim();
                obj.LogRequestInfo = this.txtLogRequestInfo.Text.Trim();
                //obj.LogRelateMoudleID = Convert.ToInt32(this.txtLogRelateMoudleID.Text.Trim());
                //obj.LogRelateMoudleDataID = Convert.ToInt32(this.txtLogRelateMoudleDataID.Text.Trim());
                obj.LogRelateUserID = Convert.ToInt32(this.txtLogRelateUserID.Text.Trim());
                obj.LogRelateDateTime = UIHelper.SaftGetDateTime(this.txtLogRelateDateTime.Text.Trim());


                SystemLogWrapper.Update(obj);

                winSystemLogEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }

        }
    }

}