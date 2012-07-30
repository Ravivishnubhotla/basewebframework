using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.PermissionManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemOperationAdd")]
    public partial class UCSystemOperationAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show(int rid)
        {
            try
            {
                this.lblResourceName.Text = SystemResourcesWrapper.FindById(rid).ResourcesNameCn;

                this.hidResourcesID.Value = rid;

                this.winSystemOperationAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

        protected void btnSaveSystemOperation_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemOperationWrapper obj = new SystemOperationWrapper();
                obj.OperationNameCn = this.txtOperationNameCn.Text.Trim();
                obj.OperationNameEn = this.txtOperationNameEn.Text.Trim();
                obj.OperationDescription = this.txtOperationDescription.Text.Trim();
                obj.IsSystemOperation = this.chkIsSystemOperation.Checked;
                obj.IsCanSingleOperation = this.chkIsCanSingleOperation.Checked;
                obj.IsCanMutilOperation = this.chkIsCanMutilOperation.Checked;
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.IsInListPage = this.chkIsInListPage.Checked;
                obj.IsInSinglePage = this.chkIsInSinglePage.Checked;
                obj.OperationOrder = Convert.ToInt32(this.txtOperationOrder.Text.Trim());
                obj.IsCommonOperation = this.chkIsCommonOperation.Checked;



                obj.ResourceID = SystemResourcesWrapper.FindById(Convert.ToInt32(this.hidResourcesID.Value));





                SystemOperationWrapper.Save(obj);

                winSystemOperationAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }

    }
}