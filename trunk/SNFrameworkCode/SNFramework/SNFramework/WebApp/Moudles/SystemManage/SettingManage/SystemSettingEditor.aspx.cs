using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Common.WebApp.Moudles.SystemManage.SettingManage
{
    public partial class SystemSettingEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            SystemSettingWrapper obj = SystemSettingWrapper.GetCurrentSystemSetting();
            this.txtSystemName.Text = obj.SystemName;

            //if (obj.SystemName!=null)
            //{
            //    if(obj.SystemName.ToLower().StartsWith("[l]"))
            //    {
            //        this.txtSystemName.Triggers[0].HideTrigger = false;
            //    }
            //    else
            //    {
            //        this.txtSystemName.Triggers[0].HideTrigger = true;              
            //    }
            //}
            //else
            //{
            //    this.txtSystemName.Triggers[0].HideTrigger = true;           
            //}


            this.txtSystemDescription.Text = obj.SystemDescription;
            this.txtSystemUrl.Text = obj.SystemUrl;
            this.txtSystemVersion.Text = obj.SystemVersion;
            this.txtSystemLisence.Text = obj.SystemLisence;          
        }


        protected void btnSaveSystemSetting_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemSettingWrapper obj = SystemSettingWrapper.GetCurrentSystemSetting();
                obj.SystemName = this.txtSystemName.Text.Trim();
                obj.SystemDescription = this.txtSystemDescription.Text.Trim();
                obj.SystemUrl = this.txtSystemUrl.Text.Trim();
                obj.SystemVersion = this.txtSystemVersion.Text.Trim();
                obj.SystemLisence = this.txtSystemLisence.Text.Trim();


                SystemSettingWrapper.Update(obj);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = this.GetGlobalResourceObject("GlobalResource","msgErrorMsg").ToString() + ex.Message;
                return;
            }

        }
    }
}
