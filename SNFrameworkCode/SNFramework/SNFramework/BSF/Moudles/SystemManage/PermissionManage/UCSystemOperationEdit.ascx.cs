using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace SNFramework.BSF.Moudles.SystemManage.PermissionManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemOperationEdit")]
    public partial class UCSystemOperationEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemOperationWrapper obj = SystemOperationWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtOperationNameCn.Text = ValueConvertUtil.ConvertStringValue(obj.OperationNameCn);
                    this.txtOperationNameEn.Text = ValueConvertUtil.ConvertStringValue(obj.OperationNameEn);
                    this.txtOperationDescription.Text = ValueConvertUtil.ConvertStringValue(obj.OperationDescription);
                    this.chkIsSystemOperation.Checked = obj.IsSystemOperation;
                    this.chkIsCanSingleOperation.Checked = obj.IsCanSingleOperation;
                    this.chkIsCanMutilOperation.Checked = obj.IsCanMutilOperation;
                    this.chkIsEnable.Checked = obj.IsEnable;
                    this.chkIsInListPage.Checked = obj.IsInListPage;
                    this.chkIsInSinglePage.Checked = obj.IsInSinglePage;
                    this.txtOperationOrder.Text = obj.OperationOrder.ToString();
                    this.chkIsCommonOperation.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsCommonOperation);

                    if (obj.ResourceID != null)
                        this.txtResourceName.Text = obj.ResourceID.ResourcesNameCn;

                    hidOperationID.Text = id.ToString();


                    winSystemOperationEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message : Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemOperation_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemOperationWrapper obj = SystemOperationWrapper.FindById(int.Parse(hidOperationID.Text.Trim()));
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



                SystemOperationWrapper.Update(obj);

                winSystemOperationEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
                return;
            }

        }

    }
}