using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.LogManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemLogView")]
    public partial class UCSystemLogView : System.Web.UI.UserControl
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



                    this.lblLogLevel.Text = obj.LogLevel.ToString();
                    this.lblLogType.Text = obj.LogType.ToString();
                    this.lblLogDate.Text = obj.LogDate.ToString();
                    this.lblLogSource.Text = obj.LogSource.ToString();
                    this.lblLogUser.Text = obj.LogUser.ToString();
                    this.lblLogDescrption.Text = obj.LogDescrption.ToString();
                    this.lblLogRequestInfo.Text = obj.LogRequestInfo.ToString();
                    this.lblLogRelateMoudleID.Text = obj.LogRelateMoudleID.ToString();
                    this.lblLogRelateMoudleDataID.Text = obj.LogRelateMoudleDataID.ToString();
                    this.lblLogRelateUserID.Text = obj.LogRelateUserID.ToString();
                    this.lblLogRelateDateTime.Text = obj.LogRelateDateTime.ToString();





                    //hidLogID.Text = id.ToString();


                    winSystemLogView.Show();

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


    }
    
}