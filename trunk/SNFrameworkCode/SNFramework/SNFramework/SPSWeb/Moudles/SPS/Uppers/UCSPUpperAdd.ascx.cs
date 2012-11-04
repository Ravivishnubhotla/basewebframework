  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Uppers
{
 
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPUpperAdd")]
    public partial class UCSPUpperAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPUpperAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPUpper_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPUpperWrapper obj = new SPUpperWrapper();
                obj.Name = this.txtName.Text.Trim();        	
                obj.Code = this.txtCode.Text.Trim();        	
                obj.Description = this.txtDescription.Text.Trim();
                obj.CreateBy = CurrentLoginUser.UserID;        	
                obj.CreateAt = System.DateTime.Now;
                obj.LastModifyBy = CurrentLoginUser.UserID;
                obj.LastModifyAt = System.DateTime.Now;        	
                obj.LastModifyComment = "创建上家。";        	





                SPUpperWrapper.Save(obj);

                winSPUpperAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }




}

