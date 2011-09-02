using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemDictionaryPatchEdit")]
    public partial class UCSystemDictionaryPatchEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void SubmitSelection(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            List<SystemDictionaryWrapper> allSavedata = JSON.Deserialize<List<SystemDictionaryWrapper>>(json);

            foreach (SystemDictionaryWrapper systemDictionaryWrapper in allSavedata)
            {
                SystemDictionaryWrapper up = SystemDictionaryWrapper.FindById(systemDictionaryWrapper.SystemDictionaryID);

                up.SystemDictionaryKey = systemDictionaryWrapper.SystemDictionaryKey;
                up.SystemDictionaryValue = systemDictionaryWrapper.SystemDictionaryValue;
                up.SystemDictionaryCode = systemDictionaryWrapper.SystemDictionaryCode;
                up.SystemDictionaryDesciption = systemDictionaryWrapper.SystemDictionaryDesciption;
                up.SystemDictionaryIsEnable = systemDictionaryWrapper.SystemDictionaryIsEnable;
                up.SystemDictionaryOrder = systemDictionaryWrapper.SystemDictionaryOrder;

                SystemDictionaryWrapper.Update(up);
            }


        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                gridPanelSystemDictionary.Title = "字典分组‘"+ DictionaryGroup.Name +"‘子项管理" ;
                this.winSystemDictionaryPatchEdit.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message：" + ex.Message;
            }
        }

        protected void storeFilterSystemDictionary_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            storeFilterSystemDictionary.DataSource = SystemDictionaryWrapper.GetDictionaryByCategoryName(DictionaryGroup.Code);
            storeFilterSystemDictionary.DataBind();
        }


        public SystemDictionaryGroupWrapper DictionaryGroup
        {
            get
            {
                if (this.Request.QueryString["DictionaryGroupID"] != null)
                {
                    return
                        SystemDictionaryGroupWrapper.FindById(int.Parse(this.Request.QueryString["DictionaryGroupID"]));
                }
                return null;
            }
        }
    }
}